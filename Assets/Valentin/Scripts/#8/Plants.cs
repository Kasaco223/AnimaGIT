using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int counter;
    [SerializeField] bool inside;
    [SerializeField] float dif;

    [SerializeField] private Material opacity;
    [SerializeField] private float transparency = 0f;
    [SerializeField] public static bool planted;

    private AudioSource audioSource;

    [SerializeField] private AudioClip SFXCorrect;

    void Start()
    {
        inside = false;

        opacity = GetComponent<Renderer>().material;
        planted = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        dif = PlantsGenerator.difficulty;
        switch (dif)
        {
            case 0:
                speed = Random.Range(3, 4);
                transform.position += -transform.right * speed * Time.deltaTime;
                break;
            case 1:
                speed = Random.Range(4, 5);
                transform.position += -transform.right * speed * Time.deltaTime;
                break;
            case 2:
                speed = Random.Range(5, 6);
                transform.position += -transform.right * speed * Time.deltaTime;
                break;
            case 5:
                transform.position += -transform.right * speed * Time.deltaTime;
                break;
        }

        if (counter == 2)
            inside = true;
        else
            inside = false;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inside)
            {
                planted = true;

                audioSource.PlayOneShot(SFXCorrect);

                GameObject.Find("ActionZone").GetComponent<Rythmn>().score++;
                GameObject.Find("ActionZone").GetComponent<Rythmn>().text.text = "Score: " +
                GameObject.Find("ActionZone").GetComponent<Rythmn>().score.ToString();

                Destroy(gameObject, 2.01f);
                Debug.Log(gameObject.tag);
            }
        }

        if (planted)
        {
            transparency = Mathf.Clamp(0f, 0f, 1f);
            Color newColor = opacity.color;
            newColor.a = transparency;
            opacity.color = newColor;

            if (gameObject.tag == "Note")
                gameObject.tag = "NotePlayed";
        }

        planted = false;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            counter++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            counter--;
    }
}
