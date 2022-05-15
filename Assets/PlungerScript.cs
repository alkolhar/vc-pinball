using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlungerScript : MonoBehaviour
{
    public float power;
    float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerSlider.value = power;
        if (ballList.Count > 0) {
            if (Input.GetKey(KeyCode.Space)) {
                if (power <= maxPower) {
                    power += 500*Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                foreach(Rigidbody r in ballList) {
                    r.AddForce(power*Vector3.forward);
                }
            }
        } else {
            power = minPower;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
            powerSlider.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            powerSlider.gameObject.SetActive(false);
            power = minPower;
        }
    }
}
