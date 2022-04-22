using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float SPEED = 50f;
    protected Rigidbody2D rgbd;
    
    // Awake is called only once time to initiate
    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed(float speed)
    {
        this.SPEED = speed;
    }

    public void ResetPosition()
    {
        rgbd.position = new Vector2(rgbd.position.x, 0f);
        rgbd.velocity = Vector2.zero;
    }

    protected void SetMode()
    {
        
    }
}
