using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceLevel2 : MonoBehaviour
{
    public TMP_Text finalText;
    public TMP_Text playerLifes;
    public TMP_Text enemyLifes;

    private bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentObjective = "";
    }

     // Update is called once per frame
    void Update()
    {
        playerLifes.text = GameManager.currentLifes.ToString();
        enemyLifes.text = GameManager.currentEnemyLifes.ToString();

        if (GameManager.gameState == GameState.FINISHED && !isFinished)
        {
            isFinished = true;
            StartCoroutine(EndRound(GameManager.currentObjective));
        }
    }

    private IEnumerator EndRound(string winner)
    {
        if (winner == "Player")
        {
            finalText.text = "You win!";
            GameManager.currentEnemyLifes--;
        }
        else
        {
            finalText.text = "You lose!";
            GameManager.currentLifes--;
        }

        yield return new WaitForSeconds(2f);

        if (GameManager.currentLifes == 0 || GameManager.currentEnemyLifes == 0)
        {
            SceneManager.LoadScene("FinalScene");
        }
        else
        {
            SceneManager.LoadScene("Level2Scene");
        }
    }
}
