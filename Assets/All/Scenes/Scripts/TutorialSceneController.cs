using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialController1 : MonoBehaviour
{
    public GameObject tutorialVideo;
    public GameObject tutorialImage;
    private VideoPlayer videoPlayer;
    MasterTime masterTime;
    private void Start()
    {
        // Obtén el componente VideoPlayer del objeto tutorialVideo
        videoPlayer = tutorialVideo.GetComponent<VideoPlayer>();

        // Agrega un listener al evento loopPointReached del VideoPlayer
        videoPlayer.loopPointReached += OnVideoEnd;
        masterTime = FindAnyObjectByType<MasterTime>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        { 
            LevelMaster2.LoadRandomScene();
            masterTime.StartTimer();
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // Activa la imagen del tutorial cuando el video termine
        tutorialImage.SetActive(true);  
    }
}
