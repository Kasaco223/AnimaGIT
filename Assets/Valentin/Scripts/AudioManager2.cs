using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [SerializeField] private AudioSource soundtrack;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SFXAlarm;
    [SerializeField] private AudioClip SFXOnFire;
    [SerializeField] private AudioClip SFXExtinguishedFire;

    private bool onceTime;
    private int timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        onceTime = true;
        timer = 0;
    }

    void Update()
    {
        if (onceTime)
        {
            OnceTime();
            onceTime = false;
        }


        switch (timer)
        {
            case 0:
                //la alarma suena 3 veces y empieza la musica
                if (audioSource.time >= 5f)
                {
                    audioSource.Stop();
                    audioSource.clip = SFXOnFire;
                    audioSource.Play();
                    soundtrack.volume = 1f;

                    timer = 1;
                }
                break;
            case 1:
                //se quita el sonido de llama
                if (audioSource.time >= 15f)
                {
                    audioSource.volume -= Time.deltaTime / 5;
                    Debug.Log(audioSource.volume);
                    
                    if(audioSource.volume <= 0)
                        timer = 2;
                }
                break;
            case 2:
                //empieza a sonar el fuego siendo apagado
                audioSource.Stop();
                audioSource.clip = SFXExtinguishedFire;
                audioSource.Play();
                audioSource.volume = 1;
                
                soundtrack.volume -= Time.deltaTime / 5;
                Debug.Log(soundtrack.volume);

                if (soundtrack.volume <= 0)
                    timer = 3;
                
                break;
        }
    }

    private void OnceTime()
    {
        audioSource.Play();
    }
}
