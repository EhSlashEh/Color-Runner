using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickTrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            foreach (Transform child in transform)
            {
                //child.gameObject.SetActive(true);               
            }
            Debug.Log("hit");
        }
    }
}
