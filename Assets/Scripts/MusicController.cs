using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Awake()
    {
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
        camera = Camera.main;
        transform.position = camera.transform.position;
    }
}
