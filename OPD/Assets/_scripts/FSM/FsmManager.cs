using UnityEngine;

public class FsmManager : MonoBehaviour
{
    [SerializeField]
    private FsmState_StartMenu state_startMenu;
    [SerializeField]
    private FsmState_PrepareStage state_prepareStage;
    [SerializeField]
    private FsmState_AttackStage state_attackStage;
    [SerializeField]
    private FsmState_ResultMenu state_resultMenu;

    private Fsm fsm;

    private void Awake()
    {
        fsm = new Fsm();

        fsm.AddState("StartMenu", state_startMenu);
        fsm.AddState("PrepareStage", state_prepareStage);
        fsm.AddState("AttackStage", state_attackStage);
        fsm.AddState("ResultMenu", state_resultMenu);

        fsm.Initialize("StartMenu");
    }

    public void SetGameState(string stateName)
    {
        fsm.SetState(stateName);
    }
}
