using UnityEngine;

/// <summary>
/// Lightning tower AI, used for waffles.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class LightningTower : TowerAI
{
    override protected void TryAttack()
    {
        timeSinceLastAttack -= Time.deltaTime;
        if (timeSinceLastAttack > 0f)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < range)
            {
                target = enemy.transform;
                GameObject bolt = (GameObject)Instantiate(attackEffect, target.position, Quaternion.identity);
                Destroy(bolt, 0.4f);
                EnemyAI enemyToHit = target.GetComponent<EnemyAI>();
                if (enemyToHit != null)
                    enemyToHit.Hit(damage);
            }
        }
        timeSinceLastAttack = attackSpeed;
    }
}
