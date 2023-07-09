using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public RangedWeapon RangedWeapon;
    Rigidbody2D rb;
    public float projSpeed = 5f;
    public float timeToDestroy = 3f;
    float timePassed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Target");
        RangedWeapon = player.GetComponentInChildren<RangedWeapon>();
        enemy = RangedWeapon.enemy;

        // This shoots the projectile towards the enemy
        // I know this does use the rigidbody but this was the only thing I found to work after messing with it for a few hours
        Vector2 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * projSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // timer to destory the projectile if the projectile doesnt hit anything
        if(timePassed < timeToDestroy)
        {
            timePassed += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // if projectile hits enemy
        {
            // you should be able to get the MobScript from here using collision.GetComponent<MobScript>(); as well as any other component on the enemy it hit if needed
            Debug.Log("damage");
            collision.GetComponent<HealthScript>().TakeDamage(RangedWeapon.damage);
            Destroy(gameObject); // This works in the sense that it does delete the projectile, but theres a chance that it will destroy the projectile before it can actually go through with any more code that is added so keep that in mind.
        }
    }
}
