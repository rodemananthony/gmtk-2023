using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class MobScript : MonoBehaviour
{
    [SerializeField] MobDetails MobDetails;
    [SerializeField] WeaponData Weapon;
    GameObject Target { get; set; }

    [SerializeField]
    float? AttackClock = null;
    bool IsAttacking { get => AttackClock.HasValue; }

    bool _attackLock = false;
    bool CanAttack 
    { 
        get => AttackClock is null && !_attackLock; 
        set => _attackLock = value; 
    }

    int HealthPoints;

    public float separationRadius = 1f;
    public float separationMoveFactor = .25f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Target");

        HealthPoints = MobDetails.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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

            if (CanAttack && isInRange)
            {
                AttackClock = 0;
                Debug.Log($"{name}: Beginning Attack");
            }
        }
    }

    void UpdateTransform(out bool isInRange)
    {
        var (vecToTarget, distanceToInRange) = GetTargetingData();

        var moveDistance = Mathf.Min(distanceToInRange, Time.deltaTime * MobDetails.Speed);
        transform.position += moveDistance * vecToTarget.normalized;
        
        
        // Only decluster if mob would move anyways
        if (moveDistance > 0f)
        {
            DeclusterPosition();
        }
        
        transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, vecToTarget.normalized, Vector3.forward));

        (_, distanceToInRange) = GetTargetingData();
        isInRange = distanceToInRange <= 0f;
    }

    (Vector3, float) GetTargetingData()
    {
        var vecToTarget = (Target.transform.position - transform.position);
        var distanceToInRange = Mathf.Max(vecToTarget.magnitude - Weapon.Range, 0f);
        return (vecToTarget, distanceToInRange);
    }


    public void DeclusterPosition()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, separationRadius);

        int count = 0;

        float seperateSpeed = MobDetails.Speed * separationMoveFactor;

        Vector2 sum = Vector2.zero;

        foreach (var hit in hits)
        {
            if (hit.GetComponent<MobScript>() != null && hit.transform != transform)
            {
                Vector2 difference = transform.position - hit.transform.position;

                sum += difference.normalized;
                count++;
            }
        }

        if (count > 0)
        {
            sum /= count;
            sum = sum.normalized * seperateSpeed;

            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)sum, seperateSpeed * Time.deltaTime);
        }

    }


    public void AssignDamage(int damage)
    {
        HealthPoints -= damage;
    }
}