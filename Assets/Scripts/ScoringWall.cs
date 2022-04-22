using UnityEngine;

public class ScoringWall : MonoBehaviour
{
    public GameManager gm;
    void OnCollisionEnter2D(Collision2D other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            if(gm.CheckPlayerCollided(ball)) gm.PlayerScores();
            else gm.ComputerScores();
        }    
    }
}
