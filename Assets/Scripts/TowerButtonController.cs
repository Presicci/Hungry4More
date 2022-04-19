using UnityEngine;

public class TowerButtonController : MonoBehaviour
{
    public static TowerButtonController instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ResetOtherButtons(TowerButton excempt)
    {
        foreach (TowerButton button in GetComponentsInChildren<TowerButton>())
        {
            if (button != excempt)
                button.ResetColor();
        }
    }
}
