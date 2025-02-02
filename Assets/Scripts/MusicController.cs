using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Awake()
    {
        // Comprueba si ya existe un objeto con el tag Music, si es así destruye el objeto
        // Si no existe hace que el objeto no sea destruido al cambiar de escena para que la música no se pare nunca
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        camera = Camera.main; // Recoge la camara principal
        transform.position = camera.transform.position; // El objeto sigue a la cámara para que se escuche la música
    }
}
