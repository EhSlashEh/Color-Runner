using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class autoPlayScript : MonoBehaviour
{
    public Toggle thisToggle;

    void Start()
    {
        if (PlayerPrefs.HasKey("autoPlay"))
        {
            if (PlayerPrefs.GetInt("autoPlay") == 1)
            {
            thisToggle.isOn = PlayerPrefs.GetInt("autoPlay") == 1;
            }
            else
            {
                PlayerPrefs.SetInt("autoPlay", 0);
            }
        }
    }
}
