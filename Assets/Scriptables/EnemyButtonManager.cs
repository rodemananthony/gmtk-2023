using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButtonManager : MonoBehaviour
{
    public bool isPressedOne = false;
    public bool isPressedTwo = false;
    public bool isPressedThree = false;
    public GameObject enemySpawnedOne;
    public GameObject enemySpawnedTwo;
    public GameObject enemySpawnedThree;
    public GameObject indicatorOne;
    public GameObject indicatorTwo;
    public GameObject indicatorThree;
    public Vector3 mousePos;
    public Vector3 enemyPos;
    // This is where we can mess with the total energy the player will have per level
    public int totalEnergyInt;
}
