using System.Collections;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    private bool hasObjective = false; // Si tiene el objetivo
    private bool isWaiting = false; // Si puede robar el objetivo

    public GameObject objective;

    // Update is called once per frame
    void Update()
    {
        // Comprueba si tiene el objetivo o no para asignar una velocidad
        if (GameManager.currentObjective == "Player")
        {
            GameManager.currentSpeed = GameManager.objectiveSpeed;
        } else {
            GameManager.currentSpeed = GameManager.defaultSpeed;
        }

        // Si tiene el objetivo lo coloca encima del coche
        if (hasObjective)
        {
            objective.transform.position = transform.position + new Vector3(0, .5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Si detecta el objetivo lo coge y desactiva el collider del objetivo
        if (other.CompareTag("Objective"))
        {
            GameManager.currentObjective = tag;
            hasObjective = true;
            objective.GetComponent<BoxCollider>().enabled = false;
        }

        // Si detecta la meta final del jugador y tiene el objetivo termina la ronda
        if (hasObjective && other.CompareTag(tag))
        {
            GameManager.gameState = GameState.FINISHED;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(GameManager.gameState != GameState.STARTED) return;
        if (!isWaiting && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")))
        {
            if (!hasObjective) GameManager.currentObjective = tag;
            hasObjective = !hasObjective;
            StartCoroutine(WaitForObjective());
        }
    }

    private IEnumerator WaitForObjective()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;
    }
}
