using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathPoints;

    [SerializeField]
    private float moveSpeed = 1f;

    private int health = 100;

    private int pointIndex;

    // Update is called once per frame
    void Update()
    {
        Move();
        if (health <= 0)
            Destroy(this);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathPoints[pointIndex].transform.position, moveSpeed * Time.deltaTime);
        if ((transform.position.x == pathPoints[pointIndex].transform.position.x) 
            && (transform.position.z == pathPoints[pointIndex].transform.position.z) 
            && pointIndex < pathPoints.Length - 1)
        {
            ++pointIndex;
            transform.LookAt(pathPoints[pointIndex]);
        }
    }
}
