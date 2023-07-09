using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorScript : MonoBehaviour
{
    //public MobDetails Details;
    public bool shouldMoveAway;
    public Transform enemyTrans = null;
    public float speed = 7;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Survivor does move away but ends up just riding the edges of the screen eventually. Not sure if theres an easy way to fix

        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        // For moving away from enemies
        if (shouldMoveAway && enemyTrans != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyTrans.position, Time.deltaTime * speed * -1);

            //Debug.Log(new Vector2(transform.position.x-enemyTrans.transform.position.x, transform.position.y - enemyTrans.transform.position.y));
            //new Vector2(transform.position.x - enemyTrans.transform.position.x, transform.position.y - enemyTrans.transform.position.y)
        }

        // Attempt on trying to make the survivor not get cornered + not leave the carmera viewport.
        if (pos.x < 0.1 || .9 < pos.x || pos.y < 0.1 || .9 < pos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, -Camera.main.WorldToViewportPoint(transform.position), Time.deltaTime * speed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            shouldMoveAway = true;
            enemyTrans = collision.transform;
        }
    }
}
