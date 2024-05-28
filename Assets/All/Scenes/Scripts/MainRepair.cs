using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRepair : MonoBehaviour
{
    private static bool hasStarted = false;

    void Start()
    {
        if (!hasStarted)
        {
            SceneManager.LoadScene("Start");
            hasStarted = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
