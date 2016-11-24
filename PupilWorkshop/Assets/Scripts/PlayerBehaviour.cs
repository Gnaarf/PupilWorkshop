using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject weapon;
    public GameObject gameOver;

    public bool spieler1 = true;
    int points;
    float speed = 40;
    float maxForce = 6;
    bool grounded = false;
    bool goingRight = false;
    bool blockInput = false;
    public GameObject Waffe1;
    public GameObject Waffe2;

    Shootspawner schusswaffe;
    Shootspawner wurfwaffe;
    Rigidbody2D rb;
    

    // Use this for initialization
    void Start()
    {
    }

    void Awake()
    {
        schusswaffe = Waffe1.GetComponent<Shootspawner>();
        wurfwaffe = Waffe2.GetComponent<Shootspawner>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y.CompareTo(0) == 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        if (!blockInput)
        {
            if (spieler1)
            { 
                if (Input.GetKey(KeyCode.D))
                {
                    if (!goingRight)
                    {
                        goingRight = true;
                        Vector3 newScale = transform.localScale;
                        newScale.x *= -1;
                        transform.localScale = newScale;
                    }
                    if (rb.velocity.x.CompareTo(maxForce) < 0)
                    {
                        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    if (goingRight)
                    {
                        goingRight = false;
                        Vector3 newScale = transform.localScale;
                        newScale.x *= -1;
                        transform.localScale = newScale;
                    }
                    if (rb.velocity.x.CompareTo(-maxForce) > 0)
                    {
                        rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                    }
                }
                if (Input.GetKeyDown(KeyCode.W) && grounded)
                {
                    rb.AddForce(Vector3.up * 500);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    schusswaffe.shoot();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    wurfwaffe.shoot();
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (!goingRight)
                    {
                        goingRight = true;
                        Vector3 newScale = transform.localScale;
                        newScale.x *= -1;
                        transform.localScale = newScale;
                    }
                    if (rb.velocity.x.CompareTo(maxForce) < 0)
                    {
                        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (goingRight)
                    {
                        goingRight = false;
                        Vector3 newScale = transform.localScale;
                        newScale.x *= -1;
                        transform.localScale = newScale;
                    }
                    if (rb.velocity.x.CompareTo(-maxForce) > 0)
                    {
                        rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
                {
                    rb.AddForce(Vector3.up * 500);
                }

                if (Input.GetKeyDown(KeyCode.Keypad8))
                {
                    schusswaffe.shoot();
                }
                if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    wurfwaffe.shoot();
                }

            }
        
        }


        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!blockInput)
            {
                gameOver.GetComponent<SpriteRenderer>().enabled = true;
                blockInput = true;
            }
            else
            {
                gameOver.GetComponent<SpriteRenderer>().enabled = false;
                blockInput = false;
            }
        }

        schusswaffe.setGoingRight(goingRight);
        wurfwaffe.setGoingRight(goingRight);
    }

    public void addPoints(int value)
    {
        points += value;
    }
}
