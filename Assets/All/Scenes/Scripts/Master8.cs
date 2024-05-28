using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master8 : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Notes", 1f, 1f);
    }
    private void Notes()
    {
        // Obtener todos los objetos con el tag "DragParent" en la escena
        GameObject[] dragParentObjects = GameObject.FindGameObjectsWithTag("Note");
        // Contar cu�ntos objetos se encontraron
        int count = dragParentObjects.Length;
        // Debug.Log("N�mero de objetos con el tag 'DragParent': " + count);
        if (count == 0 && Rythmn.staticScore > 2)
        {
            LevelMaster2.lvl8 = true;
            // Llama al m�todo PlayVictorySound directamente desde la clase MasterSound
            MasterSound.PlayVictorySound();
            SceneManager.LoadScene("Win");
        }
        else if (count == 0 && Rythmn.staticScore < 2)
        {
            LevelMaster2.lvl8 = false;
            // Llama al m�todo PlayVictorySound directamente desde la clase MasterSound
            MasterSound.PlayDefeatSound();
            SceneManager.LoadScene("Lose");
        }
    }
}
