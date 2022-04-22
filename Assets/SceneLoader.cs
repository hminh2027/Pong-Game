using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public InputField inputName;
    public GameObject errorMessage;

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadInputNameScene()
    {
        SceneManager.LoadScene("InputNameScene");
    }

    public void LoadModeScene()
    {
        SceneManager.LoadScene("ModeScene");
    }

    public void LoadScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }
    
    public void LoadGameScene()
    {
        
        if (string.IsNullOrEmpty(inputName.text)) {
            errorMessage.SetActive(true);
            return;
        }
        PlayerPrefs.SetString("curPlayer", inputName.text);
        SceneManager.LoadScene("GameScene");     
    }
}
