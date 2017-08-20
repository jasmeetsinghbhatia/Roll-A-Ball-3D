using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour {

	public float timer;
	public int newtarget;
	public float speed;
	public NavMeshAgent nav;
	public Vector3 target;
	public bool updateOn = true;
	public bool isReady = false;

	// Use this for initialization
	void Start () {
		nav = gameObject.GetComponent<NavMeshAgent> ();
		StartCoroutine (updateOff());
	}

	// Update is called once per frame
	void Update () {

		if (updateOn == true) {
			timer += Time.deltaTime;

			if (timer >= newtarget) {
				nav.speed = speed;
				newTarget();
				timer = 0;
			}
		}
	}

	IEnumerator updateOff ()
	{
		yield return new WaitForSeconds (30.0f);
		updateOn = false;
		reset ();
		yield break;
	}

	void newTarget(){
		float myX = gameObject.transform.position.x;
		float myZ = gameObject.transform.position.z;

		float xPos = myX + Random.Range(-10, 10);
		float zPos = myZ + Random.Range(-20, 20);

		target = new Vector3 (xPos, gameObject.transform.position.y, zPos);
		nav.SetDestination (target);
	}

	void reset(){
		nav.speed = 0.0f;
		isReady = true;
	}
}
