using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject scoreStart;
    [SerializeField] Canvas canvas;
    [SerializeField] Text scoreText;

    Transform scoreEnd;
    float distance;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            Debug.Log("´«´êÀ½");
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.SetActive(false);

            distance = Vector3.Magnitude(collision.gameObject.transform.position - scoreStart.transform.position);

            Debug.Log(collision.gameObject.transform.position.x);
            canvas.gameObject.SetActive(true);
            scoreText.text = collision.gameObject.transform.position.x.ToString();
        }

    }
}
