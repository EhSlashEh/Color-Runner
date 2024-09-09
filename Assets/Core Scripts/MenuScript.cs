using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    //Paused game
    public GameObject pauseMenu;
    public static bool _gamePaused;
    public GameObject _player;

    //Volume Control
    public AudioMixer audioMixer;
    public GameObject volSlider;
    private float volumeMemory;

    // in game stats
    public GameObject _alwaysDisplay;

    // Click sound
    public AudioSource _clickSound;

    void Awake()
    {
        // Remember old volume
        volumeMemory = PlayerPrefs.GetFloat("volume");
    }

    void Start()
    {
        volSlider.GetComponent<Slider>().value = volumeMemory;
        audioMixer.SetFloat("volume", volumeMemory);

        // Reset menu for dev
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        //Pause Game
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }

        // Always display logic
        if (NewCamScript._gaming)
        {
            _alwaysDisplay.SetActive(true);
        }
        else
        {
            _alwaysDisplay.SetActive(false);
        }
    }

    public void PauseGame()
    {
        _clickSound.Play();
        if (!_gamePaused)
        {
            _gamePaused = true;
            pauseMenu.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            _gamePaused = false;
            pauseMenu.SetActive(false);

            if (_player.activeSelf)
            {
                Time.timeScale = PlayerScript._gameSpeed;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void MenuButton()
    {
        _clickSound.Play();
        PlayerPrefs.SetInt("High Score", ScoreScript.highscore);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        _clickSound.Play();        
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
