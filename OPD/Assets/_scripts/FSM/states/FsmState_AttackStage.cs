using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState_AttackStage : MonoBehaviour, FsmState
{
    public void Enter()
    {
        Debug.Log("AttackStage_Enter");
    }

    public void Exit()
    {
        Debug.Log("AttackStage_Exit");
    }
}
