using UnityEngine;

public class EnemyPathObject : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathPoints;

    public Transform[] GetPathPoints()
    {
        return pathPoints;
    }
}
