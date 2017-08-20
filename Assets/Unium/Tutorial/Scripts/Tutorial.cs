﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public bool OpenBrowser = true;
    public Text PickupText;

    static bool OpenOnce = true;
    int NumPickups = 0;

    // exposed event for tutorial script to hook into
    public event Action<object> OnPickupCollected;

	void Start()
    {
        if( OpenBrowser && OpenOnce )
        {
            OpenOnce = false;
            System.Diagnostics.Process.Start( "http://localhost:8342/tutorial/index.html" );
        }
    }

    void PickupCreated()
    {
        NumPickups++;
        PickupText.text = NumPickups.ToString();
    }

    void PickupCollected()
    {
        NumPickups--;
        PickupText.text = NumPickups.ToString();

        GetComponent<AudioSource>().Play();

        Debug.Log( "Pickup collected" );

        if( OnPickupCollected != null )
        {
            OnPickupCollected( "Pickup Collected" );
        }
    }

    public void SayHello()
    {
        Debug.Log( "Hello from Unium" );
    }
}

