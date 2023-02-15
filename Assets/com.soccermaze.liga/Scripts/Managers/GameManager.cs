using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject leaders;
    [SerializeField] GameObject settings;

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
}
