using UnityEngine;

/// <summary>
/// Path object that holds an array of Transforms that are only used for their coordinates.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class EnemyPathObject : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathPoints;

    public Transform[] GetPathPoints()
    {
        return pathPoints;
    }
}
