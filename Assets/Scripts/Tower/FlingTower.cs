using UnityEngine;

/// <summary>
/// Fling tower AI, used for apples.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class FlingTower : TowerAI
{
    private Vector3 spawnPos;
    private EnemyAI enemyAI;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    override protected void TryAttack()
    {
        timeSinceLastAttack -= Time.deltaTime;
        if (target != null)
            transform.LookAt(target.transform);
        if (timeSinceLastAttack > 0f)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject potentialTarget = null;
        float potentialDistance = range + 1;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < potentialDistance)
            {
                potentialDistance = distance;
                potentialTarget = enemy;
            }
        }
        if (potentialDistance <= range && potentialTarget != null)
        {
            target = potentialTarget.transform;
            transform.LookAt(target.transform);
            enemyAI = target.GetComponent<EnemyAI>();
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetComponent<Rigidbody>().AddForce(target.position - transform.position + new Vector3(.1f, 3, .1f), ForceMode.Impulse);
            timeSinceLastAttack = attackSpeed;
            Invoke("HurtEnemy", 0.7f);  // Call with a delay to avoid the enemy dying as soon as the object is thrown
            Invoke("RespawnTower", 1.4f);
        }
    }

    private void HurtEnemy()
    {
        if (enemyAI != null)
            enemyAI.Hit(damage);
    }

    private void RespawnTower()
    {
        transform.position = spawnPos;
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.rotation = Quaternion.identity;
    }
}
