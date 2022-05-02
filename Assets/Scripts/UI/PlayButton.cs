using UnityEngine;
using UnityEngine.EventSystems;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale == 0 || Time.timeScale > 1)
        {
            GameController.instance.ResumeGame();
            ffButton.GetComponent<FastForwardButton>().ResetColor();
            pauseButton.GetComponent<PauseButton>().ResetColor();
        }
    }
}
