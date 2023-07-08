using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectPlayer : MonoBehaviour
{
    public bool canSpawn = true;
    // This is where we mess with how much energy spawning an enemy costs
    public int energyLost = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            canSpawn = false;
            //Debug.Log("hit collider");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            canSpawn = true;
            //Debug.Log("hit collider");
        }
    }
}
