using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        moveSpeed = SpawnerScript._objectSpeedSet;

    }

    void Update()
    {
        //Move fan prefab forward
        transform.position = transform.position + (Vector3.back * moveSpeed) * Time.deltaTime; //move forward

        //Destroy when off screen
        if (gameObject.transform.position.z < -35)
        {
            Destroy(gameObject);
        }
    }
}
