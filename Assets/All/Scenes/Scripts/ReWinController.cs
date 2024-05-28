using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ReWinController : MonoBehaviour
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
            SceneManager.LoadScene("Ruleta");
            tutorialSeguridad.SetActive(true);
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Ruleta");
        tutorialSeguridad.SetActive(true);

    }
}
