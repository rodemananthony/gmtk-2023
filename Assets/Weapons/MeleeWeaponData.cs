using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Melee")]
public class MeleeWeaponData : WeaponData
{
    public float ArcAngleRad;

    public override void Attack(GameObject primaryTarget, TargetEnum validTargets, GameObject source)
    {
        var attackObject = Instantiate(AttackPrefab, source.transform);
        var attackScript = attackObject.GetComponent<MeleeAttackScript>();
        attackScript.Weapon = this;        
    }
}
