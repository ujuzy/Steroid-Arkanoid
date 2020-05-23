using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    private AudioSource mDeathTheme;

    public static bool isDead;
    
    void Start()
    {
        gameObject.SetActive(false);
        mDeathTheme = GetComponent<AudioSource>();
        isDead = false;
    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void ToggleDeathScreenOn(int score)
    {
        gameObject.SetActive(true);

        isDead = true;
    }

    public void Restart()
    {
        HealthBarScript.NumberOfHearts = 3;
        
        gameObject.SetActive(false);

        isDead = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
