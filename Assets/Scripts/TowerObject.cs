using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Tower", fileName = "Tower.asset")]
public class TowerObject : ScriptableObject
{
    [SerializeField]
    private GameObject towerObject;

    public GameObject GetTowerAsGameObject()
    {
        return towerObject;
    }
}
