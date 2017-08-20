using System;
using UnityEngine;
using UnityEngine.UI;

public class Testmini3dgame : MonoBehaviour
{
	public bool OpenBrowser = true;
	static bool OpenOnce = true;

	void Start()
	{
		if( OpenBrowser && OpenOnce )
		{
			OpenOnce = false;
			System.Diagnostics.Process.Start( "http://localhost:8342/Tests/index.html" );
		}
	}
}
