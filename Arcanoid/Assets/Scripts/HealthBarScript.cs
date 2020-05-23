using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static int NumberOfHearts = 3;

    public Image[] hearts;

    private void FixedUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < NumberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
