using UnityEngine;

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
