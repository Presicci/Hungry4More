using UnityEngine;
using UnityEngine.EventSystems;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private TowerObject tower;

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
        Debug.Log("clicked");
        GameController.instance.SelectTower(tower);
    }
}
