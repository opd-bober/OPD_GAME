using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState_AttackStage : MonoBehaviour, FsmState
{
    [SerializeField]
    private GameObject _test_menu;

    public void Enter()
    {
        _test_menu.SetActive(true);

        Debug.Log("AttackStage_Enter");
    }

    public void Exit()
    {
        _test_menu.SetActive(false);

        Debug.Log("AttackStage_Exit");
    }
}
