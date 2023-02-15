using System.Collections;
using UnityEngine;

public class BallAI : MonoBehaviour
{
    private readonly Vector2[] Directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private Vector2 Target { get; set; }
    private const float force = 2;

    private static Rigidbody2D Rigidbody { get; set; }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetBallPosition(Vector2 position)
    {
        transform.position = position;
        Target = position;
    }

    public void StartTravelling()
    {
        StartCoroutine(nameof(Travelling));
    }

    public static bool Sleep
    {
        set => Rigidbody.bodyType = value ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Goal>() != null)
        {
            StopCoroutine(nameof(Travelling));
        }
    }

    private IEnumerator Travelling()
    { 
        while(true)
        {
            if (GameManager.GamePaused)
            {
                yield return null;
            }

            bool find = false;

            for (int i = 0; i < Directions.Length; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Directions[i], 0.7f);
                if (hit.collider != null)
                {
                    if (hit.collider.GetType() == typeof(EdgeCollider2D))
                    {
                        continue;
                    }

                    if (hit.collider.isTrigger)
                    {
                        hit.collider.gameObject.layer = 2;
                        Target = hit.transform.position;
                        find = true;
                    }
                }

                if (find)
                {
                    break;
                }
            }

            Vector2 direction = (Target - (Vector2)transform.position).normalized;
            Rigidbody.AddForce(direction * force, ForceMode2D.Force);

            yield return null;
        }
    }
}
