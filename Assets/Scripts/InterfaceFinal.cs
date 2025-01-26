using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceFinal : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text coinsText;
    public TMP_Text lifesText;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text += GameManager.currentTime + "\"";
        coinsText.text = GameManager.currentCoins.ToString();
        lifesText.text = GameManager.currentLifes.ToString();
        scoreText.text += CalculateScore().ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private int CalculateScore()
    {
        int score = 0;
        int time = GameManager.defaultTimer - GameManager.currentTime;
        score += time / 10 * GameManager.defaultScore;
        score += GameManager.currentCoins * GameManager.defaultScore;
        score += GameManager.currentLifes * GameManager.defaultScore;
        return score;
    }
}
