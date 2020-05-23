using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int hitsToDestroy;

    private int mHitsDone;

    private void Start()
    {
        mHitsDone = 0;
    }

    private void FixedUpdate()
    {
        if (HealthBarScript.NumberOfHearts == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            mHitsDone++;

            if (hitsToDestroy == mHitsDone)
            {
                Destroy(this.gameObject);

                ScoreScript.ScoreValue += mHitsDone * 10;
            }
        }
    }
}
