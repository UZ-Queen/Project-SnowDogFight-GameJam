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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.MovePosition(player.position + Vector2.right * slopeMoveSpeed*Time.deltaTime);
    }



}
