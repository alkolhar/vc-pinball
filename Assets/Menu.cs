using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string chooseFlipper;
    public GameObject pauseMenu;
    public bool isPaused;
    public string mainMenuScene;

    public GameObject optionsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(chooseFlipper);
    }

    public void ResumeGame() {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain() {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OpenOptions() {
        optionsScreen.SetActive(true);
    }


    public void CloseOptions() {
        optionsScreen.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }


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

    public static void restartGame() {
        score = 0;
        ballCount = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
