using UnityEngine;
using UnityEngine.UI;
public class ScoreSceneScript : MonoBehaviour
{
    public Text username;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        if(username.text == null)
        {
            username.text = "No player before";
            score.text = " ";
        }
        else
        {
            username.text = PlayerPrefs.GetString("name");
            score.text = PlayerPrefs.GetInt("score").ToString();
        }      
    }
}