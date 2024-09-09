using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpinScript : MonoBehaviour
{
    public static Vector3 _fanTriggerPosision;

    // Start is called before the first frame update
/*    void Start()
    {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        //rotate fan
        transform.Rotate(0, 0, 400 * Time.deltaTime); //rotate

        //Trigger Location
        _fanTriggerPosision = gameObject.transform.position;

    }
}
