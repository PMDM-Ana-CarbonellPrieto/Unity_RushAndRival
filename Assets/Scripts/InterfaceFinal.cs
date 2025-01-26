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
        scoreText.text += "200";
    }

    public void Restart()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
