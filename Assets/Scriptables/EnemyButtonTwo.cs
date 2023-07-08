using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyButtonTwo : MonoBehaviour
{
    public EnemyButtonManager EnemyButtonManager;
    public DectectPlayer DectectPlayer;
    public Outline buttonOutlineOne;
    public Outline buttonOutlineTwo;
    public Outline buttonOutlineThree;

    private void Awake()
    {
        buttonOutlineTwo.enabled = false;
    }

    void Update()
    {
        if (DectectPlayer.canSpawn == true && EnemyButtonManager.isPressedTwo == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorTwo.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if ((DectectPlayer.canSpawn == false || EnemyButtonManager.totalEnergyInt <= DectectPlayer.energyLost) && EnemyButtonManager.isPressedTwo == true)
        {
            //Debug.Log("change color");
            EnemyButtonManager.indicatorTwo.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (EnemyButtonManager.isPressedTwo == true)
        {
            EnemyButtonManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //indicator follows mousepos while it is active
            EnemyButtonManager.indicatorTwo.SetActive(true);
            EnemyButtonManager.indicatorTwo.transform.position = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 10);
        }

        else if (EnemyButtonManager.isPressedTwo == false)
        {
            EnemyButtonManager.indicatorTwo.SetActive(false);
        }

        if (EnemyButtonManager.isPressedTwo == true && Input.GetMouseButtonDown(0) && DectectPlayer.canSpawn == true && EnemyButtonManager.totalEnergyInt >= DectectPlayer.energyLost && EventSystem.current.IsPointerOverGameObject() == false)
        {
            //Debug.Log("mouse pressed");
            EnemyButtonManager.enemyPos = new Vector3(EnemyButtonManager.mousePos.x, EnemyButtonManager.mousePos.y, 0);
            SpawnEnemy();

        }
    }

    public void ActivateEnemy()
    {
        if (EnemyButtonManager.isPressedTwo == false)
        {
            buttonOutlineOne.enabled = false;
            buttonOutlineTwo.enabled = true;
            buttonOutlineThree.enabled = false;
            EnemyButtonManager.isPressedOne = false;
            EnemyButtonManager.isPressedTwo = true;
            EnemyButtonManager.isPressedThree = false;
        }
        else if (EnemyButtonManager.isPressedTwo == true)
        {
            buttonOutlineTwo.enabled = false;
            EnemyButtonManager.isPressedTwo = false;
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyButtonManager.enemySpawnedTwo, EnemyButtonManager.enemyPos, Quaternion.identity);
        EnemyButtonManager.totalEnergyInt -= DectectPlayer.energyLost;
    }

}
