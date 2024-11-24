using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?ÔøΩÍ∏∞??
/// </summary>
public class Slope : MonoBehaviour
{
    public Action OnJumpEnds = ()=>{};

    [SerializeField] private bool isLeftSide = true;
    [SerializeField] private MoveAlongEdgeCollider mover;
    [SerializeField] private Person person;
    [SerializeField] private SnowBall snowBall;

    [SerializeField] private TimingBoostArea gettingOnArea;
    [SerializeField] private TimingBoostArea jumpingArea;


    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float slopeMoveSpeed = 5f;
    [SerializeField] private float maxBoostAmount = 20f;

    public float snowSizeBonus = 0f;
    // public float snowSpeedBonus = 0f;

    public bool hasStartedRunning = false;


    void Awake(){
        gettingOnArea.OnBoostComplete+=OnPlayerGetOnSnow;
        jumpingArea.OnBoostComplete+= OnPlayerJumpOffTheSlope;
    }

    void Update(){
        if(!hasStartedRunning && Input.GetKeyDown(KeyCode.RightArrow)){
            StartRunning();
        }
    }

    void StartRunning(){
        Debug.Log("?ÄÏßÅÏù¥Í∏∞Î? ?úÏûë??");
        hasStartedRunning = true;
        // mover.enabled = true;
        snowBall.ForciblyMove(isLeftSide);
    }


    void OnPlayerGetOnSnow(float boostPercent){
        float snowSpeedBonus = BoostPercentBonus(boostPercent)*maxBoostAmount;

        Debug.Log($"{snowSpeedBonus}ÎßåÌÅº ?çÎèÑÎ•??òÎ¶¥Í≤åÏöî!");
        
        // snowBall.EnableAirControl();
        person.GetComponentInParent<FriendsTillTheEnd>().enabled= false;
        person.ToggleRiding();
        snowBall.AdjustSpeed(snowSpeedBonus/10, 1f);

        // mover.AdjustSpeed(snowSpeedBonus);
        // mover.enabled = false;

    }

    void OnPlayerJumpOffTheSlope(float boostPercent){

        float snowSizeBonus = BoostPercentBonus(boostPercent) / 25 * maxBoostAmount;
        float snowSpeedBonus = BoostPercentBonus(boostPercent) / 3 *maxBoostAmount;
        Debug.Log($"{snowSpeedBonus}ÎßåÌÅº ?çÎèÑÎ•??òÎ¶¥Í≤åÏöî!");
        Debug.Log($"{snowSizeBonus}ÎßåÌÅº ?¨Í∏∞Î•??òÎ¶¥Í≤åÏöî!");


        // snowBall.EnableAirControl();
        // mover.AdjustSpeed(snowSpeedBonus);
        // mover.enabled = false;

        // snowBall.SetVelocity(new Vector2(1f, 0f).normalized  * mover.speed * 3 * (isLeftSide ? 1 : -1));
        // snowBall.GrowImmidiate(snowSizeBonus);
        // Invoke(mover.)
    }

    float BoostPercentBonus(float boostPercent){
        float bonusPercent = 0f;
        if(boostPercent > 0.95f){
            bonusPercent = 1f;
        }
        else if(boostPercent > 0.9f){
            bonusPercent = 0.5f;
        }
        if(bonusPercent < 0f)
            bonusPercent = 0f;
        // else if(boostPercent)

        return bonusPercent + boostPercent;
    }

    // public void AddSnowSize(float size){
    //     snowSizeBonus+= size;
    // }

    // public void AddSnowSpeed(float speedAmount){
    //     snowSpeedBonus += speedAmount;
    // }



}
