using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {


    public GameObject coin;
    public int scale = 3;

    public void createCoin()
    {
        GameObject coins = Instantiate(coin);
        coins.transform.parent = transform;
        Vector2 position = Random.insideUnitCircle;
        position.Scale(new Vector2(scale, scale));
        coins.transform.localPosition = position;
    }

    void Awake()
    {
        createCoin();
    }
}
