using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RePack : MonoBehaviour
{
    public void RePackButton()
    {
        Debug.Log("Button Pressed - RePack");
        AudioManager.Instance.PlaySFX("ResetButtonAudio");
        SceneManager.LoadScene(0);

    }

    public void ExitButton()
    {
        Debug.Log("Game Closed");
        AudioManager.Instance.PlaySFX("ExitButtonAudio");
        Application.Quit();
    }

}
