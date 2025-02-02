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
        timeText.text += GameManager.currentTime + "\""; // Tiempo de la carrera
        coinsText.text = GameManager.currentCoins.ToString(); // Monedas recogidas
        lifesText.text = GameManager.currentLifes.ToString(); // Vidas restantes
        scoreText.text += CalculateScore().ToString(); // Puntuación máxima
    }

    public void Restart()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // Calcula los puntos multiplicando las monedas, el tiempo y las vidas restantes por el multiplicador base
    private int CalculateScore()
    {
        int score = 0;
        int time = GameManager.defaultTimer - GameManager.currentTime;
        score += time * GameManager.defaultScore;
        score += GameManager.currentCoins * GameManager.defaultScore;
        score += GameManager.currentLifes * GameManager.defaultScore;
        return score;
    }
}
