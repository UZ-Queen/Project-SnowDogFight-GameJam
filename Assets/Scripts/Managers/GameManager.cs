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
            Debug.Log($"{instance.name} : 하늘 아래 두 개의 태양은 있을 수 없는 법..");
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
