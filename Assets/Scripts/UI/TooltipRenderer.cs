using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles tooltip method calls when the gameobject is moused over.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class TooltipRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("The title text of the tooltip.")]
    private string titleText;

    [SerializeField]
    [Tooltip("The body text of the tooltip. (Optional)")]
    private string bodyText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (bodyText.Equals(""))
        {
            TooltipHandler.instance.ConstructTooltip(eventData.position, titleText);
        }
        else
        {
            TooltipHandler.instance.ConstructTooltip(eventData.position, titleText, bodyText);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipHandler.instance.DestroyTooltip();
    }
}
