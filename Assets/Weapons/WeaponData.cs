using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    public float Range;
    public float CooldownSeconds;
    public int Damage;
    public float AttackTime;

    public GameObject AttackPrefab;

    public abstract void Attack(GameObject primaryTarget, TargetEnum validTargets, GameObject source);
}
