using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator ani;

    public void shake()
    {
        ani.SetTrigger("shake");
    }
    
}
