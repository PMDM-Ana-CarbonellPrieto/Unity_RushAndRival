using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceLevel2 : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text finalText;

    private bool isEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentSpeed = 0;
        GameManager.currentObjective = "";
        StartCoroutine(StartRound());
    }

     // Update is called once per frame
    void Update()
    {
        if (!GameManager.isStarted && GameManager.currentObjective != "" && !isEnded)
        {
            isEnded = true;
            StartCoroutine(EndRound(GameManager.currentObjective));
        }
    }

    private IEnumerator StartRound() {
        GameManager.isStarted = false;

        int count = 3;
        while (count > 0)
        {
            countText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }
        countText.text = "Start";
        yield return new WaitForSeconds(1f);
        countText.text = "";

        GameManager.isStarted = true;
    }

    private IEnumerator EndRound(string winner)
    {
        if (winner == "Player")
        {
            countText.text = "You win!";
            GameManager.currentEnemyCoins--;
        }
        else
        {
            countText.text = "You lose!";
            GameManager.currentCoins--;
        }

        yield return new WaitForSeconds(2f);

        if (GameManager.currentCoins == 0 || GameManager.currentEnemyCoins == 0)
        {
            SceneManager.LoadScene("FinalScene");
        }
        else
        {
            SceneManager.LoadScene("Level2Scene");
        }
    }
}
