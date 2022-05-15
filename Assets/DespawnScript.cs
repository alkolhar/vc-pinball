using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Manager = ManagerScript;

public class DespawnScript : MonoBehaviour
{
    public GameObject myBall;
    private Vector3 startVector;
    [SerializeField] private TextMeshProUGUI ballCountText;
    [SerializeField] private GameObject goDialog;
    
    // Start is called before the first frame update
    void Start()
    {
        goDialog.SetActive(false);
        ballCountText.text = "Remaining balls: " + Manager.ballCount;
        startVector = new Vector3(3.058f, 0.266f, -3.8f);
        myBall.transform.position = startVector;
    }

    void OnCollisionEnter(Collision collision)
     {
         if (collision.collider.gameObject.tag == "Ball")
         {
             collision.collider.gameObject.SetActive(false); // deactivate ball
             Manager.decreaseBallCount(); // reduce amount of playable balls
             ballCountText.text = "Remaining balls: " + Manager.ballCount;

             spawnBall();
         }
     }

    void spawnBall() {
        if (Manager.ballCount > 0) {
            myBall.transform.position = startVector; // Set Ball to start position
            myBall.SetActive(true); // Show ball
        } else {
            Debug.Log("TODO: GameOver routine!");
            goDialog.SetActive(true);
        }
    }
}
