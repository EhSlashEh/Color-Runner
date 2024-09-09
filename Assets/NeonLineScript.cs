using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonLineScript : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        moveSpeed = SpawnerScript._objectSpeedSet * 10;
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.back * moveSpeed) * Time.deltaTime; //move forward

        //Destroy when off screen
        if (gameObject.transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
