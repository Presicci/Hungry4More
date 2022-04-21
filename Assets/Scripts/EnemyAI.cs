using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private EnemyPathObject path;

    [SerializeField]
    private Transform cake;

    [SerializeField]
    private Transform coin;

    private float moveSpeed = 1f;
    private int health = 100;
    private int moneyReward = 2;

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
            //GameController.instance.AddMoney(moneyReward);    // Temp addMoney amt
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
