using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxScript : MonoBehaviour
{
    private float moveSpeed;
    public GameObject Coin;

    Rigidbody m_Rigidbody;

    // transparent box
    public Material clearRedBox;
    private bool _brokenBox;
    Color tempColor;

    void Start()
    {
        moveSpeed = SpawnerScript._objectSpeedSet;

        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        tempColor = GetComponent<MeshRenderer>().material.color;
    }

    void Update()
    {
        //Destory if off screen
        if (transform.position.z < -11)
        {Destroy(gameObject);}                

        // Get transparent if broken
        if (_brokenBox)
        {
            tempColor = GetComponent<MeshRenderer>().material.color;
            tempColor.a -= 0.7f * Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = tempColor;
        }

        if (tempColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(0, 0, -1);

        //Move box forward
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && PlayerScript.playerColor == "Red" && gameObject.gameObject.CompareTag("Red Cube")) //If player red and box red
        {
            BreakBox();
        }    
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && PlayerScript.playerColor == "Red" && gameObject.gameObject.CompareTag("Red Cube")) //If player red and box red
        {
            BreakBox();
        }
    }

    private void BreakBox()
    {
        Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(new Vector3(90, 0, -90)));
        PlayerScript.rb.position = new Vector3(PlayerScript.rb.position.x, PlayerScript.rb.position.y, PlayerScript.rb.position.z + 0.1f);
        ScoreScript.score += 1;

        // Cool way to break the box
        GetComponent<BoxCollider>().enabled = false;
        float randomNumber = Random.Range(-3, 3); //Make a random number
        GetComponent<Rigidbody>().velocity = new Vector3(randomNumber,4,0);
        GetComponent<Renderer>().material = clearRedBox;
        _brokenBox = true;
    }
}