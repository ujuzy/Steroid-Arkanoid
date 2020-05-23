using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundScript : MonoBehaviour
{
    private AudioSource mMainTheme;
    private bool mIsMainThemePlay;

    void Start()
    {
        mMainTheme = GetComponent<AudioSource>();
        mMainTheme.loop = true;
        mIsMainThemePlay = false;
    }
    
    void FixedUpdate()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Brick").Length);
        
        if (Input.GetKeyDown(KeyCode.Space) && !mIsMainThemePlay)
        {
            mMainTheme.Play();
            mIsMainThemePlay = true;
        }
        
        if (DeathScreenScript.isDead)
        {
            mMainTheme.Stop();
        }

        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0 &&
            !DeathScreenScript.isDead)
        {
            SceneManager.LoadScene(2);
        }
    }
}
