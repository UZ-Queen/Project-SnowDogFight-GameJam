using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Castle castle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            castle.OnDamaged();
        }
    }
}