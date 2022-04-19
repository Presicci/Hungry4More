using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private TowerObject tower;

    private Image image;
    private Color initialColor;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
        initialColor = image.color;
        EventTrigger trigger = this.transform.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameController.instance.SelectTower(tower);
        TowerButtonController.instance.ResetOtherButtons(this);
        image.color = Color.gray;
    }

    public void ResetColor()
    {
        image.color = initialColor;
    }
}
