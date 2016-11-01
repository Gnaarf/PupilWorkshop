using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour
{
    public KeyCode restartKey;
    bool firstFrame;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnEnable()
    {
        firstFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstFrame && Input.GetKeyDown(restartKey))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        firstFrame = false;
    }
}
