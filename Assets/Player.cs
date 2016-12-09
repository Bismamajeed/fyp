using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour 

{   public float speed;

	Ray ray;
	RaycastHit hit;
	Rigidbody rb;
	public Camera cam;
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	private float TouchTime;
	private bool check = false;
	RaycastHit2D hitInfo;
     private int score=0;
    public Text gameScore;
    private float timeLimit = 20.0f;
    public pausegame pg;
    bool Grounded;

    void Start()
	{

		rb = GetComponent<Rigidbody> ();

	}

	void Update()

	{
        if (Time.timeSinceLevelLoad >= timeLimit)
        {
            speed += 5;
            timeLimit += 50f;
        }

        gameScore.text = score.ToString();
        GetComponent<Rigidbody>().velocity = new Vector2(speed, GetComponent<Rigidbody>().velocity.y);
		//#if UNITY_ANDROID
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began)

			    {
				ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
					if (Physics.Raycast (ray, out hit ,Mathf.Infinity)) {
						Debug.Log ("HIT SOMETHING");
						Debug.DrawRay (ray.origin, ray.direction * 
						20, Color.green);
					if (hit.collider.gameObject.tag == "banana") {
						Destroy (hit.transform.gameObject);
					}
					}
				}

				startPos = touch.position;
				TouchTime = Time.time;
				//casting a rayhit2d from touch position to (0,0), hitinfo will store the information about object that collides with the casted ray

				//Vector2 playerpos = transform.position;
				//Vector2 touchpos = Input.GetTouch (0).position;

				//hitInfo = Physics2D.Raycast (playerpos, touchpos, 700);
				//Debug.DrawRay(transform.position, Input.GetTouch(0).position,Color.red);
				//if (hitInfo.collider != null) {
				//	if (hitInfo.collider.gameObject.tag != "Player" && hitInfo.collider.gameObject.tag != "Obstacle") 
				//	{ Destroy (hitInfo.collider.gameObject);
                  //      score = score + 5; ;
                       // gameScore.text = score.ToString();

                       // transform.position = new Vector3(0.3f, 0, 0);
                   // }
				//}



			 if (touch.phase == TouchPhase.Stationary)
			{
				if (Time.time - TouchTime > 0.3f && Time.time - TouchTime < 0.8f )
				{
					longjump();
				}
			}

			else if (touch.phase == TouchPhase.Ended)
			{if (Time.time - TouchTime < 0.15f   && hitInfo.collider == null )
				{ jump();
				}

				else
				{
					float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

					if (swipeDistVertical > minSwipeDistY)
					{
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

					if (swipeValue > 0  && hitInfo.collider == null )//up swipe
							jump();
						else if (swipeValue < 0)//down swipe
							shrink();
					}

					float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

					if (swipeDistHorizontal > minSwipeDistX)
					{
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

						if (swipeValue > 0)//right swipe

							MoveRight();
						else if (swipeValue < 0)//left swipe

							MoveLeft();
					}
				}
			}
		}

	}


	void OnTriggerEnter (Collider c){
		if (c.tag == "Obstacle" || c.tag == "banana") {
			GameObject.Destroy (this.gameObject);
         pg.PauseGame();

        }
		Debug.Log ("trigger entered");
	}




	public void jump () 
	{
        if (Grounded)
        {
            
            rb.AddForce(new Vector2(0, 350));
        }
		
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
           // if (Grounded==true)
            rb.AddForce (new Vector2(0,22));

	}


	

	void OnCollisionStay2D(Collision2D collider)
	{
		CheckIfGrounded ();
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		Grounded = false;
	}

	private void CheckIfGrounded()
	{
		RaycastHit2D[] hits;

		// raycast down 1 pixel from this position to check for a collider
		Vector2 positionToCheck = transform.position;
		hits = Physics2D.RaycastAll (positionToCheck, new Vector2 (0, -1), 0.01f);

		//if a collider was hit, we are grounded
		if (hits.Length > 0) {
			Grounded = true;
		}
	}
}