using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public void RestartButtonClick()
    {
        Debug.Log("재시작");
        SceneManager.LoadScene("ddd");
    }

    public void GameOverButtonClick()
    {
        Debug.Log("종료");

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


}
