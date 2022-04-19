using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;

    private MeshRenderer renderer;
    private GameObject tower;

    private Vector3 buildOffset = new Vector3(0, 0.1f, 0);

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material.color = defaultColor;
        renderer.enabled = false;
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
        tower = (GameObject)Instantiate(selectedTower.GetTowerAsGameObject(), transform.position + buildOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (GameController.instance.GetSelectedTower() != null && tower == null)
        {
            renderer.enabled = true;
            renderer.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        renderer.enabled = false;
        renderer.material.color = defaultColor;
    }
}
