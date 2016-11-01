using UnityEngine;
using System.Collections;

public class PlayerBehaviour2 : MonoBehaviour
{
    public float speed;
    public bool fancy;
    public float jumpStrengh;
    int counter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float targetXSpeed = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            targetXSpeed += speed;
        if(Input.GetKey(KeyCode.LeftArrow))
            targetXSpeed -= speed;


        if (fancy)
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, targetXSpeed, 0.1F), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetXSpeed, rb.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpStrengh);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<RestartScene>().enabled = true;
        }
    }
}
