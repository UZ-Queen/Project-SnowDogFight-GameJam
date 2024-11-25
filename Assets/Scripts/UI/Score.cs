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
        SceneManager.LoadScene("AddCommandSystem");
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
        SceneManager.LoadScene("AddCommandSystem");
    }
    public void MainMenuButtonClick()
    {
        Debug.Log("���θ޴�");
        SceneManager.LoadScene("GameStart");
    }
    public void HelpButtonClick()
    {
        Debug.Log("����");
        SceneManager.LoadScene("Help");
    }
}
