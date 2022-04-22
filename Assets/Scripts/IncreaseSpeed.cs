using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class IncreaseSpeed : MonoBehaviour
{
    public float gainSpeed = 0.2f;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Vector2 normal = other.GetContact(0).normal;
            // ball.rgbd.AddForce(-normal * gainSpeed, ForceMode2D.Impulse);
        }    
    }
}
