using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TimingBoostArea : MonoBehaviour
{
    public System.Action<float> OnBoostComplete;

    Collider2D c;
    Collider2D targetCollider;

    float startX = 0;
    float endX = 0;

    void Awake()
    {
        c = GetComponent<Collider2D>();
    }

    void Update(){
        if(isBoostable){
            if (Input.GetKeyDown(InputManager.Interaction)){
                CalculateBoostAmount(targetCollider.transform.position.x);
            }
        }
    }

    bool hasAppliedBoost = false;
    bool isBoostable = false;
    // void Update(){
    //     if(isBoostable && Input.GetKeyDown(InputManager.Interaction)){
    //         CalculateBoostAmount();
    //     }
    // }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagManager.Snow)
        {
            isBoostable = true;
            Debug.Log("?´ì œ ë¶€?¤íŠ¸ ê°€?¥í•´??");
            targetCollider = other;
            // startX = other.transform.position.x;
            // startX += other.bounds.size.x/2 * other.transform.position.x < transform.position.x ? 1 : -1;

        }
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (!isBoostable) return;
    //     if (other.tag != TagManager.Snow) return;

    //     if (Input.GetKeyDown(InputManager.Interaction))
    //     {
    //         CalculateBoostAmount(other.transform.position.x);
    //     }

    // }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isBoostable) return;
        if (other.tag != TagManager.Snow) return;
        // if(other.tag == TagManager.Snow && isBoostable){
        // }
        // CalculateBoostAmount(0, other.transform);
        CalculateBoostAmount(other.transform.position.x);

    }


    void CalculateBoostAmount(float xPosition, Transform boostableObj)
    {

        isBoostable = false;


        float value = Mathf.Abs(transform.position.x - xPosition);
        // float boostValue = Mathf.Lerp(maxBoostValue, 0, value / (transform.position.x / 2));
        Debug.Log($"ë¶€?¤íŠ¸ ?„ë²½?„ëŠ”? {value / (transform.position.x / 2)}(0?¼ìˆ˜ë¡??„ë²½?©ë‹ˆ??)");
        // OnBoostComplete(boostValue);
        //?¸í„°?˜ì´??......

    }

    void CalculateBoostAmount(float xPosition)
    {
        isBoostable = false;
        targetCollider = null;
        float value = Mathf.Abs(transform.position.x - xPosition);
        float boostPercent = 1 - value / (c.bounds.size.x/ 2);
        Debug.Log($"ë¶€?¤íŠ¸ ?„ë²½?„ëŠ”? {value / (c.bounds.size.x/ 2)}(0?¼ìˆ˜ë¡??„ë²½?©ë‹ˆ??)");
        // OnBoostComplete(boostValue);
        //?¸í„°?˜ì´??......
        OnBoostComplete(boostPercent);
        gameObject.SetActive(false);
    }

}
