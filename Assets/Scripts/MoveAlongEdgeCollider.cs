using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAlongEdgeCollider : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D c;
    Vector2[] points;
    int currentIndex;
    public float speed {get;private set;} = 5f;
    public Vector2 offset = Vector2.up;

    private void Awake()
    {
        if (c == null)
        {

        }
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        points = c.points;
        currentIndex = 0;
        // foreach(Vector2 point in points){}
        for(int i=0;i<points.Length; i++){
            points[i] = c.transform.TransformPoint(points[i] + offset);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.P)){
        //     StartCoroutine(MoveAlongLine());
        // }
        MoveAlongLineNotCoroutine();
        
    }

    IEnumerator MoveAlongLine(){
        
        while(currentIndex < points.Length - 1){
            float percent = 0;
            while(percent < 1){
                percent+= Time.deltaTime*speed;
                transform.position= Vector2.Lerp(points[currentIndex], points[currentIndex+1], percent);
                yield return null;
            }
            currentIndex++;
        }


        
    }

    void MoveAlongLineNotCoroutine(){
        if(currentIndex >= points.Length - 1){
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, points[currentIndex+1], speed*Time.deltaTime );
        if(Vector2.SqrMagnitude(-(Vector2)transform.position + points[currentIndex+1]) < 0.1f){
            currentIndex++;
        }
    }



    public void AdjustSpeed(float amount){
        speed+= amount;
    }

}
