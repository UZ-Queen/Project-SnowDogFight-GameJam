using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Rigidbody2D))]
public class SnowBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float growRate = 0.005f;

    [SerializeField] private bool isControllable = true;

    // [SerializeField] private Transform ;

    // public void SetControllablity(bool state){
    //     isControllable = state;
    // }
    // public void SetControllablity(){
    //     isControllable^=true;
    // }

    Vector2 force = Vector2.zero;
    Rigidbody2D rb;
    private bool isGround;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        rb.isKinematic = true;
        isControllable = false;
    }

    public void SetForce(float horizontal)
    {
        force = Vector2.right * horizontal * moveSpeed;
    }
    public void AjdustVelocity(float velocity){
        moveSpeed += velocity;
        
    }

    public void EnableAirControl(){
        isControllable = true;
        rb.isKinematic = false;
    }



    void FixedUpdate()
    {
        if(isControllable)
            Move();
        ClampVelocity();
    }

    void Update(){
        if (isGround)
            Grow();
    }


    void Move()
    {
        SetForce(InputManager.Horizontal);
        rb.AddForce(force, ForceMode2D.Force);
    }

    void ClampVelocity()
    {
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);


        else if (rb.velocity.x < maxSpeed * (-1))
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);
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
        transform.localScale += Vector3.one * growRate * Time.deltaTime;
    }
}