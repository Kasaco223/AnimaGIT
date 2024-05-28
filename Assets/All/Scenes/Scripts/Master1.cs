using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master1 : MonoBehaviour
{

    private void Update() {
        // Obtener todos los objetos con el tag "DragParent" en la escena
        GameObject[] dragParentObjects = GameObject.FindGameObjectsWithTag("DragParent");
        // Contar cuántos objetos se encontraron
        int count = dragParentObjects.Length;
       // Debug.Log("Número de objetos con el tag 'DragParent': " + count);
        if(count == 1)
        {
           LevelMaster2.lvl1 = true;
           MasterSound.PlayVictorySound();
           SceneManager.LoadScene("Win");
        }
    }
}
