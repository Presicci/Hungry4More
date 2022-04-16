using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Color hoverColor;
    public Color defaultColor;

    private MeshRenderer renderer;
    private GameObject tower;

    private Vector3 buildOffset = new Vector3(0, 0.3f, 0);

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
