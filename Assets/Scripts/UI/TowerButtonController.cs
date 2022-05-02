using UnityEngine;

/// <summary>
/// Controls the states of the play/pause/ff buttons.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class TowerButtonController : MonoBehaviour
{
    // Holds the active instance for this object
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
