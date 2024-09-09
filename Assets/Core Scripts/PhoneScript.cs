using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject phoneMenu;
    public GameObject player;

    private bool showingPhoneMenu;

    private bool movePlayerLeft;
    private bool movePlayerRight;

    public static bool playerJump;


    void Start()
    {
        showingPhoneMenu = false;
    }

    void Update()
    {
        if (movePlayerLeft)
        {
            player.transform.position = player.transform.position + new Vector3(-2, 0, 0) * Time.deltaTime;
        }
        if (movePlayerRight)
        {
            player.transform.position = player.transform.position + new Vector3(2, 0, 0) * Time.deltaTime;
        }
    }

    public void PhoneControllsEnabled()
    {
        if (!showingPhoneMenu)
        {
            phoneMenu.SetActive(true);
            showingPhoneMenu = true;
        }
        else
        {
            phoneMenu.SetActive(false);
            showingPhoneMenu = false;
        }
    }

    public void MovePlayerLeftDown()
    {
        movePlayerLeft = true;
    }
    public void MovePlayerLeftUp()
    {
        movePlayerLeft = false;
    }

    public void MovePlayerRightDown()
    {
        movePlayerRight = true;
    }
    public void MovePlayerRightUp()
    {
        movePlayerRight = false;
    }

    public void MovePlayerJumpDown()
    {
        playerJump = true;
    }
    public void MovePlayerJumpUp()
    {
        playerJump = false;
    }

}
