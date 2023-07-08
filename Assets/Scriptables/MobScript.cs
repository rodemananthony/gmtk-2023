using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MobScript : MonoBehaviour
{
    [SerializeField] private MobDetails MobDetails;
    [SerializeField] private Weapon Weapon;
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

    public float seperateRadius = 1f; // Made this public so we can change it in the inspector

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
            clock = clock + Time.deltaTime;
            var attackProportion = Mathf.Min(clock / Weapon.AttackTime, 1f);

            if (clock >= Weapon.AttackTime)
            {
                AttackClock = null;
            }
            else
            {
                AttackClock = clock;
            }
        }
        else
        {
            UpdatePosition(out bool isInRange);

            if (CanAttack && isInRange)
            {
                AttackClock = 0;
            }        
        }
    }

    void UpdatePosition(out bool isInRange)
    {
        var vecToTarget = (Target.transform.position - transform.position);

        var distanceToInRange = Mathf.Max(vecToTarget.magnitude - Weapon.Range, 0f);

        /*var hits = Physics2D.OverlapCircleAll(transform.position, seperateRadius);

        float count = 0f;

        float seperateSpeed = MobDetails.Speed / 2f;

        Vector2 sum = Vector2.zero;

        foreach (var hit in hits)
        {
            if (hit.GetComponent<MobScript>() != null && hit.transform != transform)
            {
                Vector2 difference = transform.position - hit.transform.position;

                difference = difference.normalized / Mathf.Abs(difference.magnitude);

                sum += difference;
                count++;
            }
        }

        if (count > 0)
        {
            sum /= count;
            sum = sum.normalized * seperateSpeed;

            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)sum, seperateSpeed * Time.deltaTime);
        }*/
        // This works but I think it overrides the code below this. I think its just merging them both together for it to not override but I just didnt want to mess with anything here and possibly make everything worse.


        if (distanceToInRange == 0f) 
        {
            isInRange = true;
        }
        else
        {
            var moveDistance = Mathf.Min(distanceToInRange, Time.deltaTime * MobDetails.Speed);

            transform.position += Mathf.Min(distanceToInRange, Time.deltaTime * MobDetails.Speed) * vecToTarget.normalized;

            isInRange = moveDistance >= distanceToInRange;

        }
    }
}
