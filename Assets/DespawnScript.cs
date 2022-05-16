using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Manager = Menu;

public class DespawnScript : MonoBehaviour
{
    public GameObject myBall;
    private Vector3 startVector;
    [SerializeField] private TextMeshProUGUI ballCountText;
    [SerializeField] private TextMeshProUGUI newHighscore;
    [SerializeField] private GameObject goDialog;

    
    // Start is called before the first frame update
    void Start()
    {
        goDialog.SetActive(false);
        ballCountText.text = "Remaining balls: " + Menu.instance.ballCount;
        startVector = new Vector3(3.058f, 0.266f, -3.8f);
        myBall.transform.position = startVector;
    }

    void OnCollisionEnter(Collision collision)
     {
         if (collision.collider.gameObject.tag == "Ball")
         {
             collision.collider.gameObject.SetActive(false); // deactivate ball
             Menu.instance.decreaseBallCount(); // reduce amount of playable balls
             ballCountText.text = "Remaining balls: " + Menu.instance.ballCount;

             spawnBall();
         }
     }

    void spawnBall() {
        if (Menu.instance.ballCount > 0) {
            myBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            myBall.transform.position = startVector; // Set Ball to start position
            Menu.instance.multiplyer = 1; // Reset mulitplyer
            myBall.SetActive(true); // Show ball
        } else {
            Color c = newHighscore.color;
            if (Menu.instance.showHighscore) {
                newHighscore.color = new Color(c.r, c.g, c.b, 1);
            } else {
                newHighscore.color = new Color(c.r, c.g, c.b, 0);
            }
            goDialog.SetActive(true);
        }
    }
}
