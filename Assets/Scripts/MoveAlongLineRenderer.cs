using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongLineRenderer : MonoBehaviour
{
    LineRenderer lr;
    Vector2[] pathPoints;



    private void Awake() {
        if(lr == null){
            Debug.LogError("?�인?�더?��? ?�당??주세??");
            gameObject.SetActive(false);
        }    
    }
    // Start is called before the first frame update
    void Start()
    {
        // pathPoints = lr.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
