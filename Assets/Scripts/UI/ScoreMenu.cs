using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField] private GameObject scoreMenuContainer;
    [SerializeField] private GameObject finalScore;
    [SerializeField] private AudioClip crashSFX, clickSFX;
    [SerializeField] private AudioClip gameMusic;
    private bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        SoundManager.Instance.PlaySingleMusic(gameMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.GetHealth() <= 0 & !gameOver)
        {
            ShowScore();
            gameOver = true;
        }
    }

    private void ShowScore()
    {
        Time.timeScale = 0f;
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlaySFX(crashSFX);
        finalScore.GetComponent<TextMeshProUGUI>().text = stats.GetScore().ToString();
        scoreMenuContainer.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayClickSFX()
    {
        SoundManager.Instance.PlaySFX(clickSFX);
    }
}
