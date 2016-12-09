using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{ 
    
	public Player player; 
	public int blockindex;
	public Camera gameCamera;
	public GameObject [] blockprefabs;
	private float gamepointer;
	private float safespawningarea =400;
    public Text gameText;
    // Use this for initialization
    void Start()
	{
        gamepointer = -590;
		//Instantiate (blockprefabs [0]);

    }

    // Update is called once per frame
    void Update()

    {
        //Debug.Log(player.transform.position.x);
        if (player != null) {
			gameCamera.transform.position = new Vector3 (
	      	player.transform.position.x +50f,
				gameCamera.transform.position.y,
				gameCamera.transform.position.z);
            //gameText.text =  Mathf.Floor(player.transform.position.x + 31).ToString();
        }
        

		while (gamepointer < player.transform.position.x + safespawningarea) {
			//int blockindex = Random.Range (0, blockprefabs.Length);

			if (gamepointer < 0) {
				blockindex = 0;
			
			} 
			if (Time.time > 8 && Time.time < 30) {
				blockindex = 1;
			}

			if (Time.time > 30 && Time.time < 50) {
				blockindex = 2;
			}

			 if (Time.time > 50) {
				blockindex = 3;
			}


	
			GameObject blockobject = Instantiate (blockprefabs [blockindex]);
			Debug.Log (Time.time);
			blockobject.transform.SetParent (this.transform);
			Block block = blockobject.GetComponent<Block> ();
			blockobject.transform.position = new Vector2 (
				gamepointer + block.size/2, 0 );
			gamepointer += block.size/2;
		}

           

        }
      
    }

    

