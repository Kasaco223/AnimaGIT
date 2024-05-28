using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdController : MonoBehaviour
{
    public float jumpForce = 200f; // Fuerza del impulso
    public float horizontalSpeed = 2f;
    public Rigidbody rb;
    private int points = 0;
    MasterSound masterSound;
    public AudioSource audioSource;
    public AudioClip MovimientoAnimal;
    public AudioClip puntaje;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        masterSound = FindObjectOfType<MasterSound>();
    }

    void Update()
    {
       
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(MovimientoAnimal);
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.right * horizontalSpeed * Time.deltaTime);
        
        rb.AddForce(Vector3.down * Time.deltaTime * 500f);
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           
            Debug.Log("Game Over");
            MasterSound.PlayDefeatSound();
            SceneManager.LoadScene("Lose");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            points++; // Incrementa el contador de puntos
            audioSource.PlayOneShot(puntaje);

            Debug.Log("Puntos: " + points);
            if(points >= 10)
            {
                
                LevelMaster2.lvl3 = true;
                MasterSound.PlayVictorySound();
                SceneManager.LoadScene("Win");
            }
        }
    }
}