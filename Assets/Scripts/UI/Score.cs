using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public void RestartButtonClick()
    {
        Debug.Log("�����");
        SceneManager.LoadScene("ddd");
    }

    public void GameOverButtonClick()
    {
        Debug.Log("����");

        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GameStartButtonClick()
    {
        Debug.Log("���ӽ���");
        SceneManager.LoadScene("ddd");
    }
}
