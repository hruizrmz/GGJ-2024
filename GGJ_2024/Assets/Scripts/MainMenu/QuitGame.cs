using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void QuitGameFunction()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.sfxSource.Stop();
        AudioManager.instance.PlayMusic("Opening");
        SceneManager.LoadScene("MainMenu");
    }
}