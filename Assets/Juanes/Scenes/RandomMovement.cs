using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float horizontalSpeed = 40f; // Aumenta la velocidad en el eje X
    public float laneOffset = 5f;
    public Rigidbody rb;
    private DodgeController playerController;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<DodgeController>();
        StartMoving();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);
            float speedX = horizontalSpeed; // Velocidad en el eje X constante

            rb.velocity = new Vector3(speedX, moveDirection.y * horizontalSpeed, moveDirection.z * horizontalSpeed);

            if (distance < 0.1f)
            {
                isMoving = false;
                rb.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator ChangeLanePeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            MoveRandomLane();
        }
    }

    void MoveRandomLane()
    {
        Debug.Log("Moviendo a carril aleatorio");
        int randomLane = Random.Range(0, 4);
        float targetY = (randomLane - 1) * laneOffset;
        bool isPlayerChangingLane = playerController.IsChangingLane();

        if (!isPlayerChangingLane)
        {
            targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            isMoving = true;
        }
    }

    public void StartMoving()
    {
        StartCoroutine(ChangeLanePeriodically());
    }

    public void StopMoving()
    {
        StopAllCoroutines();
        rb.velocity = Vector3.zero;
    }
}
