using UnityEngine;

/// <summary>
/// Funny little attachment to make the object rotate every frame, used for mm food.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class RotateObject : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Index for the rotation axis. 0 = x, 1 = y, 2 = z")]
    private int rotationAxis;

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (rotationAxis)
        {
            default:
                transform.Rotate(new Vector3(4, 0, 0));
                break;
            case 1:
                transform.Rotate(new Vector3(0, 4, 0));
                break;
            case 2:
                transform.Rotate(new Vector3(0, 0, 4));
                break;
        }
    }
}
