using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreValue;
    
    private Text mScore;
    
    void Start()
    {
        mScore = GetComponent<Text>();
        mScore.text = "StartText";
        
        ScoreValue = 0;
    }
    
    void FixedUpdate()
    {
        AddScore();

        if (DeathScreenScript.isDead)
        {
            Destroy(this.gameObject);
        }
    }

    private void AddScore()
    {
        mScore.text = "Score: " + ScoreValue;
    }
}