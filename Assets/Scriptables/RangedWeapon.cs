using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ranged")]
public class RangedWeapon : Weapon
{
    public float ProjectileSpeed;
    public float ProjectileHeight;
    public float ProjectileWidth;
    public int ProjectileCount;
    public int SpreadAngleRad;
}
