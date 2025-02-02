using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceLevel2 : MonoBehaviour
{
    public Image finalText;
    public Sprite winSprite;
    public Sprite loseSprite;
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

        // Si el juego ha terminado muestra el texto de WIN o LOSE
        if (GameManager.gameState == GameState.FINISHED && !isFinished)
        {
            isFinished = true;
            StartCoroutine(EndRound(GameManager.currentObjective));
        }
    }

    private IEnumerator EndRound(string winner)
    {
        // Comprueba si el jugador ha ganado o no para mostrar el texto
        finalText.gameObject.SetActive(true);
        if (winner == "Player")
        {
            finalText.sprite = winSprite;
            GameManager.currentEnemyLifes--;
        }
        else
        {
            finalText.sprite = loseSprite;
            GameManager.currentLifes--;
        }

        yield return new WaitForSeconds(2f);

        // Si alguno de los dos coches no tiene vidas se termina el juego
        if (GameManager.currentLifes == 0 || GameManager.currentEnemyLifes == 0)
        {
            SceneManager.LoadScene("FinalScene");
        }
        // Si todavía tienen vida ambos se reinicia el nivel
        else
        {
            SceneManager.LoadScene("Level2Scene");
        }
    }
}
