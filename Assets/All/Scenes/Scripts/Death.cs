using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeathObj",1f);
    }

    // Update is called once per frame
    private void DeathObj()
    {
        Destroy(gameObject);
    }
}
