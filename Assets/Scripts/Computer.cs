using UnityEngine;

public class Computer : Paddle
{
    public Rigidbody2D ball;

    void Start() {
        SetMode();
    }
    // FixUpdate is called once per amount of time (Do physic here)
    void FixedUpdate() 
    {
        if (this.ball.velocity.x > 0.0f)
        {
            if (this.ball.position.y > this.transform.position.y)
            {
                rgbd.AddForce(Vector2.up * SPEED);
            }
            else
            {
                rgbd.AddForce(Vector2.down * SPEED);
            }
        }
        else 
        {
            if (this.transform.position.y < 0)
            {
                rgbd.AddForce(Vector2.up * SPEED);
            }
            else
            {
                rgbd.AddForce(Vector2.down * SPEED);
            }
        }
    }

    void SetMode()
    {
        string mode = PlayerPrefs.GetString("mode");
        switch (mode) 
        {
            case "ease":
                this.SetSpeed(15f);
                break;
            case "normal":
                this.SetSpeed(30f);
                break;
            case "hard":
                this.SetSpeed(50f);
                break;
        }
    }
}
