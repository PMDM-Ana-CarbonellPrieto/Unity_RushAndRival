using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceLevel1 : MonoBehaviour
{
    public TMP_Text finalText;
    public TMP_Text coinsText;
    public TMP_Text timerText;

    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentTime = 0;
        GameManager.currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = GameManager.currentCoins + "/4";
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
            timerText.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }

        StartCoroutine(EndLevel(time));
    }

    private IEnumerator EndLevel(int time)
    {
        if (time > 0)
        {
            finalText.text = "You win!";
            GameManager.currentTime = GameManager.defaultTimer - time;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Level2Scene");
        }
        else
        {
            GameManager.gameState = GameState.FINISHED;
            finalText.text = "You lose!";
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("FailScene");
        }
    }
}
