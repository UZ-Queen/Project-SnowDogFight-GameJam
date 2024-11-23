using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float maxHp = 100f;
    public float currentHp;
    void Start()
    {
        currentHp = maxHp;
    }

    public void OnDamaged()
    {
        currentHp -= 10f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.SnowBall))
        {
            OnDamaged();
        }
    }
}
