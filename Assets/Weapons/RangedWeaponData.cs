using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ranged")]
public class RangedWeaponData : WeaponData
{
    public float ProjectileSpeed;
    public float ProjectileHeight;
    public float ProjectileWidth;
    public int ProjectileCount;
    public int SpreadAngleRad;
    public int PierceDepth;


    public override void Attack(GameObject primaryTarget, TargetEnum validTargets, GameObject source)
    {
        var attackObject = Instantiate(AttackPrefab, source.transform);
    }
}
