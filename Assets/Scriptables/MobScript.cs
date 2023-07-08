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
