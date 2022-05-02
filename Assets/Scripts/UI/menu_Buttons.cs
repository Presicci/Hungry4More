using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the buttons on the main menu.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class menu_Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
