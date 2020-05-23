using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallScript : MonoBehaviour
{
    private readonly Vector2 StartForce = new Vector2(150.0f, 150.0f);
    private Vector3 mBallPosition;
    private bool mIsActive;

    private Rigidbody2D mBallRigidBody;
    public GameObject platformObject;

    public DeathScreenScript deathScreenScript;

    private AudioSource mSource;
    private AudioClip mFailSound;
    private AudioClip mBounceSound;

    private void Start()
    {
        mIsActive = false;
        mBallRigidBody = GetComponent<Rigidbody2D>();
        mBallPosition = transform.position;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        mSource = audioSources[0];

        mBounceSound = audioSources[0].clip;
        mFailSound = audioSources[1].clip;
    }

    private void FixedUpdate()
    {
        if (!mIsActive)
        {
            try
            {
                mBallPosition.x = platformObject.transform.position.x;
                transform.position = mBallPosition;
            }
            catch (Exception e)
            {
                Debug.Log("Invalid platformObject");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!mIsActive)
            {
                mIsActive = true;

                mBallRigidBody.AddForce(StartForce);
            }
        }

        if (mIsActive && transform.position.y < -5.9f)
        {
            mSource.PlayOneShot(mFailSound);

            mIsActive = false;
            mBallRigidBody.velocity = Vector3.zero;
            mBallPosition.x = platformObject.transform.position.x;
            mBallPosition.y = -4.0f;
            transform.position = mBallPosition;

            HealthBarScript.NumberOfHearts--;
        }

        if (HealthBarScript.NumberOfHearts == 0)
        {
            deathScreenScript.ToggleDeathScreenOn(ScoreScript.ScoreValue);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (mIsActive)
        {
            mSource.PlayOneShot(mBounceSound);
        }
    }
}
