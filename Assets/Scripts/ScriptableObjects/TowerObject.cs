using UnityEngine;

/// <summary>
/// Scriptable object template for towers.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
[System.Serializable]
[CreateAssetMenu(menuName = "Tower", fileName = "Tower.asset")]
public class TowerObject : ScriptableObject
{
    [SerializeField]
    private GameObject towerObject;

    [SerializeField]
    private int cost;

    public GameObject GetTowerAsGameObject()
    {
        return towerObject;
    }

    public int GetCost()
    {
        return cost;
    }
}
