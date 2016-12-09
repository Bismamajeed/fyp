using UnityEngine;
using System.Collections;

public class touchcontrols : MonoBehaviour 

{  
	//public float jumpForce;
	//public float hordist;
	Rigidbody2D rb;
	public int speed;

	public float minSwipeDistY;

	public float minSwipeDistX;

	private Vector2 startPos;
	private float TouchTime;

	void Start()
	{ rb = GetComponent<Rigidbody2D> ();}

	void Update()
	{

	GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);


		//#if UNITY_ANDROID
		if (Input.touchCount > 0 )
		{	Touch touch = Input.touches[0];

			switch (touch.phase) 

			{

			case TouchPhase.Began:

				startPos = touch.position;
				TouchTime = Time.time;


				break;

		case TouchPhase.Stationary:
	
				if (Time.time - TouchTime > 0.3f) {

					longjump ();
				}
				break;


			case TouchPhase.Ended:


			//	if (Time.time - TouchTime > 0.5f) {
			//		longjump ();
			//	}
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {

					float swipeValue = Mathf.Sign (touch.position.y - startPos.y);

					if (swipeValue > 0)//up swipe

						jump ();
					else if (swipeValue < 0)//down swipe

						shrink ();

				}

			

				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) {

					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);

					if (swipeValue > 0)//right swipe

						MoveRight ();
					else if (swipeValue < 0)//left swipe

						MoveLeft ();
					

				} 


				else {
					jump ();
				}
				break;
				}
			}
	}



	public void jump () 
	{
		
		rb.AddForce (new Vector2(0,400));

	}


	public void shrink () 
	{
		rb.AddForce (new Vector2(0,-400));

	}
	public void MoveRight  () 
	{
		rb.AddForce (new Vector2(400,0));

	}

	public void MoveLeft  () 
	{
		rb.AddForce (new Vector2(-400,0));

	}

	public void longjump  () 
	{
		rb.AddForce (new Vector2(5,5));

	}


}