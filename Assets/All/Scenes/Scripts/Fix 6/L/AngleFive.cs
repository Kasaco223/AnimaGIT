using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleFive : MonoBehaviour
{
    private bool correctAngle = false;

    private void Update()
    {
        // Obt�n el �ngulo Z actual del objeto
        float currentAngleZ = transform.eulerAngles.z;
       // Debug.Log(currentAngleZ);

        // Si el �ngulo cambi� y no se ha registrado a�n, actualiza el contador
        {
            if (currentAngleZ == 0f)
            {
                //Debug.Log("es igual a 360");
                SendPlus();
            }
            else
            {
                // Resta 1 a "correct" si el �ngulo es diferente de 0 o 180 grados
                SendLess();
            }
        }
    }
    private void SendPlus()
    {
        if (!correctAngle)
        {
            PipelineMaster.correct += 1;
            correctAngle = true;
        }
    }
    private void SendLess()
    {
        if (correctAngle)
        {
            PipelineMaster.correct -= 1;
            correctAngle = false;

        }
    }

}