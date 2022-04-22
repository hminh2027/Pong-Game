using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSceneScript : MonoBehaviour
{

    public void EaseMode()
    {
        PlayerPrefs.SetString("mode", "ease");
        InputScene();
    }

    public void NormalMode()
    {
        PlayerPrefs.SetString("mode", "normal");
        InputScene();
    }

    public void HardMode()
    {
        PlayerPrefs.SetString("mode", "hard");
        InputScene();
    }

    private void InputScene()
    {
        SceneManager.LoadScene("InputNameScene");
    }
}
