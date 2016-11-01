using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public Vector3 position;

    void Awake()
    {
        position = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        position = gameObject.transform.position;

        if (position.x > Boundary.boundaryRight)
        {
            Destroy(gameObject);
        }

        if (position.x < Boundary.boundaryLeft)
        {
            Destroy(gameObject);
        }
        if (position.y > Boundary.boundaryUp)
        {
            Destroy(gameObject);
        }
        if (position.y < Boundary.boundaryDown)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Border" || other.gameObject.tag == "WorldObject")
            Destroy(gameObject);
    }
}
