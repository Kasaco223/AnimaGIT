using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject zoomout;
    Pause pause;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        pause = FindAnyObjectByType<Pause>();
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        pause.PausarJuego();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad9))
        {
            zoomout.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        //skipear video
        if (Input.GetKeyUp(KeyCode.Mouse0))
            videoPlayer.frame = (long)610;

    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        pause.ReanudarJuego();
        zoomout.gameObject.SetActive(true);
        // Destruye el objeto que contiene este script
        audioSource.volume = 1f;
        Destroy(gameObject);
    }
}
