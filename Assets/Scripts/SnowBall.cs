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
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float growRate = 0.005f;
    [SerializeField] Person person;
    [SerializeField] Floor gameManager;

    [SerializeField] private bool isControllable = true;

    // public void SetControllablity(bool state){
    //     isControllable = state;
    // }
    // public void SetControllablity(){
    //     isControllable^=true;
    // }

    public bool autoScroll{get;set;} = false;


    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private bool isLeftSide = true;

    Vector2 Direction{get{
        return isLeftSide ? Vector2.right : Vector2.left;
    }}


    Rigidbody2D rb;
    private bool isGround;
    private bool doSnowballGrow;

    float originGravity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originGravity = rb.gravityScale;
    }
    private void Start() {
        rb.isKinematic = true;
        isControllable = false;
        doSnowballGrow=false;
    }
    void Update(){
        //if(Input.GetKeyDown(KeyCode.RightBracket)){ AdjustSpeed(400,1);}
        //if(Input.GetKeyDown(KeyCode.Return)) {
        //    transform.position = new Vector3(-10, 5, 0);
        //     rb.velocity = Vector2.zero;
        //}
        //if(Input.GetKeyDown(KeyCode.DownArrow)) rb.gravityScale = 10f;
        //if(Input.GetKeyDown(KeyCode.UpArrow)) rb.gravityScale = 1f;
        if (moveSpeed == 0)
        {
            this.gameObject.SetActive(false);
            gameManager.GameOver();
        }
        if (isGround || doSnowballGrow)
            Grow();
    }
    public IEnumerator DecreaseGravityScale()
    {
        rb.gravityScale = 5f;
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = originGravity;
    }

    public IEnumerator IncreaseGravityScale()
    {
        rb.gravityScale = 10f;
        yield return null;
        rb.gravityScale = originGravity;
    }
    void FixedUpdate()
    {
        // if(isControllable)
        //     Move();
        ClampVelocity();
        if(autoScroll) Move();
    }

    public void ForciblyMove(bool isLeft){
        rb.isKinematic ^= true;
        isLeftSide = isLeft;
        autoScroll ^=true;
    }

    //?‘ì? ?¨ìœ„ë¡?ì¡°ì •?˜ì„¸??
    public void AdjustSpeed(float speed, float duration)
    {
        // moveSpeed += speed;
        StartCoroutine(AdjustSpeedSmoothly(speed, duration));
    }

    IEnumerator AdjustSpeedSmoothly(float amount, float duration){
        float percent = 0;
        float speed = 1/duration;
        float originalValue = moveSpeed;
        while(percent <= 1){

            percent+= speed*Time.deltaTime;
            moveSpeed = Mathf.Lerp(originalValue, originalValue+amount, percent);
            if (moveSpeed < 0)
                moveSpeed = 0;
            yield return null;
        }
    }

    public void EnableAirControl(){
        isControllable = true;
        rb.isKinematic = false;
    }

    void Move()
    {
        rb.AddForce(moveSpeed * Direction * 0.02f, ForceMode2D.Impulse);
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

    //ì½”ë£¨?´ì´??ë¦°íŠ¸?ˆìœ¼ë¡??ì§„?ìœ¼ë¡??˜ë¦¬??
    public void GrowImmidiate(float amount){
        transform.localScale += Vector3.one * amount;
    }
    public void SetVelocity(Vector2 velocity){
        rb.velocity = velocity;
    }
}