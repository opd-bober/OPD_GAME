
using UnityEngine;

public class FsmState_StartMenu : MonoBehaviour, FsmState
{
    [SerializeField]
    private GameObject menu;

    public void Enter()
    {
        menu.SetActive(true);

        Debug.Log("StartMenu_Enter");
    }

    public void Exit()
    {
        menu.SetActive(false);

        Debug.Log("StartMenu_Exit");
    }
}
