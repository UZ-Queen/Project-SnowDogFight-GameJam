using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager
{
    public static KeyCode Interaction{get{return KeyCode.Space;}}
    // public static KeyCode 
    // public static float RotateClockwise{get{return Input.GetAxisRaw("Horizontal")}}
    public static float Horizontal{get{return Input.GetAxisRaw("Horizontal");}}

}
