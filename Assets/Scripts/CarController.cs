using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carModel; // Modelo 3D del coche
    public GameObject car; // Objeto completo del coche
    public ParticleSystem impact; // Efecto de impacto
    public AudioSource engine; // Audio del motor
    public AudioSource crash; // Audio de impacto
    
    private float speed; // Velocidad del coche (la esfera)
    private Rigidbody rb; // Rigidbody del coche (la esfera)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Recoge el Rigidbody
        speed = GameManager.defaultSpeed; // Asigna velocidad normal
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.position = rb.position - new Vector3(0, .5f, 0); // Mueve el coche a la posición de la esfera
        if(GameManager.gameState != GameState.STARTED) return; // Si no ha empezado la ronda omite el código de abajo
        // Rotación del coche según input del jugador y del modelo 3D del coche, para que de impresión de que derrapa
        car.transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * .25f, 0);
        carModel.transform.eulerAngles = car.transform.eulerAngles + new Vector3(0, 180 + Input.GetAxis("Horizontal") * 10f, 0);
        engine.volume = 1 * Math.Abs(Input.GetAxis("Vertical")); // Sube el volumen del motor cuando se acelera
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration); // Gravedad (Fuerza hacia el suelo)
        if(GameManager.gameState != GameState.STARTED) return; // Si no ha empezado la ronda omite el código de abajo
        speed = GameManager.currentSpeed; // Asigna la velocidad máxima al coche
        rb.AddForce(car.transform.forward * Input.GetAxis("Vertical") * speed, ForceMode.Acceleration); // Acelera el coche
    }

    private void OnCollisionEnter(Collision other) {
        // Si colisiona con un enemigo reproduce efecto y sonido de impacto
        if(other.gameObject.CompareTag("Enemy"))
        {
            impact.Play();
            crash.Play();
        }
    }
}
