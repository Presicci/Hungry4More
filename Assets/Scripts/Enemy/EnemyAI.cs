using UnityEngine;

/// <summary>
/// Handles the pathing and holds the stats for each enemy.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("EnemyPathObject that the enemy will follow.")]
    private EnemyPathObject path;

    [SerializeField]
    [Tooltip("Object that will be enabled when the enemy reaches the fridge.")]
    private Transform cake;

    [SerializeField]
    [Tooltip("Coin object that will be spawned when the enemy dies.")]
    private Transform coin;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int moneyReward = 2;

    private int pointIndex;

    private bool isDead = false;

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
        if (health <= 0 && !isDead)
        {
            isDead = true;  // Prevents the enemy awarding more money than intended
            Transform coinObj = Instantiate(coin, coin.position, coin.rotation);    // Spawn a coin above the piggy jar
            coinObj.GetComponent<Coin>().SetMoneyAmount(moneyReward);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    public void SetMoneyReward(int money)
    {
        this.moneyReward = money;
    }
}
