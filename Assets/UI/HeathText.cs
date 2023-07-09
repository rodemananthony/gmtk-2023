using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathText : MonoBehaviour
{
    public HealthScript HealthScript;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health Left: " + HealthScript.HealthPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health Left: " + HealthScript.HealthPoints.ToString();
    }
}
