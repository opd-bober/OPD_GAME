
using UnityEngine;

public class FsmState_PrepareStage : MonoBehaviour, FsmState
{
    
    public void Enter()
    {
        Debug.Log("PrepareStage_Enter");
        
    }

    public void Exit()
    {
        Debug.Log("PrepareStage_Exit");
    }
}
