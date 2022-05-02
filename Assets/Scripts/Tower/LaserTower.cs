using UnityEngine;

/// <summary>
/// Laser tower AI, used for burgers and carrots.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class LaserTower : TowerAI
{
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
            GameObject laser = (GameObject)Instantiate(attackEffect, transform.position, transform.rotation);
            Destroy(laser, 0.3f);
            EnemyAI enemy = target.GetComponent<EnemyAI>();
            timeSinceLastAttack = attackSpeed;
            if (enemy != null)
                enemy.Hit(damage);
        }
    }
}