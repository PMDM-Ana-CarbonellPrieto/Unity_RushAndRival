using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Camera camera;
    private AudioSource music;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camera = Camera.main;
        transform.position = camera.transform.position;
    }
}
