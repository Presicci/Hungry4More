using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FastForwardButton : MonoBehaviour
{
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
        EventTrigger trigger = this.transform.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
        }
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
