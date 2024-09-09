using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//[RequireComponent(typeof(Rigidbody))]

public class PlayerScript : MonoBehaviour
{
    //Player posisiton
    static public Vector3 Vec; //Posisiton
    Vector3 VecStart; //Starting Posisiton

    //Put player back to good z-axis if pushed back
    public float forwardPower; //Forward Power

    //Define player's physics
    public static Rigidbody rb; //The Player

    //Jumping
    public float _variableJumpHeightMax;
    public float jumpAmount;
    public static float jumpTime;
    public static bool jumping;
    readonly float distanceCheck = 0.5f; //From center of player to little under player

    //Player color
    public static string playerColor;
    public Material _redMat;
    public Material _blueMat;
    public Material _yellowMat;

    //Player has control
    public static bool playerControl;

    //Rail bools
    public static bool _balancePlayer;
    bool _doingTrick;

    //Fan bools
    public static bool enteredFan;

    //Paused game
    public GameObject pauseMenu;
    public static bool _gamePaused;

    //Restarting game
    bool _restartingGame;
    public static bool _autoLoad;
    public GameObject _deathExplosion;

    //Game Speed
    public static float _gameSpeed;

    //Song
    private int randomNumber;
    public static GameObject playingSong;
    public GameObject song1;
    public GameObject song2;


    void Start()
    {
        VecStart = transform.localPosition; //Get starting posistion
        rb = GetComponent<Rigidbody>(); //Player's body

        //Dropping in
        gameObject.transform.position = new Vector3(6.4f, -1.4f, -11);
        rb.velocity = new Vector3(-5.4f, 7, 1);

        //Pick a song
        randomNumber = Random.Range(1, 6); //Make a random number
        PickSong(randomNumber);

        //Starting Values
        playerColor = "Red";
        playerControl = true;
        _balancePlayer = false;
        enteredFan = false;
        _doingTrick = false;

        // Destory all spawns when I come in
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.layer == 6)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        //Current posistion
        Vec = transform.localPosition; 

        //Left and right
        if(playerControl)
        {
            Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 2;
        }

        //Forward if got pushed back
        if (Vec.z < VecStart.z && Time.timeScale < 6)
        {
            Vec.z += Time.deltaTime * forwardPower;
        }

        //Jump
        if (Input.GetButton("Jump") || PhoneScript.playerJump)
        {
            PlayerJump();
        }

        //Updated posistion is now current
        transform.localPosition = Vec;

        //Player color
        PlayerColor();

        //Doing sick trick
        if (gameObject.transform.eulerAngles.z >= 10 || (gameObject.transform.eulerAngles.z < 0))
        {
            transform.Rotate(0, 0, 350 * Time.deltaTime, Space.Self);
        }
        if (gameObject.transform.eulerAngles.z > 0 && gameObject.transform.eulerAngles.z < 10 && _doingTrick)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            _doingTrick = false;
        }

        //Restart game
        if (gameObject.transform.position.y < -1.9 && (_restartingGame == false))
        {
            //Start restarting
            _restartingGame = true;
            Time.timeScale = 1;

            //Play death sound
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "Die Sound")
                {
                    child.gameObject.SetActive(true);
                }
            }

            // Play explosion
            //Instantiate(_deathExplosion, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));

            //Do restart scene stuff after sound finishes
            StartCoroutine(WaitForDeathSound());
        }
    }

    void FixedUpdate()
    {
        //Down is down lol
        Vector3 _down = transform.TransformDirection(Vector3.down);

        //Check if player is in air
        Debug.DrawLine(this.transform.position - new Vector3(-0.15f, distanceCheck, 0), this.transform.position - new Vector3(0.15f, distanceCheck, 0));
        if (Physics.Raycast(transform.position, _down, distanceCheck))
        { jumping = false; jumpTime = 0;}
        else
        {jumping = true;}

        //Get faster
        if (Time.timeScale < 10)
        {
            Time.timeScale += 0.0005f;
            _gameSpeed = Time.timeScale;
        }
        //Debug.Log(Time.timeScale);
    }

    private void OnCollisionStay(Collision col)
    {
        //On Rail
        if (col.gameObject.CompareTag("Rail"))
        {
            foreach (Transform child in transform)
            {
                if(child.gameObject.name == "Rail Particle System")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Rail"))
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "Rail Particle System")
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        //Second rail trigger
        if (col.gameObject.name == "Rail2 Trigger" && playerColor == "Blue")
        {
            rb.velocity = new Vector3(0, 4f, 0);
        }

        //Exit rail trigger
        if (col.gameObject.name == "TopRail2 Trigger")
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z + 0.5f);
            _doingTrick = true;
            gameObject.transform.eulerAngles = new Vector3(0, 0, 11);
        }
    }

    IEnumerator WaitForDeathSound()
    {
        yield return new WaitForSeconds(1.5f);

        PlayerPrefs.SetInt("High Score", ScoreScript.highscore);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    private void PickSong(int i)
    {
        if (i < 4)
        {
            song1.SetActive(true);
            playingSong = song1;
        }
        else
        {
            song2.SetActive(true);
            playingSong = song2;

        }
    }

    private void PlayerColor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 1);
            //GetComponent<Renderer>().material = _blueMat;
            playerColor = "Blue";
            Debug.Log("Player is Blue");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            //GetComponent<Renderer>().material = _redMat;
            playerColor = "Red";
            Debug.Log("Player is Red");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 0);
            //GetComponent<Renderer>().material = _yellowMat;
            playerColor = "Yellow";
            Debug.Log("Player is Yellow");
        }
    }

    public void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && !jumping && playerControl)
        {
            if (rb.velocity.x != 0)
            {
                rb.velocity = new Vector3(0, jumpAmount, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
            }
        }
        if (jumping && jumpTime < _variableJumpHeightMax && rb.velocity.y >= jumpAmount * 2 / 3 && playerControl)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
            jumpTime += Time.deltaTime;
        }
    }
}