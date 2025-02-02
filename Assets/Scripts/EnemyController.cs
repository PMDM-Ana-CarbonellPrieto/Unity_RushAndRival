using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform objective; // Objetivo central
    public Transform target; // Meta del enemigo
    public GameObject car; // Modelo del coche

    private float speed; // Velocidad máxima (esfera)
    private Rigidbody rb; // Rigidbody (esfera)
    private AudioSource engine; // Audio del motor

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Recoge el Rigidbody
        engine = GetComponent<AudioSource>(); // Recoge el reproductor de audio
        speed = GameManager.defaultSpeed; // Asigna velocidad normal
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.position = rb.position - new Vector3(0, .5f, 0); // Mueve el coche a la posición de la esfera
        if(GameManager.gameState != GameState.STARTED) return; // Si no ha empezado la ronda omite el código de abajo
        // Comprueba si tiene el objetivo o no para asignar la velocidad adecuada y calcular rotación del target u objetivo
        Quaternion rotation;
        if (GameManager.currentObjective == tag)
        {
            speed = GameManager.objectiveSpeed; // Velocidad lenta
            rotation = Quaternion.LookRotation(target.position - rb.transform.position); // Devuelve la rotación hacia la meta
        } else {
            speed = GameManager.defaultSpeed; // Velocidad normal
            rotation = Quaternion.LookRotation(objective.position - new Vector3(0, .5f, 0) - rb.transform.position); // Devuelve la rotación hacia el objetivo
        }
        float diff = (rotation.y - car.transform.rotation.y) * .9f; // Calcula diferencia entre rotación actual y rotación al objetivo o target para que realice el giro lentamente
        car.transform.rotation = new Quaternion(rotation.x, rotation.y - diff, rotation.z, rotation.w); // Aplica rotación al coche
        engine.volume = 1; // Sube a tope el volumen del motor
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration); // Gravedad (Fuerza hacia el suelo)
        if(GameManager.gameState != GameState.STARTED) return; // Si no ha empezado la ronda omite el código de abajo
        rb.AddForce(car.transform.forward * speed, ForceMode.Acceleration); // Acelera el coche
    }
}
