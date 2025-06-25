using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        if (scoreText != null)
            scoreText.text = "Score: " + finalScore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("SampleScene"); 
    }
}