using UnityEngine;
using System.Collections;

public class MovementR : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;
    private bool isWaiting = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.right * 10;
    }

    void Update()
    {
        if (!isWaiting)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                StartCoroutine(WaitAndChangeDirection());
            }
        }
    }

    IEnumerator WaitAndChangeDirection()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1.0f); 

        if (movingRight)
        {
            targetPosition = startPosition + Vector3.left * 10;
        }
        else
        {
            targetPosition = startPosition + Vector3.right * 10;
        }
        movingRight = !movingRight;
        isWaiting = false;
    }
}




















