using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    MeshRenderer cubeMeshRender;
    [SerializeField][Range(0f, 1f)] float lerpTime;

    [SerializeField] Color myColor;

    void Start()
    {
        cubeMeshRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (NewCamScript._gaming)
        {
            cubeMeshRender.material.color = Color.Lerp(cubeMeshRender.material.color, myColor, lerpTime * Time.deltaTime);
        }
    }
}
