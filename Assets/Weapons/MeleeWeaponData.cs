using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Melee")]
public class MeleeWeaponData : WeaponData
{
    public float ArcAngleRad;

    public override void Attack(GameObject primaryTarget, TargetEnum validTargets, GameObject source)
    {
        throw new System.NotImplementedException();
    }
}
