using UnityEngine;

public class Ball : MonoBehaviour
{
    public float SPEED = 300f;
    public Rigidbody2D rgbd;

    // Awake is called only once time to initiate
    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        ResetPosition();
        AddRandomForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRandomForce()
    { 
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y =  Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rgbd.AddForce(new Vector2(x, y)  * SPEED);
    }

    public void ResetPosition()
    {
        rgbd.position = Vector2.zero;
        rgbd.velocity = Vector2.zero;
    }

    public float GetVelocityX()
    {
        return rgbd.velocity.x;
    }

    void SetSpeed(float speed)
    {
        this.SPEED = speed;
    }

    void SetMode()
    {
        string mode = PlayerPrefs.GetString("mode");
        switch (mode) 
        {
            case "ease":
                this.SetSpeed(100f);
                break;
            case "normal":
                this.SetSpeed(200f);
                break;
            case "hard":
                this.SetSpeed(300f);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name != "Left Wall" && other.gameObject.name != "Right Wall")
            FindObjectOfType<AudioManager>().Play("BallHitted");
    }
}
