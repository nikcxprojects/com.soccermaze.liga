using UnityEngine;

public class BallAI : MonoBehaviour
{
    //private Vector2[] Directions = { Vector2.down, Vector2.up, Vector2.left, Vector2.right };
    private Vector2[] Directions = { Vector2.down };
    private bool IsTraveling { get; set; }

    private Vector2 Target { get; set; }
    [SerializeField] float speed;

    private void Start()
    {
        Target = transform.position;
    }

    private void Update()
    {
        if(!IsTraveling)
        {
            return;
        }

        //RaycastHit2D hit = Physics2D.Raycast(Vector2.down, transform.position, rayLenght);
        //if(hit.collider != null)
        //{
        //    Target = hit.transform.position;
        //    Debug.Log(hit.collider.name);
        //}

        for(int i = 0; i < Directions.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(Directions[i], transform.position, Mathf.Infinity);
            if (hit.collider != null)
            {
                Target = hit.transform.position;

                if (hit.collider.isTrigger)
                {
                    hit.collider.enabled = false;
                    Debug.Log(hit.collider.name);
                }
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    public void StartTravelling()
    {
        IsTraveling = true;
        Debug.Log("StartTravelling");
    }
}
