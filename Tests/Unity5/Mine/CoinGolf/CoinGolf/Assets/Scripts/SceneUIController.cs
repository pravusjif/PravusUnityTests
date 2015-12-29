using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUIController : MonoBehaviour
{
    public Image winningImage;

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void DisplayWinningImage()
    {
        winningImage.enabled = true;
    }
}
