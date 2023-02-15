using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject background;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject leaders;
    [SerializeField] GameObject settings;

    [Space(10)]
    [SerializeField] GameObject pause;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;

    private void Start()
    {
        OpenMenu();
    }

    public void OpenLeaders(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        leaders.SetActive(IsOpen);
    }

    public void OpenSettings(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        settings.SetActive(IsOpen);
    }

    public void OpenGame()
    {
        background.SetActive(false);

        menu.SetActive(false);
        game.SetActive(true);
    }

    public void OpenMenu()
    {
        background.SetActive(true);

        game.SetActive(false);
        pause.SetActive(false);

        menu.SetActive(true);
    }

    public void SetPause(bool IsPause)
    {
        pause.SetActive(IsPause);
    }
}
