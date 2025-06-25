using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject bar;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private float targetFill = 1.0f;
    private float currentFill = 1.0f;
    private float fillSpeed = 2.5f;

    void Start()
    {
        bar = GameObject.Find("HealthBar");
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    void Update()
    {
        currentFill = Mathf.Lerp(currentFill, targetFill, Time.deltaTime * fillSpeed);
        if (bar != null)
            bar.GetComponent<Image>().fillAmount = currentFill;
    }

    public void HitByBullet()
    {
        targetFill = Mathf.Clamp01(targetFill - 0.15f);

        if (targetFill <= 0.05f)
        {
            Destroy(bar);
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}