using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Click handling for the fast forward button.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class FastForwardButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Tooltip("Pause button reference, used for resetting its color when this button is pressed.")]
    private Transform pauseButton;

    [SerializeField]
    [Tooltip("Play button reference, used for resetting its color when this button is pressed.")]
    private Transform playbutton;

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
        if (Time.timeScale > 1)
        {
            ResetColor();
            GameController.instance.ResumeGame();
        }
        else
        {
            image.color = toggledColor;
            GameController.instance.FastForwardGame();
            pauseButton.GetComponent<PauseButton>().ResetColor();
            playbutton.GetComponent<PlayButton>().ResetColor();
        }
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
