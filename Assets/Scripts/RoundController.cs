using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public Image countText;
    public Image finalText;
    public Sprite oneSprite; // Imagen del 1
    public Sprite twoSprite; // Imagen del 2
    public Sprite threeSprite; // Imagen del 3
    public Sprite startSprite; // Imagen del Start

    private AudioSource startRace; // Audio cuenta atrás
    
    // Start is called before the first frame update
    void Start()
    {
        startRace = GetComponent<AudioSource>(); // Recoge el reproductor de audio
        GameManager.currentSpeed = GameManager.defaultSpeed;
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        GameManager.gameState = GameState.PREPARED; // Cambia el estado del juego para iniciar
        yield return new WaitForSeconds(2f);
        
        countText.gameObject.SetActive(true); // Pone visible el contador
        startRace.Play(); // Inicia el audio de cuenta atrás
        // Hace una cuenta atrás desde 3
        int count = 3;
        while (count > 0)
        {
            // Dependiendo del número actual de la cuenta atrás selecciona una imagen
            switch (count)
            {
                case 3:
                    countText.sprite = threeSprite;
                    break;
                case 2:
                    countText.sprite = twoSprite;
                    break;
                default:
                    countText.sprite = oneSprite;
                    break;
            }
            yield return new WaitForSeconds(1f);
            count--;
        }
        countText.gameObject.SetActive(false); // Oculta el contado

        // Muestra el texto de Start
        finalText.gameObject.SetActive(true);
        finalText.sprite = startSprite;
        yield return new WaitForSeconds(1f);

        finalText.gameObject.SetActive(false); // Oculta el Start
        GameManager.gameState = GameState.STARTED; // Cambia el estado del juego para empezar
    }
}
