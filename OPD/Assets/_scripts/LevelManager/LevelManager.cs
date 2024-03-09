using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Level_SO _level_so;
    [SerializeField] private Button[] buttons;

    public void UnlockLevels()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }

        for (int i = _level_so.LevelUnlock; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public void ExitGame()
    {
        Debug.Log(1);
        Application.Quit();
    }

}
