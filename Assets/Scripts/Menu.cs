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
    [SerializeField] private TextMeshProUGUI bonusScreen;
    public bool isPaused, showBonus, showHighscore;
    public string mainMenuScene;

    public GameObject optionsScreen;

    public static Menu instance;
    private float t = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        showHighscore = false;
        if (highscoreText) {
            highscore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "-highscore", highscore);
            highscoreText.text = "Highscore: " + highscore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for interrupt
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        // Update Score
        if (scoreText) {
            scoreText.text = "Score: " + score;
            if (score > highscore) {
                // Update Highscore
                showHighscore = true;
                highscore = score;
                highscoreText.text = "Highscore: " + highscore;
            
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "-highscore", highscore);
            }
        }

        // Fade in/out Bonus screen
        if (this.showBonus) {
            Color c = bonusScreen.color;
            if (t < 1){
                bonusScreen.color = new Color(c.r, c.g, c.b, t);
                t += Time.deltaTime;
            } else {
                bonusScreen.color = new Color(c.r, c.g, c.b, 0);
                this.showBonus = false;
                t = 0;
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


    public float score = 0;
    public float highscore;
    public int ballCount = 3;
    public int multiplyer = 1;

    public void decreaseBallCount() {
        ballCount--;
    }

    public void increaseBallCount() {
        ballCount++;
    }

    public void updateScore(float gotScore) {
        score += multiplyer * gotScore;
    }

    public void restartGame() {
        score = 0;
        ballCount = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
