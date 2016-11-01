using UnityEngine;
using System.Collections;

public class Shootspawner : MonoBehaviour {

    Vector3 position;
    bool goingRight = false;
    Transform body;
    public GameObject bullet;
    float speed = .4f;

    // Use this for initialization
    void Start ()
    {      
    }

    void Awake()
    {
        body = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void FixedUpdate()
    {
    }

    public void shoot()
    {
        GameObject shot = (GameObject) Instantiate(bullet,body.position,body.localRotation);
        shot.GetComponent<Bulletstorm>().setDirection(goingRight, speed);
    }

    public void setGoingRight(bool right)
    {
        goingRight = right;
    }
}
