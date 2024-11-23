using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TimingBoostArea : MonoBehaviour
{
    public System.Action<float> OnBoostComplete;


    [SerializeField] private int maxBoostValue;

    [SerializeField] private bool isRidingBoost = false;
    [SerializeField] private bool isSpeedBoost = false;
    [SerializeField] private bool isSizeBoost = false;
    Slope slope;

    Collider2D c;


    float startX = 0;
    float endX = 0;

    void Awake(){
        c = GetComponent<Collider2D>();
    }

    bool hasAppliedBoost = false;
    bool isBoostable = false;
    // void Update(){
    //     if(isBoostable && Input.GetKeyDown(InputManager.Interaction)){
    //         CalculateBoostAmount();
    //     }
    // }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == TagManager.Snow){
            isBoostable = true;
            // startX = other.transform.position.x;
            // startX += other.bounds.size.x/2 * other.transform.position.x < transform.position.x ? 1 : -1;

        }   
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(!isBoostable) return;
        if(other.tag != TagManager.Snow) return;

        if(Input.GetKeyDown(InputManager.Interaction)){
            CalculateBoostAmount(other.transform.position.x, other.transform);
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(!isBoostable) return;
        if(other.tag != TagManager.Snow) return;
        // if(other.tag == TagManager.Snow && isBoostable){
        // }
        CalculateBoostAmount(0, other.transform);
    }


    void CalculateBoostAmount(float xPosition, Transform boostableObj)
    {
        isBoostable = false;

        
        float value = Mathf.Abs(transform.position.x - xPosition);
        float boostValue = Mathf.Lerp(maxBoostValue, 0, value/(transform.position.x/2) );
        Debug.Log($"부스트 완벽도는? {value/(transform.position.x/2)}(0일수록 완벽합니다!)");
        // OnBoostComplete(boostValue);
        boostableObj.GetComponent<SnowBall>();
    }

}
