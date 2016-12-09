using UnityEngine;
using System.Collections;

public class touchtester : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			if (Physics.Raycast (ray, out hit ,Mathf.Infinity)) {
				Debug.Log ("HIT SOMETHING");
				Debug.DrawRay (ray.origin, ray.direction * 20, Color.green);
				Destroy (hit.transform.gameObject);
			}
		}


	}
}
