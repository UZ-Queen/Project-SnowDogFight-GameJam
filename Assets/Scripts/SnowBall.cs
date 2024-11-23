using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnowBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float growRate = 0.005f;

    [SerializeField] private bool isControllable = true;

    public void SetControllablity(bool state){
        isControllable = state;
    }
    public void SetControllablity(){
        isControllable^=true;
    }

    Vector2 force = Vector2.zero;
    Rigidbody2D rigid;
    private bool isGround;




    public void SetForce(float horizontal)
    {
        force = Vector2.right * horizontal * moveSpeed;
    }



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        FindObjectOfType<Slope>().OnJumpEnds += SetControllablity;

    }

    void FixedUpdate()
    {
        if(isControllable)
            Move();
        ClampVelocity();
        if (isGround)
            Grow();
    }



    void Move()
    {
        SetForce(InputManager.Horizontal);
        rigid.AddForce(force, ForceMode2D.Force);
        
        
    }

    void ClampVelocity()
    {
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);


        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.Ground))
        {
            isGround = true;
        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.Ground))
        {
            isGround = false;
        }
    }

    void Grow()
    {
        transform.localScale += Vector3.one * rigid.velocity.magnitude * growRate;
    }
}