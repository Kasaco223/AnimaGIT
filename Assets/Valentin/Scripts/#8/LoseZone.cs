using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            audioSource.Play();
            Debug.Log("Reproducir sonido de error");

            GameObject.Find("ActionZone").GetComponent<Rythmn>().score--;
            GameObject.Find("ActionZone").GetComponent<Rythmn>().text.text = "Score: " +
            GameObject.Find("ActionZone").GetComponent<Rythmn>().score.ToString();

            Destroy(collision.gameObject);
        }
    }
}
