using UnityEngine;
using System.Collections;

public class BewegendePlattform : MonoBehaviour {

    Transform plattform;
    public float maxRechts = 3f;
    public float maxLinks = 3f;
    public float maxHoch = 3f;
    public float maxTief = 3f;
    float transformLinks;
    float transformRechts;
    float transformHoch;
    float transformTief;
    float translationXr;
    float translationYh;
    public bool rechts = true;
    public bool hoch = true;
    public int schritte = 100;


    void Awake()
    {
        transformLinks = transform.localPosition.x - maxLinks;
        transformRechts = transform.localPosition.x + maxRechts;
        transformHoch = transform.localPosition.y + maxHoch;
        transformTief = transform.localPosition.y - maxTief;

        translationXr = (maxRechts+maxLinks) / schritte;
        translationYh = (maxHoch+maxTief) / schritte;

    }
	// Update is called once per frame
	void FixedUpdate () {
        if (rechts)
        {

            transform.Translate(new Vector2(translationXr, 0));
        }
        else
        {
            transform.Translate(new Vector2(-translationXr, 0));
        }
        if(hoch)
        {
            transform.Translate(new Vector2(0, translationYh));
        }
        else
        {
            transform.Translate(new Vector2(0, -translationYh));
        }
        if (transform.localPosition.x > transformRechts) rechts = false;
        if (transform.localPosition.x < transformLinks) rechts = true;
        if (transform.localPosition.y > transformHoch) hoch = false;
        if (transform.localPosition.y < transformTief) hoch = true;
    }
}
