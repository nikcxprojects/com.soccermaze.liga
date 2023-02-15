using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StartCell : MonoBehaviour
{
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnMouseDown()
    {
        if(GameManager.GamePaused)
        {
            return;
        }

        Debug.Log("start game");
    }
}
