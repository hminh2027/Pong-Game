using UnityEngine;

public class Player : Paddle
{
    private Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) _direction = Vector2.up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) _direction = Vector2.down;
        else _direction = Vector2.zero;
    }

    // FixUpdate is called once per amount of time (Do physic here)
    void FixedUpdate() 
    {
        if (_direction.sqrMagnitude != 0) rgbd.AddForce(_direction * SPEED); 
    }
}
