using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private Collider _cloudCollider;
    private void Start()
    {
        _cloudCollider = GetComponent<Collider>();
    }
    void Update()
    {
        if (PlayerScript.Vec.y < 6.7498)
        {
            _cloudCollider.enabled = !_cloudCollider.enabled;
        }
    }
}
