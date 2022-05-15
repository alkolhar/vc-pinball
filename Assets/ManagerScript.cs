using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static float score = 0;
    public static int ballCount = 3;
    public static float scorePerHit = 999;

    public static void decreaseBallCount() {
        ballCount--;
    }

    public static void increaseBallCount() {
        ballCount++;
    }

    public static void updateScore() {
        score += scorePerHit;
    }

    public static void quitGame() {
        Application.Quit();
    }

    public static void restartGame() {
        score = 0;
        ballCount = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
