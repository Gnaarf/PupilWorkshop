using UnityEngine;
using System.Collections;

public class SpawningCoin : MonoBehaviour {

    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerBehaviour>().addPoints(value);
            GetComponentInParent<CoinSpawner>().createCoin();
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        transform.localPosition = Random.insideUnitCircle;
    }
}
