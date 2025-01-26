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
    public Transform player;
    public bool showCoins = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentTimer = 0;
        GameManager.currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (showCoins)
        {
            coinsText.text = GameManager.currentCoins + "/4";
        }

        if (GameManager.isStarted && !showCoins) {
            showCoins = true;
            StartCoroutine(StartTimer());
        }
    }

    private IEnumerator StartTimer()
    {
        int maxTimePlay = GameManager.defaultTimer;

        while (maxTimePlay > 0)
        {
            timerText.text = maxTimePlay.ToString();
            yield return new WaitForSeconds(1f);
            maxTimePlay--;
        }

        finishText.text = "Fail Level";
        yield return new WaitForSeconds(1f);
        timerText.text = "";
        coinsText.text = "";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FailScene");

    }
}
