using UnityEngine;
using System.Collections.Generic;

public class MasterSound : MonoBehaviour
{
    public List<AudioClip> loopedSounds;
    public AudioClip mouseClickSound; // Nuevo sonido para el clic del rat�n
    public AudioClip victorySound; // Sonido de victoria
    public AudioClip defeatSound; // Sonido de derrota
    private static List<AudioSource> audioSources; // Cambio a est�tico
    private static MasterSound instance; // Referencia est�tica a la instancia

    private void Awake()
    {
        // Verificar si ya existe un objeto MasterSound en la escena
        if (instance != null && instance != this)
        {
            // Si ya existe otro objeto MasterSound, destruir este objeto
            //Destroy(gameObject);
            return;
        }

        // Asignar la instancia
        instance = this;

        // Crear audio sources para cada sonido en la lista y configurarlos para bucle
        audioSources = new List<AudioSource>();
        foreach (AudioClip sound in loopedSounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            source.loop = true;
            source.playOnAwake = false; // Desactivar la reproducci�n autom�tica al inicio
            audioSources.Add(source);
        }

        // A�adir audio source para el sonido del clic del rat�n
        AudioSource mouseClickSource = gameObject.AddComponent<AudioSource>();
        mouseClickSource.clip = mouseClickSound;
        mouseClickSource.playOnAwake = false;
        audioSources.Add(mouseClickSource);

        // A�adir audio source para el sonido de victoria
        AudioSource victorySource = gameObject.AddComponent<AudioSource>();
        victorySource.clip = victorySound;
        victorySource.playOnAwake = false;
        audioSources.Add(victorySource);

        // A�adir audio source para el sonido de derrota
        AudioSource defeatSource = gameObject.AddComponent<AudioSource>();
        defeatSource.clip = defeatSound;
        defeatSource.playOnAwake = false;
        audioSources.Add(defeatSource);

        // No destruir este objeto al cargar una nueva escena
        //DontDestroyOnLoad(gameObject);
    }

    public static void PlayTwo()
    {
        if (audioSources != null && audioSources.Count >= 2)
        {
            audioSources[0].Play();
            audioSources[1].Play();
        }
    }

    public static void UpVolumenValue()
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = 1f;
        }
        Debug.Log("Subio");
    }

    public static void StopAllSounds()
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = 0f;
        }
       // Debug.Log("se bajo");
    }

    // M�todo para reproducir el sonido de victoria
    public static void PlayVictorySound()
    {
        if (instance != null && instance.loopedSounds != null && audioSources.Count > instance.loopedSounds.Count + 1)
        {
            audioSources[instance.loopedSounds.Count + 1].Play();
        }
    }
    public void PlayMouseClickSound()
    {
        // Verificar si hay audio sources disponibles
        if (audioSources != null && audioSources.Count > loopedSounds.Count)
        {
            // Reproducir el sonido del clic del rat�n, que est� en la posici�n inmediatamente despu�s de los sonidos en bucle
            audioSources[loopedSounds.Count].Play();
        }
        else
        {
            Debug.LogWarning("No se encontr� el sonido del clic del rat�n en la lista de audio sources.");
        }
    }
    public static void PlayDefeatSound()
    {
        if (instance != null && instance.loopedSounds != null && audioSources.Count > instance.loopedSounds.Count + 1)
        {
            audioSources[instance.loopedSounds.Count + 2].Play();
        }
    }
}

