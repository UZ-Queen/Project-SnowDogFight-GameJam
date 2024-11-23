using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?¨Í∏∞??
/// </summary>
public class Slope : MonoBehaviour
{
    public Action OnJumpEnds = ()=>{};
    
    // [SerializeField] private Collider2D gettingOnStart;
    // [SerializeField] private Collider2D gettingOnEnd;

    // [SerializeField] private Collider2D jumpingOnStart;

    // [SerializeField] private Collider2D jumpingOnEnd;

    [SerializeField] private Collider2D gettingOnArea;
    [SerializeField] private Collider2D jumpingArea;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float slopeMoveSpeed = 5f;
    [SerializeField] private float maxBoostAmount;

    public bool isControllable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.MovePosition(player.position + Vector2.right * slopeMoveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Ï¢Ä ?îÎü¨?¥Îç∞..
        if(other == gettingOnArea){

            return;
        }
        else if(other == jumpingArea){
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other == gettingOnArea){
            
            return;
        }
        else if(other == jumpingArea){
            OnJumpEnds();
            gameObject.SetActive(false);
            return;
        }
    }


}
