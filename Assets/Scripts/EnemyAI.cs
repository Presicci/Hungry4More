using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private EnemyPathObject path;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private Transform cake;

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
            && (transform.position.z == pathPoints[pointIndex].position.z))
        {
            if (pointIndex < pathPoints.Length - 1)
            {
                if (pointIndex == 3)
                    cake.gameObject.SetActive(true);
                ++pointIndex;
                transform.LookAt(pathPoints[pointIndex]);
                return;
            }
            if (pointIndex == pathPoints.Length - 1)
            {
                GameController.instance.RemoveLife();
                Destroy(gameObject);
            }
        }
    }

    public void Hit(int damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            GameController.instance.AddMoney(2);    // Temp addMoney amt
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
