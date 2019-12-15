using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Swipe : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [Range(0.05f, 1f)]
    public GameObject plate;
    public float throwForce = 1f;
    public float test;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 2));
            transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
        }

        if (Input.touchCount > 0 & Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 & Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            GetComponent<Rigidbody2D>().AddForce(direction/timeInterval * throwForce);
        }

        }
    void OnBecameInvisible()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

}
