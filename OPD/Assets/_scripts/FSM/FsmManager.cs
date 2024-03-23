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

    public static Fsm Fsm { get; private set; }

    private void Awake()
    {
        Fsm = new Fsm();

        Fsm.AddState("StartMenu", state_startMenu);
        Fsm.AddState("PrepareStage", state_prepareStage);
        Fsm.AddState("AttackStage", state_attackStage);
        Fsm.AddState("ResultMenu", state_resultMenu);

        Fsm.Initialize("StartMenu");
    }

    public void SetGameState(string stateName)
    {
        Fsm.SetState(stateName);
    }
}
