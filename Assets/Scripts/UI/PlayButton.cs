using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Click handling for the play/continue button.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Tooltip("Fast forward button reference, used for resetting its color when this button is pressed.")]
    private Transform ffButton;

    [SerializeField]
    [Tooltip("Pause button reference, used for resetting its color when this button is pressed.")]
    private Transform pauseButton;

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
        if (GameController.instance.IsGameLost())
            return;
        if (Time.timeScale == 0 || Time.timeScale > 1)
        {
            GameController.instance.ResumeGame();
            image.color = toggledColor;
            ffButton.GetComponent<FastForwardButton>().ResetColor();
            pauseButton.GetComponent<PauseButton>().ResetColor();
        }
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }

    public void ToggleColor()
    {
        image.color = toggledColor;
    }
}
