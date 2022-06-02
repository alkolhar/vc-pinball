using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager = Menu;

public class TargetScript : MonoBehaviour
{
    private int hitCount;
    private string targetHit;
    private float timeLeft, timeShow, rotateTimeLeft, rotateTimeRight;
    private bool leftLockSet, rightLockSet;
    private Vector3 originalPos;

    public GameObject leftLock;
    public GameObject rightLock;

    [SerializeField] private Vector3 target = new Vector3(1, 1, 1);
    [SerializeField] private float speed = 1;  
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        leftLockSet = rightLockSet = false;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Multiplyer Countdown
        timeLeft -= Time.deltaTime;

        // Reposition Countdown
        timeShow -= Time.deltaTime;

        // Rotate Countdown
        rotateTimeLeft -= Time.deltaTime;
        rotateTimeRight -= Time.deltaTime;

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

        if (leftLockSet && rotateTimeLeft < 0) {
            RotateLock(leftLock, 5.0f, Color.red);
            leftLockSet = false;
        }
        if (rightLockSet && rotateTimeRight < 0) {
            RotateLock(rightLock, -5.0f, Color.red);
            rightLockSet = false;
        }
    }

    void OnCollisionEnter(Collision collision)
     {

        if (this.CompareTag("LeftLocker")) {
            leftLockSet = true;
            RotateLock(leftLock, -30.0f, Color.red);
            rotateTimeLeft = 25;
        } else if (this.CompareTag("RightLocker")) {
            rightLockSet = true;
            RotateLock(rightLock, 30.0f, Color.red);
            rotateTimeRight = 25;
        } else if (hitCount == 0) {
            Menu.instance.showBonus = true;
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

     void RotateLock(GameObject go, float angle, Color col) {
         Debug.Log(go.name + " : " + angle);
        go.transform.Rotate(0.0f, angle, 0.0f);
        go.GetComponent<Renderer>().material.color = col; 
     }
}
