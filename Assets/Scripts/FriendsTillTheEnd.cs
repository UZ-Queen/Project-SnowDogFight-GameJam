using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendsTillTheEnd : MonoBehaviour
{
    [SerializeField] private Transform target;

    Vector2 offset;

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + (Vector3)offset;
    }


    public void RecalculatePosition(){
        offset = target.position - transform.position;


    }
}
