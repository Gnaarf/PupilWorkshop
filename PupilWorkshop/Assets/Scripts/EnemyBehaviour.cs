using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {


    bool goingRight = false;
    float speed = 40;
    public float maxForce = 2;
    Rigidbody2D rb;
    Vector3 oldPosition;
    int timer = 0;
    int standingStill = 0;
    public GameObject border;

    // Use this for initialization
    void Start () {
	
	}

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        endlesswalk();
    }

    void OnTriggerEnter2D(Collider2D other)
    {         
        if (other.gameObject.tag == "Bullet")
            Destroy(gameObject);

        if (border != null)
        {
            if (timer <= 0)
            {

                for(int i = 0; i < border.transform.childCount; i++)
                {
                    if(border.transform.GetChild(i).gameObject == other.gameObject)
                    {
                        goingRight = !goingRight;
                        Vector3 newScale = transform.localScale;
                        newScale.x *= -1;
                        transform.localScale = newScale;
                        timer = 10;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (timer <= 0)
        {
            if (other.gameObject.tag == "Border")
            {
                goingRight = !goingRight;
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                timer = 10;
            }
        }
    }

    void endlesswalk()
    {
        if (oldPosition == transform.position)
        {
            standingStill++;
            if (standingStill >= 10)
            {
                goingRight = !goingRight;
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                timer = 10;
                standingStill = 0;
            }
        }
        else
        {
            standingStill = 0;
        }


        if (goingRight)
        {
            if (rb.velocity.x.CompareTo(maxForce) < 0)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            }
        }
        else
        {
            if (rb.velocity.x.CompareTo(-maxForce) > 0)
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            }
        }

        if (timer > 0) timer--;
        oldPosition = transform.position;
    }

}
