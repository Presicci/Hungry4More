using UnityEngine;

/// <summary>
/// Handles rendering for build nodes and handles the placing of towers.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class BuildNode : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;

    private MeshRenderer mRenderer;
    private GameObject tower;

    private Vector3 buildOffset = new Vector3(0, 0.1f, 0);

    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        mRenderer.material.color = defaultColor;
        mRenderer.enabled = false;
    }

    private void OnMouseDown()
    {
        if (tower != null)
            return;
        TowerObject selectedTower = GameController.instance.GetSelectedTower();
        if (selectedTower == null)
            return;
        if (!GameController.instance.HasEnoughMoney(selectedTower.GetCost()))
        {
            Debug.Log("Not enough money!");
            return;
        }
        GameController.instance.RemoveMoney(selectedTower.GetCost());
        GameObject towerPrefab = selectedTower.GetTowerAsGameObject();
        tower = (GameObject)Instantiate(towerPrefab, transform.position + buildOffset, towerPrefab.transform.rotation);
    }

    void OnMouseEnter()
    {
        if (GameController.instance.GetSelectedTower() != null && tower == null)
        {
            mRenderer.enabled = true;
            mRenderer.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        mRenderer.enabled = false;
        mRenderer.material.color = defaultColor;
    }
}
