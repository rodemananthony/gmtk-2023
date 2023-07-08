using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyButtonOne : MonoBehaviour
{
    public PauseMenu PauseMenu;
    public EnemyButtonManager EnemyButtonManager;
    public DectectPlayer DectectPlayer;
    public Outline buttonOutlineOne;
    public Outline buttonOutlineTwo;
    public Outline buttonOutlineThree;

    private void Awake()
    {
        buttonOutlineOne.enabled = false;
    }

    void Update()
    {
        if (DectectPlayer.canSpawn == true && EnemyButtonManager.isPressedOne == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorOne.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if ((DectectPlayer.canSpawn == false || EnemyButtonManager.totalEnergyInt <= DectectPlayer.energyLost) && EnemyButtonManager.isPressedOne == true)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorOne.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (EnemyButtonManager.isPressedOne == true && PauseMenu.isPaused == false)
        {
            EnemyButtonManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //indicator follows mousepos while it is active
            EnemyButtonManager.indicatorOne.SetActive(true);
            EnemyButtonManager.indicatorOne.transform.position = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 10);
        }

        else if (EnemyButtonManager.isPressedOne == false)
        {
            EnemyButtonManager.indicatorOne.SetActive(false);
        }

        if (EnemyButtonManager.isPressedOne == true && Input.GetMouseButtonDown(0) && DectectPlayer.canSpawn == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost && EventSystem.current.IsPointerOverGameObject() == false)
        {
            //Debug.Log("mouse pressed");
            EnemyButtonManager.enemyPos = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 0);
            SpawnEnemy();

        }

        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("over ui");
        }*/
    }

    public void ActivateEnemy()
    {
        if (EnemyButtonManager.isPressedOne == false)
        {
            buttonOutlineOne.enabled = true;
            buttonOutlineTwo.enabled = false;
            buttonOutlineThree.enabled = false;
            EnemyButtonManager.isPressedOne = true;
            EnemyButtonManager.isPressedTwo = false;
            EnemyButtonManager.isPressedThree = false;
        }
        else if (EnemyButtonManager.isPressedOne == true)
        {
            buttonOutlineOne.enabled = false;
            EnemyButtonManager.isPressedOne = false;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyButtonManager.enemySpawnedOne, EnemyButtonManager.enemyPos, Quaternion.identity);
        EnemyButtonManager.totalEnergyInt -= DectectPlayer.energyLost;
    }

}
