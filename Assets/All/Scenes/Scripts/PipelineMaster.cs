using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipelineMaster : MonoBehaviour
{
     public static int correct = 0;

    private void Update()
    {
        //Debug.Log(correct); 
        if (correct == 14)
        {
           
            LevelMaster2.lvl6 = true;
            MasterSound.PlayVictorySound();
            SceneManager.LoadScene("Win");
            correct = 0;
        }
     
    }

}
