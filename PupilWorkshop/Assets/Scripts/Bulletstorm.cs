using UnityEngine;
using System.Collections;

public class Bulletstorm : MonoBehaviour {

    bool goingRight = true;
    float speed = 0;
    Transform rb;

    // Use this for initialization
    void Start () {
	
	}

    void Awake()
    {
        rb = transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (goingRight)
        {
            rb.position += Vector3.right * speed;
        }
        else
        {
            rb.position -= Vector3.right * speed;
        }
    }

    public void setDirection(bool right, float speed)
    {
        goingRight = right;
        this.speed = speed;
    }
}
