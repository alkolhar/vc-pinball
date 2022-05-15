using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Manager = Menu;

public class BumperScript : MonoBehaviour
{
    public float force = 100.0f;
    public float forceRadius = 1.0f;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Sounds


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnCollisionEnter() {
        foreach (Collider col in Physics.OverlapSphere(transform.position, forceRadius)) {
            if (col.GetComponent<Rigidbody>()) {
                // Play sound
                GetComponent<AudioSource>().Play();
                // Add force
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, forceRadius);
                // Add score
                Manager.score += 999;
                scoreText.text = "Score: " + Manager.score;
            }
        }
    }
}
