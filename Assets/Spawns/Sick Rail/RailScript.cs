using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RailScript : MonoBehaviour
{
    private float moveSpeed;
    
    public static Vector3 _railStart;
    public static Vector3 _railLast;

    void Start()
    {
        moveSpeed = SpawnerScript._objectSpeedSet;
    }

    void Update()
    {
        //Move rail prefab forward
        transform.position = transform.position + (Vector3.back * moveSpeed) * Time.deltaTime; //move forward

        //Destroy when off screen
        if(gameObject.transform.position.z < -25)
        {Destroy(gameObject);}

        //What is starting rail transform?
        _railStart = gameObject.transform.Find("Rail Start").gameObject.transform.position;
        _railLast = gameObject.transform.Find("Rail Final").gameObject.transform.position;
    }
}