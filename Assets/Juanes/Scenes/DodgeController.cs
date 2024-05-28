using System.Collections;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public float jumpForce = 200f;
    public float horizontalSpeed = 2f;
    public float verticalMovementAmount = 10f;
    public float laneOffset = 5f;
    public int currentLane = 1;
    public Rigidbody rb;
    private bool isChangingLane = false;
    private RandomMovement randomMovement;



    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomMovement = FindObjectOfType<RandomMovement>();
    }

    void Update()
    {
        if (!isMoving) 
        {
            if (Input.GetKeyDown(KeyCode.W) && currentLane < 2)
            {
                Debug.Log("Cambiando a carril superior.");
                MoveToLane(currentLane + 1);
            }
            else if (Input.GetKeyDown(KeyCode.S) && currentLane > 0)
            {
                Debug.Log("Cambiando a carril inferior.");
                MoveToLane(currentLane - 1);
            }
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.right * horizontalSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }
    }

    void MoveToLane(int lane)
    {
        Debug.Log("Moviendo a carril " + lane);

        float targetY = (lane - 1) * laneOffset;
        targetPosition = new Vector3(rb.position.x, targetY, rb.position.z);
        StartCoroutine(SmoothMoveToLane());
        randomMovement.StopMoving();
    }
    IEnumerator SmoothMoveToLane()
    {
        Debug.Log("Iniciando movimiento suave a " + targetPosition);
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        float duration = 0.5f;
        //float targetY = (currentLane - 1) * laneOffset;
        //Vector3 targetPosition = new Vector3(rb.position.x, targetY, rb.position.z);


        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        transform.position = targetPosition;
        isMoving = false;
        Debug.Log("Movimiento suave completado.");

        currentLane = Mathf.RoundToInt((targetPosition.y / laneOffset) + 1);
        Debug.Log("Carril actual: " + currentLane);

        randomMovement.StartMoving();
    }
    public bool IsChangingLane()
    {
        return isChangingLane;
    }
    public void SetChangingLane(bool isChanging)
    {
        isChangingLane = isChanging;
    }
}
