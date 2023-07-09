using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    int HealthPoints;
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = FindAnyObjectByType<MobDetails>().MaxHealth;
    }

    void TakeDamage(int damage)
    {
        Debug.Log($"{name} takes {damage} damage");
        HealthPoints -= damage;

        if (HealthPoints <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
