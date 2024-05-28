using Unity.VisualScripting;
using UnityEngine;

public class Horizontal : MonoBehaviour
{
    private bool correctAngle = false;

    private void Update()
    {
        // Obtén el ángulo Z actual del objeto
        float currentAngleZ = transform.eulerAngles.z;

        // Si el ángulo cambió y no se ha registrado aún, actualiza el contador
        {
            if (currentAngleZ == 90f || currentAngleZ == 270f)
            {

                SendPlus();
            }
            else
            {
                // Resta 1 a "correct" si el ángulo es diferente de 0 o 180 grados
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
