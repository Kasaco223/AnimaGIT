using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Rythmn : MonoBehaviour
{
    public int score;
    static public int staticScore;
    public TextMeshProUGUI text;

    void Start()
    {
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        staticScore = score;
    }
}
