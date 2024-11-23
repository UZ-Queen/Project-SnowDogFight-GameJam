using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 여기서 
/// </summary>
public class Slope : MonoBehaviour
{
    public Action OnJumpEnds = ()=>{};

    [SerializeField] private Collider2D gettingOnArea;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float slopeMoveSpeed = 5f;
    [SerializeField] private float maxBoostAmount;

    public float snowSizeBonus = 0f;
    public float snowSpeedBonus = 0f;

    public bool isControllable;


    public void AddSnowSize(float size){
        snowSizeBonus+= size;
    }

    public void AddSnowSpeed(float speedAmount){
        snowSpeedBonus += speedAmount;
    }



}
