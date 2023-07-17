using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RePack : MonoBehaviour
{
    public void RePackButton()
    {
        Debug.Log("Button Pressed - RePack");
        SceneManager.LoadScene(1);

    }

    public void ExitButton()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }

}
