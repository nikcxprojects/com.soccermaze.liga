using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject LevelRef { get; set; }
    private GameObject worldElementRef;

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

    [Space(10)]
    [SerializeField] RotateBtn rotateBtn;
    [SerializeField] DeleteBtn deleteBtn;

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

        LevelRef = Instantiate(Resources.Load<GameObject>("level"), GameObject.Find("Environment").transform);
    }

    public void OpenMenu()
    {
        if(LevelRef)
        {
            Destroy(LevelRef);
        }

        background.SetActive(true);

        game.SetActive(false);
        pause.SetActive(false);

        menu.SetActive(true);
    }

    public void SetPause(bool IsPause)
    {
        pause.SetActive(IsPause);
    }

    public void SetWorldElement(GameObject _worldElementRef)
    {
        worldElementRef = _worldElementRef;
        rotateBtn.SetActive = true;
        deleteBtn.SetActive = true;
    }

    public void RotateWorldElement()
    {
        if(!worldElementRef)
        {
            return;
        }

        worldElementRef.transform.Rotate(0, 0, 90);
    }

    public void DeleteWorldElement()
    {
        if(worldElementRef)
        {
            return;
        }

        Destroy(worldElementRef);
    }

    public void ClearWorldElementRef() => worldElementRef = null;
}
