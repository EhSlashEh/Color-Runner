using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonScript : MonoBehaviour
{

    public void Update()
    {
        if (NewCamScript._gaming || NewCamScript._beginGaming)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
