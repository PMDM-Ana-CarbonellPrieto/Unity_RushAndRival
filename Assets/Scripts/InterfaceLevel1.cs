using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceLevel1 : MonoBehaviour
{
    public TMP_Text finalText;
    public TMP_Text coinsText;
    public TMP_Text timerText;
    public Button actionButton;
    public TMP_Text actionText;
    public Button exitButton;

    private bool isStarted = false;
    private bool isWinning = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentTime = 0;
        GameManager.currentCoins = 0;
        GameManager.currentLifes = 0;
        timerText.text = "Timer: " + GameManager.defaultTimer + "\"";
        actionButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = GameManager.currentCoins.ToString();
        if (GameManager.gameState == GameState.STARTED && !isStarted) {
            isStarted = true;
            StartCoroutine(StartTimer());
        }
    }

    private IEnumerator StartTimer()
    {
        int time = GameManager.defaultTimer;

        while (time > 0 && GameManager.gameState != GameState.FINISHED)
        {
            yield return new WaitForSeconds(1f);
            time--;
            timerText.text = "Timer: " + time + "\"";
        }

        StartCoroutine(EndLevel(time));
    }

    private IEnumerator EndLevel(int time)
    {
        if (time > 0)
        {
            isWinning = true;
            finalText.text = "You win!";
            GameManager.currentTime = GameManager.defaultTimer - time;
            actionText.text = "Next Level";
        }
        else
        {
            GameManager.gameState = GameState.FINISHED;
            finalText.text = "You lose!";
            actionText.text = "Restart";
        }

        yield return new WaitForSeconds(1f);
        actionButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void DoAction()
    {
        if (isWinning)
        {
            GameManager.currentLifes = GameManager.currentCoins == 0 ? 1 : GameManager.currentCoins;
            SceneManager.LoadScene("Level2Scene");
        }
        else
        {
            SceneManager.LoadScene("Level1Scene");
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
