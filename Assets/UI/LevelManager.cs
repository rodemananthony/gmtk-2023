using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public HealthScript HealthScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthScript.HealthPoints <= 0)
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
