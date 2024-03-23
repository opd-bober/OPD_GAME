using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState_ResultMenu : MonoBehaviour, FsmState
{
    public void Enter()
    {
        Debug.Log("ResultMenu_Enter");
    }

    public void Exit()
    {
        Debug.Log("ResultMenu_Exit");
    }
}
