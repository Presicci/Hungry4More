using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public float attackSpeed = 0.5f;
    public GameObject laserEffect;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TryAttack", 0f, attackSpeed);
    }

    void TryAttack()
    {
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
            if (enemy != null)
                enemy.Hit(50);

        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        transform.LookAt(target.transform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
