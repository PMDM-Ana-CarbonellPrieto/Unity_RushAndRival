using System.Collections;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public Transform respawn; // Posición del respawn
    public ParticleSystem[] boosts = new ParticleSystem[3]; // Efectos del boost
    public AudioSource coin; // Audio de la moneda

    private Vector3 respawnPosition; // Posición del respawn
    private int checkPoints = 0; // Checkpoints por los que ha pasado

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = respawn.position + Vector3.up; // Recoge la posición principal para el respawn
        foreach (ParticleSystem boost in boosts)
        {
            boost.Stop(); // Para todos los efectos
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si detecta una moneda reproduce el audio, aumenta el número de recogidas y destruye la moneda
        if (other.CompareTag("Coin"))
        {
            coin.Play();
            GameManager.currentCoins++;
            Destroy(other.gameObject);
        }
        // Si detecta un checkpoint quita el trigger para que no vuelva a darle boost e inicia el boost
        else if (other.CompareTag("CheckPoint"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            checkPoints++;
            StartCoroutine(TakeBoost());
        }
        // Si detecta un respawn guarda la posición
        else if (other.CompareTag("Respawn"))
        {
            respawnPosition = other.transform.position;
        }
        // Si detecta la meta y ha pasado por todos los checkpoint cambia el estado del juego a terminado
        else if (other.CompareTag("Finish") && checkPoints == 3)
        {
            GameManager.gameState = GameState.FINISHED;
        }
    }

    private void OnCollisionEnter(Collision other) {
        // Si colisiona con el suelo de la habitación lleva el coche al respawn
        if (other.gameObject.CompareTag("Floor"))
        {
            transform.position = respawnPosition;
        }
    }

    private IEnumerator TakeBoost()
    {
        GameManager.currentSpeed = GameManager.boostSpeed; // Da la velocidad del boost
        // Inicia todos los efectos visuales del boost
        foreach (ParticleSystem boost in boosts)
        {
            boost.Play();
        }
        // Después de unos segundos se desactivan los efectos
        yield return new WaitForSeconds(2.5f);
        foreach (ParticleSystem boost in boosts)
        {
            boost.Stop();
        }
        GameManager.currentSpeed = GameManager.defaultSpeed; // Devuelve la velocidad normal
    }
}
