using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject proj;
    public GameObject enemy;
    float timeToAttack = 5f;
    float cooldown = 1f;
    public Vector2 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cooldown moment
        timeToAttack = timeToAttack + Time.deltaTime;
    }


    // Detects if theres enemies in its attack range and spawns projectiles from there
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
            if(timeToAttack >= cooldown)
            {
                enemyPos = collision.transform.position;
                GameObject a = Instantiate(proj, transform.position, Quaternion.identity);
                timeToAttack = 0;
            }
        }
    }
}
