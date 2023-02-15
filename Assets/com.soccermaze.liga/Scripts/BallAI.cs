using System.Collections;
using UnityEngine;

public class BallAI : MonoBehaviour
{
    private readonly Vector2[] Directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private Vector2 Target { get; set; }
    [SerializeField] float speed;
    [SerializeField] float deistance;

    public void SetBallPosition(Vector2 position)
    {
        Target = transform.position;
        Debug.Log(Target);
    }

    public void StartTravelling()
    {
        StartCoroutine(nameof(Travelling));
    }

    private IEnumerator Travelling()
    { 
        while(true)
        {
            //for (int i = 0; i < Directions.Length; i++)
            //{
            //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Directions[i], deistance);
            //    if (hit.collider != null)
            //    {
            //        if (hit.collider.GetType() == typeof(EdgeCollider2D))
            //        {
            //            continue;
            //        }

            //        if (hit.collider.isTrigger)
            //        {
            //            hit.collider.gameObject.layer = 2;
            //            Target = hit.transform.position;
            //        }
            //    }

            //    if (Target != (Vector2)transform.position)
            //    {
            //        break;
            //    }
            //}

            while ((Vector2)transform.position != Target)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
                yield return null;
            }

            yield return null;
        }
    }
}
