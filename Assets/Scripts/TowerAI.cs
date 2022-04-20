using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public float attackSpeed = 0.5f;
    private float timeSinceLastAttack = 0.1f;   // Spawn delay
    public GameObject laserEffect;

    void Update()
    {
        TryAttack();
        if (target == null)
            return;
        transform.LookAt(target.transform);
    }

    void TryAttack()
    {
        timeSinceLastAttack -= Time.deltaTime;
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
            GameObject laser = (GameObject)Instantiate(laserEffect, transform.position, transform.rotation);
            Destroy(laser, 1f);
            EnemyAI enemy = target.GetComponent<EnemyAI>();
            timeSinceLastAttack = attackSpeed;
            if (enemy != null)
                enemy.Hit(50);
        }   
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
