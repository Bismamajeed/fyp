using UnityEngine;
using System.Collections;

public class EndlessScrolling : MonoBehaviour {

    public float speed = 0.5f;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;
    }
}
