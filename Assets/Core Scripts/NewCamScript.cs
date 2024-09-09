using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamScript : MonoBehaviour
{
    public GameObject _mainCamera;
    public GameObject _camFollowTarget;
    public GameObject _player;
    public GameObject _menuSong;
    
    // In menu, between menu and game, in game
    public static bool _gaming;
    public static bool _beginGaming;

    // Vector3's we need
    Vector3 mainMenuCameraPosisiton;
    Vector3 gamingCameraPosistion;

    Vector3 mainMenuCameraLookatTarget;
    Vector3 gamingCameraLookatTarget;

    // Can play with how fast the cam and LookAt target move
    private float cameraSpeed;
    private float lookAtTargetSpeed;

    // Stuff for Lerp
    private float startTime;
    float t;

    // remember auto play
    bool _autoPlay;
    public AudioSource _clickSound;

    private void Start()
    {
        _gaming = false;
        _beginGaming = false;

        mainMenuCameraPosisiton = new Vector3(-15f, 6f, -3.8f);
        gamingCameraPosistion = new Vector3(0f, 3.2f, -12f);

        mainMenuCameraLookatTarget = new Vector3(0f, 3.45f, 3.2f);
        gamingCameraLookatTarget = new Vector3(0f, 0f, -5.65f);

        cameraSpeed = 3f * Time.deltaTime;
        lookAtTargetSpeed = 2f * Time.deltaTime;

        _mainCamera.transform.position = mainMenuCameraPosisiton;
        _camFollowTarget.transform.position = mainMenuCameraLookatTarget;

        // Load right away if want to
        Debug.Log(PlayerPrefs.GetInt("autoPlay"));

        if ((PlayerPrefs.GetInt("autoPlay") == 1) && !_beginGaming && !_gaming)
        {
            MoveCamFromMenuToGaming();
        }
    }

    private void Update()
    {
        // Set cam to menu, set target to menu
        // Look at target
        // Move cam to gaming, move target to gaming
        if (_beginGaming)
        {
            t = t + 0.5f * Time.deltaTime;
            _mainCamera.transform.position = Vector3.Lerp(mainMenuCameraPosisiton, gamingCameraPosistion, t);
            _camFollowTarget.transform.position = Vector3.Lerp(mainMenuCameraLookatTarget, gamingCameraLookatTarget,  t);

            _player.SetActive(true);
        }

        if (_gaming)
        {
            DuringGameCamMove();

            // Stop menu song
            _menuSong.SetActive(false);
        }

        if (!_gaming)
        {
            _mainCamera.transform.LookAt(_camFollowTarget.transform.position);

            // Play menu song
            _menuSong.SetActive(true);
        }
    }

    public void MoveCamFromMenuToGaming()
    {
        _clickSound.Play();

        _mainCamera.transform.position = mainMenuCameraPosisiton;

        _camFollowTarget.transform.position = mainMenuCameraLookatTarget;

        t = 0;

        _beginGaming = true;

        StartCoroutine(WaitForCamToMove());
    }
    IEnumerator WaitForCamToMove()
    {
        yield return new WaitForSeconds(2.2f);
        _beginGaming = false;
        _gaming = true;
    }

    public void ResetCamFromGamingToMenu()
    {
        _gaming = false;

        _mainCamera.transform.position = mainMenuCameraPosisiton;
        _camFollowTarget.transform.position = mainMenuCameraLookatTarget;
    }

    private void DuringGameCamMove()
    {
        //Move camera up if down
        if (FanTriggerScript.enteredFan == true && _mainCamera.transform.position.y < 10)
        {
            transform.position = transform.position + (Vector3.up * 7) * Time.deltaTime; //move cam up

        }

        //Move camera down if up
        if (FanTriggerScript.enteredFan == false && _player.transform.position.y < 6.2 && _mainCamera.transform.position.y > 3.25)
        {
            transform.position = transform.position + (Vector3.down * 12) * Time.deltaTime; //move cam down
        }
    }

    public void RememberAutoPlay()
    {
        _autoPlay = !_autoPlay;
        if (_autoPlay)
        {
            PlayerPrefs.SetInt("autoPlay", 1);
        }
        else
        {
            PlayerPrefs.SetInt("autoPlay", 0);
        }
        _clickSound.Play();
    }
}
