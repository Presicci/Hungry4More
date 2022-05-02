using UnityEngine;

/// <summary>
/// Abstract class that represents a tower in the scene.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public abstract class TowerAI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Range of the tower")]
    protected float range = 15f;

    [SerializeField]
    [Tooltip("Time between attacks of the tower. 0.5 = 2 attacks per second")]
    protected float attackSpeed = 0.5f;

    [SerializeField]
    [Tooltip("Effect that is used for the attack.")]
    protected GameObject attackEffect;

    [SerializeField]
    [Tooltip("Damage that the tower deals.")]
    protected int damage = 25;

    protected Transform target;
    protected float timeSinceLastAttack = 0.1f;   // Spawn delay

    protected void Update()
    {
        TryAttack();
    }

    protected abstract void TryAttack();

    // Draws a sphere around the tower object with range as the radius when gizmos are toggled
    // Useful for tuning the range of the towers
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
