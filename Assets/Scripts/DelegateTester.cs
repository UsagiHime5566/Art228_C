using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTester : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            SignalAdapter.FakeInvoke(4);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            SignalAdapter.FakeInvoke(3);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            SignalAdapter.FakeInvoke(2);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            SignalAdapter.FakeInvoke(1);
        }
    }
}
