using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject _player;

    private float camSpeed = 1f;

    private Vector3 camGamePos;
    public Transform camMenuPos;

    public GameObject _menuLookAt;
    public GameObject _gameLookAt;
    private Vector3 _lookAtGoal;

    private float startTime;
    private bool gaming;

    void Start()
    {
        camGamePos = gameObject.transform.position;

        gaming = false;
    }

    void Update()
    {
        //DuringGameCamMove();

        if (gaming)
        {
            //Look at gaming ball
            transform.LookAt(_gameLookAt.transform);

            float t = (Time.time - startTime) * camSpeed;
            float easedT = t * t * t;
            transform.position = Vector3.Lerp(camMenuPos.position, camGamePos, easedT);
            _gameLookAt.transform.position = Vector3.Lerp(_menuLookAt.transform.position, _lookAtGoal, easedT);
        }
        else
        {
            //Look at menu ball
            transform.LookAt(_menuLookAt.transform);

        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            gaming = false;
            MoveCamFromMenuToGame();
        }

    }

    void DuringGameCamMove()
    {
        //Move camera up if down
        if (FanTriggerScript.enteredFan == true && transform.position.y < 10)
        {
            transform.position = transform.position + (Vector3.up * 7) * Time.deltaTime; //move cam up

        }

        //Move camera down if up
        if (FanTriggerScript.enteredFan == false && _player.transform.position.y < 6.2 && transform.position.y > 3.2)
        {
            transform.position = transform.position + (Vector3.down * 12) * Time.deltaTime; //move cam down
        }

    }

    void MoveCamFromMenuToGame()
    {
        gameObject.transform.position = camMenuPos.position;
        gameObject.transform.rotation = camMenuPos.rotation;
        gaming = true;
        startTime = Time.time;

    }
}
