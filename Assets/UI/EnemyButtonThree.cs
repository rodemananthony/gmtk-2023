using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyButtonThree : MonoBehaviour
{
    public PauseMenu PauseMenu;
    public EnemyButtonManager EnemyButtonManager;
    public DectectPlayer DectectPlayer;
    public Outline buttonOutlineOne;
    public Outline buttonOutlineTwo;
    public Outline buttonOutlineThree;

    private void Awake()
    {
        buttonOutlineThree.enabled = false;
    }

    void Update()
    {
        if (DectectPlayer.canSpawn == true && EnemyButtonManager.isPressedThree == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorThree.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if ((DectectPlayer.canSpawn == false || EnemyButtonManager.totalEnergyInt <= DectectPlayer.energyLost) && EnemyButtonManager.isPressedThree == true)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorThree.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (EnemyButtonManager.isPressedThree == true && PauseMenu.isPaused == false)
        {
            EnemyButtonManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //indicator follows mousepos while it is active
            EnemyButtonManager.indicatorThree.SetActive(true);
            EnemyButtonManager.indicatorThree.transform.position = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 10);
        }

        else if (EnemyButtonManager.isPressedThree == false)
        {
            EnemyButtonManager.indicatorThree.SetActive(false);
        }

        if (EnemyButtonManager.isPressedThree == true && Input.GetMouseButtonDown(0) && DectectPlayer.canSpawn == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost && EventSystem.current.IsPointerOverGameObject() == false)
        {
            //Debug.Log("mouse pressed");
            EnemyButtonManager.enemyPos = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 0);
            SpawnEnemy();

        }
    }

    public void ActivateEnemy()
    {
        if (EnemyButtonManager.isPressedThree == false)
        {
            buttonOutlineOne.enabled = false;
            buttonOutlineTwo.enabled = false;
            buttonOutlineThree.enabled = true;
            EnemyButtonManager.isPressedOne = false;
            EnemyButtonManager.isPressedTwo = false;
            EnemyButtonManager.isPressedThree = true;
        }
        else if (EnemyButtonManager.isPressedThree == true)
        {
            buttonOutlineThree.enabled = false;
            EnemyButtonManager.isPressedThree = false;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyButtonManager.enemySpawnedThree, EnemyButtonManager.enemyPos, Quaternion.identity);
        EnemyButtonManager.totalEnergyInt -= DectectPlayer.energyLost;
    }

}
