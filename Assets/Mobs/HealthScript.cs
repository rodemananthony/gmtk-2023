using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int HealthPoints = 1000000;
    // Start is called before the first frame update
    void Start()
    {
        int? mobHealth = FindAnyObjectByType<MobScript>()?.MobDetails.MaxHealth;
        if (mobHealth != null)
        {
            HealthPoints = mobHealth.Value;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{name} takes {damage} damage");
        HealthPoints -= damage;


        if(HealthPoints == 0)
        {
            Destroy(gameObject);
        }
        if (HealthPoints < 0 )
        {
            HealthPoints = 0;
            Destroy(gameObject);
        }
    }
}
