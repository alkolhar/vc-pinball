using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public string chooseFlipper;
    public GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    public bool isPaused;
    public string mainMenuScene;

    public GameObject optionsScreen;

    public static Menu instance;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        highscoreText.text = "Highscore: " + highscore;
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

        scoreText.text = "Score: " + score;
        if (score > highscore) {
            highscore = score;
            highscoreText.text = "Highscore: " + highscore;
        
            PlayerPrefs.SetFloat("highscore", highscore);
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


    public float score = 0;
    public float highscore;
    public int ballCount = 3;
    public float scorePerHit = 999;
    public int multiplyer = 1;

    public void decreaseBallCount() {
        ballCount--;
    }

    public void increaseBallCount() {
        ballCount++;
    }

    public void updateScore() {
        score += multiplyer * scorePerHit;
    }

    public void restartGame() {
        score = 0;
        ballCount = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
