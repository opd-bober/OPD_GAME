
using UnityEngine;

public class FsmState_StartMenu : MonoBehaviour, FsmState
{
    [SerializeField]
    private GameObject menu;

    public void Enter()
    {
        Debug.Log("StartMenu_Enter");
        
    }

    public void Exit()
    {
        Debug.Log("StartMenu_Exit");
    }
}
