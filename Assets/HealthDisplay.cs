using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    public Player myPlayer;
    public Text healthText;

    // Update is called once per frame
    void Update()
    { 
        // health = myPlayer.getHealth();
        // healthText.text = "test" + myPlayer.getHealth();
        healthText.text = myPlayer.getHealth().ToString();
    }
}
