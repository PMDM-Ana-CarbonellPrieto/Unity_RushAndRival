using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carModel;
    public GameObject car;
    public ParticleSystem impact;
    public AudioSource engine;
    public AudioSource crash;
    
    private float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = GameManager.defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.position = rb.position - new Vector3(0, .5f, 0);
        if(GameManager.gameState != GameState.STARTED) return;
        car.transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * .25f, 0);
        carModel.transform.eulerAngles = car.transform.eulerAngles + new Vector3(0, 180 + Input.GetAxis("Horizontal") * 10f, 0);
        engine.volume = 1 * Math.Abs(Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration);
        if(GameManager.gameState != GameState.STARTED) return;
        speed = GameManager.currentSpeed;
        rb.AddForce(car.transform.forward * Input.GetAxis("Vertical") * speed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            impact.Play();
            crash.Play();
        }
    }
}
