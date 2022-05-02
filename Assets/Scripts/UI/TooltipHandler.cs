using UnityEngine;
using TMPro;
using System.Text;

/// <summary>
/// Handles positional updates and status manipulation for the Tooltip element of the UI.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class TooltipHandler : MonoBehaviour, ICanvasRaycastFilter
{
    // Holds the active instance for this object
    public static TooltipHandler instance;

    private TextMeshProUGUI titleTextMesh;
    private TextMeshProUGUI bodyTextMesh;
    private RectTransform backgroundTransform;
    private Vector3 tooltipOffset = new Vector3(60, -35, 0);

    private void Awake()
    {
        if (instance == null)
            instance = this;
        titleTextMesh = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        bodyTextMesh = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        backgroundTransform = transform.GetChild(0).GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void ConstructTooltip(Vector3 position, string titleText, string bodyText)
    {
        DrawTooltip(position);
        titleTextMesh.SetText(BreakupString(titleText));
        bodyTextMesh.SetText(BreakupString(bodyText));
        TextMeshProUGUI largerText = titleText.Length > bodyText.Length ? titleTextMesh : bodyTextMesh;
        backgroundTransform.sizeDelta = new Vector2(largerText.preferredWidth + 20f, titleTextMesh.preferredHeight + bodyTextMesh.preferredHeight + 12f);
    }

    public void ConstructTooltip(Vector3 position, string titleText)
    {
        DrawTooltip(position);
        titleTextMesh.SetText(BreakupString(titleText));
        bodyTextMesh.SetText(" ");
        backgroundTransform.sizeDelta = new Vector2(titleTextMesh.preferredWidth + 20f, titleTextMesh.preferredHeight + 12f);
    }

    private void DrawTooltip(Vector3 position)
    {
        gameObject.SetActive(true);
        UpdatePosition();
    }

    public void DestroyTooltip()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 position = Input.mousePosition + tooltipOffset;
        // If tooltip would draw off the screen to the right, flip it to the left side of the mouse
        if (position.x + backgroundTransform.rect.width + tooltipOffset.x > Screen.width)
        {
            position.x = Input.mousePosition.x - backgroundTransform.rect.width + tooltipOffset.x / 2;
        }
        // If tooltip would draw below the screen, lock it to the bottom of the screen
        if (position.y - backgroundTransform.rect.height - tooltipOffset.y < 0)
        {
            position.y = 0 + backgroundTransform.rect.height + tooltipOffset.y;
        }
        transform.GetComponent<RectTransform>().anchoredPosition = position;
    }

    private string BreakupString(string text)
    {
        string[] words = text.Split(' ');
        int count = 0;
        int totalWords = 0;
        StringBuilder sb = new StringBuilder();
        while (totalWords < words.Length)
        {
            count += words[totalWords].Length;
            if (count > 28)
            {
                count = words[totalWords].Length;
                sb.Append("\n").Append(words[totalWords]).Append(" ");
            }
            else
            {
                sb.Append(words[totalWords]).Append(" ");
            }
            ++totalWords;
        }
        return sb.ToString();
    }

    // Disables raycasting on this UI element
    public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        return false;
    }
}
