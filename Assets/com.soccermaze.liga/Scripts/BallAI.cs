using UnityEngine;

public class BallAI : MonoBehaviour
{
    private bool IsTraveling { get; set; }

    private Vector2 Target { get; set; }

    [SerializeField] float rayLenght;
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

        RaycastHit2D hit = Physics2D.Raycast(Vector2.down, transform.position, rayLenght);
        if(hit.collider != null)
        {
            Target = hit.transform.position;
            Debug.Log(hit.collider.name);
        }

        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    public void StartTravelling()
    {
        IsTraveling = true;
        Debug.Log("StartTravelling");
    }
}
