using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Click handling for the tower select buttons.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class TowerButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Tooltip("Tower that this button will spawn.")]
    private TowerObject tower;

    private Image image;
    private Color initialColor;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
        initialColor = image.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameController.instance.IsGameLost())
            return;
        GameController.instance.SelectTower(tower);
        TowerButtonController.instance.ResetOtherButtons(this);
        image.color = Color.gray;
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
