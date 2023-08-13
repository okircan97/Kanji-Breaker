using UnityEngine;

public class Ball : MonoBehaviour {

    // fields
    bool hasStarted = false;

    // configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float ClickVectorX = 2f;
    [SerializeField] float ClickVectorY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip windVoice;

    // state
    Vector2 paddleToBallVector;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Vector2 wind = new Vector2(0, -5);
            myRigidBody2D.velocity = myRigidBody2D.velocity + wind;
            myAudioSource.PlayOneShot(windVoice);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Vector2 wind = new Vector2(5, 0);
            myRigidBody2D.velocity = myRigidBody2D.velocity + wind;
            myAudioSource.PlayOneShot(windVoice);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Vector2 wind = new Vector2(-5, 0);
            myRigidBody2D.velocity = myRigidBody2D.velocity + wind;
            myAudioSource.PlayOneShot(windVoice);
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            myRigidBody2D.velocity = new Vector2(ClickVectorX, ClickVectorY);
            hasStarted = true;
            Cursor.visible = false;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y - 0.05f);
        transform.position = paddlePosition + paddleToBallVector;
    }

    // this method will make the 
    // in the course line 53 was orginally "OnCollisionEnter2D". I changed ti with the following so that the problem letting the ball going through
    // the junction points is solved. I also changed the ball's RigidBody2D --> Collision Detection to Continious, over the inspector. 
    private void OnCollisionExit2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor)); 
        if (hasStarted) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
