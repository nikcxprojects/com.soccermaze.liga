using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public static Level Instance { get => FindObjectOfType<Level>(); }

    private static float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;

    private GameObject elementRef;

    private List<Transform> emptyCells;
    [SerializeField] Transform cells;
    [SerializeField] Transform elementParent;

    [Space(10)]
    [SerializeField] Sprite startSprite;
    [SerializeField] SpriteRenderer[] startPoints;

    private void Start()
    {
        Transform startCell = startPoints[Random.Range(0, startPoints.Length)].transform;
        emptyCells = new List<Transform>();
        for(int i = 0; i < cells.childCount; i++)
        {
            Transform cell = cells.GetChild(i);
            if(cell == startCell)
            {
                continue;
            }

            emptyCells.Add(cell);
        }

        startCell.GetComponent<SpriteRenderer>().sprite = startSprite;
        transform.position += Vector3.down * 15.0f;
    }

    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, Vector2.zero, ref velocity, smoothTime);
    }

    public void InstElement(GameObject elementPrefab)
    {
        elementRef = Instantiate(elementPrefab, elementParent);
    }

    public void UpdateElementPosition(Vector2 position)
    {
        if(!elementRef)
        {
            return;
        }

        elementRef.transform.position = position;
    }
}
