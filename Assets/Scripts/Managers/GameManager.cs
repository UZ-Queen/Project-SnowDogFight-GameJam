using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null){
            Debug.Log($"{instance.name} : ?�늘 ?�래 ??개의 ?�양?� ?�을 ???�는 �?.");
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this);
        }
    }










    // public void SlopeEnd(){
    //     FindObjectOfType<SnowBall>().SetControllablity(true);
    // }


}
