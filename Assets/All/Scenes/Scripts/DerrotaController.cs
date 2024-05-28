using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DerrotaController : MonoBehaviour
{
    public GameObject tutorialVideo;
    public GameObject tutorialSeguridad;
    private VideoPlayer videoPlayer;
    Pause pause;
    private void Start()
    {
        pause = FindObjectOfType<Pause>();
        pause.PausarJuego();
        videoPlayer = tutorialVideo.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            LevelMaster2.LoadRandomScene();
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        LevelMaster2.LoadRandomScene();
        tutorialSeguridad.SetActive(true);
        
    }
}


