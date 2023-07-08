using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyText : MonoBehaviour
{
    public EnemyButtonManager EnemyButtonManager;
    public Text totalEnergyText;
    // Start is called before the first frame update
    void Start()
    {
        totalEnergyText.text = EnemyButtonManager.totalEnergyInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        totalEnergyText.text = EnemyButtonManager.totalEnergyInt.ToString();
    }
}
