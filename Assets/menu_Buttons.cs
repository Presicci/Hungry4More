using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_Buttons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
