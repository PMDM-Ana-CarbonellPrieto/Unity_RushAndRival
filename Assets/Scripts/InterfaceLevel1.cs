using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceLevel1 : MonoBehaviour
{
    public TMP_Text finishText;
    public TMP_Text coinsText;
    public TMP_Text timerText;

    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentTimer = 0;
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
        int maxTime = GameManager.defaultTimer;

        while (maxTime > 0 && GameManager.gameState != GameState.FINISHED)
        {
            timerText.text = maxTime.ToString();
            yield return new WaitForSeconds(1f);
            maxTime--;
        }

        finishText.text = "Fail Level";
        yield return new WaitForSeconds(1f);
        timerText.text = "";
        coinsText.text = "";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FailScene");

    }
}
