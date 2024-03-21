using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text Health;
    public Text Money;

    public static int money=0;
    public static int health =200;
 
    // Start is called before the first frame update
    void Update()
    {
        Money.text = "Money:" + money.ToString();
        Health.text = "Health:" + health.ToString();
        if (health == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    
}
