using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Referencia al Animator
    private Animator animator;

    private void Start()
    {
        // Obtener el componente Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verificar si la animación "ZoomOut" se está reproduciendo en el primer layer
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ZoomOut"))
        {
            //Destruir el objeto padre
            Destroy(transform.parent.gameObject);

            // Destruir el objeto actual
            Destroy(gameObject);
        }
    }
}
