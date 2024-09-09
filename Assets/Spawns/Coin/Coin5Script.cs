using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin5Script : MonoBehaviour
{
    Color tempcolor;
    AudioSource _coinSound;
    bool _gotCoin;

    //Changing material of 5 coin
    [SerializeField] private Material _startingMaterial;
    [SerializeField] private Material _NewMaterial;



    void Start()
        {
        //Changing mat
        gameObject.GetComponent<MeshRenderer>().material = _startingMaterial;


        tempcolor = GetComponent<MeshRenderer>().material.color;
        _coinSound = GetComponent<AudioSource>();
        }

    void Update()
    {
        transform.Rotate(0, 0, 200 * Time.deltaTime); //rotate

        // move forward
        transform.position = transform.position + (Vector3.back * SpawnerScript._objectSpeedSet) * Time.deltaTime; //move forward

        // Destroy when off screen
        if (gameObject.transform.position.z < -25)
        { Destroy(gameObject); }

        if (tempcolor.a > 0 && _gotCoin) //if coin isn't deleted yet, make it fade
        {
            transform.position = transform.position + (Vector3.up * 1 / 2) * Time.deltaTime; //go up
            tempcolor = GetComponent<MeshRenderer>().material.color;
            tempcolor.a -= 0.9f * Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = tempcolor;

            if (tempcolor.a == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = _NewMaterial;
            _gotCoin = true;
            ScoreScript.score += 5;
            _coinSound.enabled = true;
        }
    }
}
