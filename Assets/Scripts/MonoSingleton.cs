using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
{
    public static T instance;

    void Awake(){
        
    }
}
