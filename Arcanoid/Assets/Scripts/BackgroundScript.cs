using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetKeyDown(KeyCode.Space) && !mIsMainThemePlay)
        {
            mMainTheme.Play();
            mIsMainThemePlay = true;
        }
        
        if (DeathScreenScript.isDead)
        {
            mMainTheme.Stop();
        }
    }
}
