using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class Person2 : MonoBehaviour
{
    SnowBall snowBall;
    bool isGotOnTheSnowBall = false;

    public float rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(InputManager.Interaction)){
            GetOn();
        }
    }

    void GetOn(){
        if(isGotOnTheSnowBall) return;
        isGotOnTheSnowBall = true;


    }

    void SetPositionToTarget(){
        // transform.position = 
    }

    void Tilt(){
        if(!isGotOnTheSnowBall) return;


        transform.RotateAround(snowBall.transform.position, Vector3.forward * InputManager.Horizontal, rotateSpeed*Time.deltaTime);
    }
}
