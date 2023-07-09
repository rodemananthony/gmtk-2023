using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MobScript : MonoBehaviour
{
    [SerializeField] MobDetails MobDetails;
    [SerializeField] WeaponData Weapon;
    GameObject Target { get; set; }
    MobManagerScript Manager { get; set; }

    [SerializeField]
    float? AttackClock = null;
    bool IsCoolingDown = false;

    bool CanAttack { get => AttackClock is null && !IsCoolingDown; }

    // Start is called before the first frame update
    void Start()
    {
        Target ??= GameObject.FindGameObjectWithTag("Target");
        Manager ??= FindAnyObjectByType<MobManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) return;

        if (AttackClock is float clock) 
        {
            clock += Time.deltaTime;
            var attackProportion = Mathf.Min(clock / Weapon.AttackTime, 1f);

            if (clock >= Weapon.AttackTime)
            {
                AttackClock = null;
                Debug.Log($"{name}: Ended Attack");
            }
            else
            {
                AttackClock = clock;
            }
        }
        else
        {
            UpdateTransform(out bool isInRange);
            Debug.Log($"{name} is {(isInRange ? "":"not ")}in range");
            if (CanAttack && isInRange)
            {
                AttackClock = 0;
                Debug.Log($"{name}: Beginning Attack");
                StartAttack();
            }
        }
    }

    void UpdateTransform(out bool isInRange)
    {
        var (vecToTarget, distanceToInRange) = GetTargetingData();

        var moveDistance = Mathf.Min(distanceToInRange, Time.deltaTime * MobDetails.Speed);
        transform.position += moveDistance * (Vector3)vecToTarget.normalized;
        
        
        // Only decluster if mob would move anyways
        if (moveDistance > 0f)
        {
            DeclusterPosition(vecToTarget);
        }


        (vecToTarget, distanceToInRange) = GetTargetingData();

        float angle = Mathf.Atan2(vecToTarget.y, vecToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        isInRange = distanceToInRange <= 0f;
    }

    (Vector2, float) GetTargetingData()
    {
        Vector2 vecToTarget = Target.transform.position - transform.position;
        var distanceToInRange = Mathf.Max(vecToTarget.magnitude - Weapon.Range, 0f);
        return (vecToTarget, distanceToInRange);
    }


    public void DeclusterPosition(Vector2 slipDirection)
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, Manager.separationRadius);

        int count = 0;

        float seperationSpeed = MobDetails.Speed * Manager.separationMoveFactor;

        Vector2 sum = Vector2.zero;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy") && hit.transform != transform)
            {
                Vector2 difference = transform.position - hit.transform.position;

                sum += difference / Mathf.Pow(difference.magnitude, 2);
                count++;
            }
        }

        if (count > 0)
        {
            sum /= count;
            sum = (sum.normalized * seperationSpeed);

            // slip is meant to help prevent mobs getting stuck between 
            //sum += slipDirection.normalized * Manager.separationSlipFactor;

            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)sum, seperationSpeed * Time.deltaTime);
        }

    }

    public void StartAttack()
    {
        Weapon.Attack(Target, TargetEnum.Survivor, gameObject);
    }

}
