using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 2f; // Puedes ajustar este valor según tus necesidades
    private Rigidbody rb;
    private float altura = -3f; // Altura inicial

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correcto;
    [SerializeField] private AudioClip incorrecto;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(velocidad, 0, 0);
        rb.MovePosition(rb.position + movimiento * Time.fixedDeltaTime);

        // Cambiar la altura con las teclas 'w' y 's'
        if (Input.GetKey(KeyCode.W))
        {
            altura = 3f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            altura = -3f;
        }

        // Asegurarse de que el objeto esté siempre a la altura correcta
        Vector3 posicion = rb.position;
        posicion.y = altura;
        rb.MovePosition(posicion);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Junk(Clone)")
            audioSource.PlayOneShot(incorrecto);
        if (other.gameObject.name == "Recycle(Clone)")
            audioSource.PlayOneShot(correcto);
    }
}