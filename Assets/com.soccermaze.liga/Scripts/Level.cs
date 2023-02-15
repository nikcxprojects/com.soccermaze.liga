using UnityEngine;

public class Level : MonoBehaviour
{
    private static float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;

    [SerializeField] Sprite startSprite;
    [SerializeField] SpriteRenderer[] startPoints;

    private void Start()
    {
        startPoints[Random.Range(0, startPoints.Length)].sprite = startSprite;
        transform.position += Vector3.down * 15.0f;
    }

    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, Vector2.zero, ref velocity, smoothTime);
    }
}
