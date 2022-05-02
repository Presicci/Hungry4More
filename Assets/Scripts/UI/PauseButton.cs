using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Click handling for the pause button.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class PauseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Tooltip("Fast forward button reference, used for resetting its color when this button is pressed.")]
    private Transform ffButton;

    private Image image;
    private Color initialColor;
    private Color toggledColor;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
        initialColor = image.color;
        toggledColor = new Color(image.color.r, image.color.g, image.color.b, 0.4f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
        {
            GameController.instance.PauseGame();
            image.color = toggledColor;
            ffButton.GetComponent<FastForwardButton>().ResetColor();
        }
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
