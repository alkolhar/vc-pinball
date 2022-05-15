using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager = Menu;

public class TargetScript : MonoBehaviour
{
    private int hitCount;
    private string targetHit;
    private float timeLeft, timeShow;
    private Vector3 originalPos;

    [SerializeField] private Vector3 target = new Vector3(1, 1, 1);
    [SerializeField] private float speed = 1;  
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Multiplyer Countdown
        timeLeft -= Time.deltaTime;

        // Reposition Countdown
        timeShow -= Time.deltaTime;

        if (hitCount > 0) {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            // If time is up, reset multiplyer
            if (timeLeft < 0) {
                Menu.instance.multiplyer = 1;
                hitCount = 0;
            }
        }

        if (timeShow < 0) {
            // Reset the position
            ResetPosition();
        }
    }

    void OnCollisionEnter(Collision collision)
     {
        if (hitCount == 0) {
            GetComponent<AudioSource>().Play();
            hitCount = 1;
            Menu.instance.multiplyer++;
            timeLeft = 10;
            timeShow = 30;
        }
     }

     void ResetPosition() {
        transform.position = originalPos;
     }
}
