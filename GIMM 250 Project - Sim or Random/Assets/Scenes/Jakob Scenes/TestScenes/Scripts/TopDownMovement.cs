using UnityEngine;
using UnityEngine.UI;

public class TopDownMovement : MonoBehaviour
{
    public float speed; // Speed given to attached object
    public Rigidbody2D rb; // Reference to the Rigidbody component, attached to the GameObject
    private Vector2 moveInput; // Vector to store input for movement

    [SerializeField] private AudioClip ratSound;
    [SerializeField] private AudioClip toiletFlush;
    [SerializeField] private AudioClip Handcuffs;
    [SerializeField] private AudioClip Toothbrush;
    private AudioSource audioSource;

    [SerializeField] private GameObject key; // Reference to the key GameObject
    [SerializeField] private Transform circle; // Reference to the circle Transform

    private Button upButton; // Reference to the button component
    private Button downButton;
    private Button leftButton;
    private Button rightButton;

    private bool keyCollected = false; // Flag to track if the key has been collected

    private void Start()
    {
        upButton = GameObject.Find("UpButton").GetComponent<Button>();
        downButton = GameObject.Find("DownButton").GetComponent<Button>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        rightButton = GameObject.Find("RightButton").GetComponent<Button>();

        audioSource = GetComponent<AudioSource>();
    }

    // MOVEMENT CODE/KEY FOLLOW 

    void Update()
    {
        // on button press, move the player in the desired direction
        upButton.onClick.AddListener(() => moveInput.y = 1);
        downButton.onClick.AddListener(() => moveInput.y = -1);
        leftButton.onClick.AddListener(() => moveInput.x = -1);
        rightButton.onClick.AddListener(() => moveInput.x = 1);
        // on button release, stop the player



        //Gets the horizontal and vertical input from the player
        //moveInput.x = Input.GetAxisRaw("Horizontal");
        //moveInput.y = Input.GetAxisRaw("Vertical");

        //Normalizes the movement vector to ensure consistent speed in all directions
        moveInput.Normalize();

        //Sets the velocity of the Rigidbody to move the object in the desired direction
        //Multiplied by the speed to control actual movement speed of attached object
        rb.velocity = moveInput * speed;

        //Moves the key with the circle if it has been collected
        if (keyCollected)
        {
            key.transform.position = circle.position;
        }
    }

    //SOUND EFFECT CODE/KEY FOLLOW

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TP"))
        {
            PlaySound(toiletFlush);
        }
        else if (other.CompareTag("Rat"))
        {
            PlaySound(ratSound);
        }
        else if (other.CompareTag("Handcuffs"))
        {
            PlaySound(Handcuffs);
        }
        else if (other.CompareTag("Toothbrush"))
        {
            PlaySound(Toothbrush);
        }

        if (other.gameObject == key && !keyCollected)
        {
            keyCollected = true; //Sets to true to indicate key is collected
            key.transform.SetParent(circle); //Set key as child to circle
        }
    }

    void PlaySound(AudioClip clip) //Helps logistics for sound
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
