using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Color tempcolor;

    // Start is called before the first frame update
    void Start()
    {
        tempcolor = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * 1/2) * Time.deltaTime; //go up
        transform.Rotate(0, 0, 400 * Time.deltaTime); //rotate

        if (tempcolor.a > 0) //if coin isn't deleted yet, make it fade
        {
            tempcolor = GetComponent<MeshRenderer>().material.color;
            tempcolor.a -= 0.5f * Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = tempcolor;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
