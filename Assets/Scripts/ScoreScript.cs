using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public Text changingText;
    public GameObject button1;

    public bool gameStart = false;

    public void TextChanger ()
    {
        changingText.text = "";
        button1.SetActive(false);
        gameStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
