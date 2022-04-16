using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private EnemyPathObject path;

    [SerializeField]
    private float moveSpeed = 1f;

    private int health = 100;

    private int pointIndex;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform[] pathPoints = path.GetPathPoints();
        transform.position = Vector3.MoveTowards(transform.position, pathPoints[pointIndex].position, moveSpeed * Time.deltaTime);
        if ((transform.position.x == pathPoints[pointIndex].position.x) 
            && (transform.position.z == pathPoints[pointIndex].position.z) 
            && pointIndex < pathPoints.Length - 1)
        {
            ++pointIndex;
            transform.LookAt(pathPoints[pointIndex]);
        }
    }
}
