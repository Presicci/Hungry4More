using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Image image;
    private Color initialColor;
    private Color toggledColor;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
        initialColor = image.color;
        toggledColor = new Color(image.color.r, image.color.g, image.color.b, 0.4f);
        //toggledColor = image.color;
        //toggledColor.a = 90;
        EventTrigger trigger = this.transform.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale == 0)
        {
            image.color = toggledColor;
            GameController.instance.ResumeGame();
        }   
        else
        {
            image.color = initialColor;
            GameController.instance.PauseGame();
        }
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
