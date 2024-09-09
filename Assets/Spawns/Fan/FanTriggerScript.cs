using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTriggerScript : MonoBehaviour
{
    static public bool enteredFan;

    AudioSource _fanNoise;

    private void Start()
    {
        _fanNoise = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player" && PlayerScript.playerColor == "Yellow")
        {
            Debug.Log("Hit fan as yellow");

            //Get good transform and velocity
            if(PlayerScript.rb.position.y < gameObject.transform.position.y)
            {
                PlayerScript.rb.position = new Vector3(PlayerScript.rb.position.x, gameObject.transform.position.y, PlayerScript.rb.position.z);
            }

            if (PlayerScript.rb.position.x > 0)
            {
                PlayerScript.rb.velocity = new Vector3(-2, 13.5f, 0);
            }
            else
            {
                PlayerScript.rb.velocity = new Vector3(2, 13.5f, 0);
            }

            //Play fan sound
            _fanNoise.enabled = true;

            PlayerScript.playerControl = false;
            enteredFan = true;
            StartCoroutine(WaitingFun());
        }

    }
    IEnumerator WaitingFun()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("wait is over");
        PlayerScript.playerControl = true;
        enteredFan = false;
    }
}