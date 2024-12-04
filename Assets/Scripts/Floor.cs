using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    public static Floor instance {  get; private set; }
    [SerializeField] GameObject scoreStart;
    [SerializeField] Canvas canvas1;
    [SerializeField] Canvas canvas2;
    [SerializeField] Canvas Spacebar;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Text scoreText;

    public bool isPause = false;
    Transform scoreEnd;
    float distance = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(instance);
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        canvas1.gameObject.SetActive(true);
        scoreText.text = distance.ToString();
        canvas2.gameObject.SetActive(false);
    }


    void Update()
    {
        if (!isPause)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spacebar.gameObject.SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPause = !isPause;
        pauseCanvas.gameObject.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            Debug.Log("´«´êÀ½");
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.SetActive(false);

            distance = Vector3.Magnitude(collision.gameObject.transform.position - scoreStart.transform.position);

            Debug.Log(collision.gameObject.transform.position.x);
            canvas1.gameObject.SetActive(true);
            scoreText.text = distance.ToString();
            canvas2.gameObject.SetActive(false);
        }
    }
}
