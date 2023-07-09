using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{
    public MeleeWeaponData Weapon;

    float AttackClock = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale.Set(gameObject.transform.localScale.x, Weapon.Range, 1);
    }

    // Update is called once per frame
    void Update()
    {
        AttackClock += Time.deltaTime;

        // Trying to just get the melee attack to work before ranged attack

        // animate blade sweep by over Weapon.AttackTime starting from
        // (current rotation) - Weapon.ArcAngleRad * rad2deg / 2f  to
        // (current rotation) + Weapon.ArcAngleRad * rad2deg / 2f

        // Need to figure out how to determine hits
        // preferably don't use physics cuz i don't get it
        // maybe cast circle of r=Weapon.Range in Start(), then order list of mobs based on position & when they'd be hit
        // also need to filter out targets
        //      WeaponData.Attack() has this info available, which can be provided to this script
        // on hit: objectThatIsHit.GetComponent<HealthScript>().TakeDamage(Weapon.Damage)
        

        if (AttackClock >= Weapon.AttackTime)
        {
            Destroy(gameObject);
        }
    }
}
