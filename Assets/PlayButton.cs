using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Fast forward button reference, used for resetting its color when this button is pressed.")]
    private Transform ffButton;

    [SerializeField]
    [Tooltip("Pause button reference, used for resetting its color when this button is pressed.")]
    private Transform pauseButton;

    private void Awake()
    {
        EventTrigger trigger = this.transform.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

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
