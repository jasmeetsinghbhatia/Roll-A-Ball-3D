using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countCubes;
	public Text winText;
	public Text CollisionPoint;
	public List<string> cordinatesList = new List<string>();
	public float velocityBall;
	public Text velocityBallText;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText(count);
		winText.text = "";
	}

	void Update(){
		velocityBall = rb.velocity.magnitude;
		velocityBallText.text = "Speed of the ball is: " + velocityBall.ToString();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText(count);
			CollisionPoint.text="Collision point: " + other.transform.position.ToString();
			cordinatesList.Add(CollisionPoint.text);
		}
	}

	void SetCountText(int cube_count)
	{
		countCubes.text = "Cubes collected: " + cube_count.ToString ();
		if (count >= 12) {
			SetWinText ();
		}
			
	}

	void SetWinText()
	{
		winText.text = "Game Over";
	}
}