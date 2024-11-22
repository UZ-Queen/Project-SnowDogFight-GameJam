using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject scoreStart;
    [SerializeField] Canvas canvas1;
    [SerializeField] Canvas canvas2;
    [SerializeField] Text scoreText;

    Transform scoreEnd;
    float distance;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            Debug.Log("������");
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
