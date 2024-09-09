using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailBalanceScript : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
        if (PlayerScript.rb.velocity.y < -0.5) 
        {
            if (col.gameObject.name == "Leg L" && PlayerScript.playerColor == "Blue")
            {
                PlayerScript.rb.velocity = new Vector3(-2f, 0, PlayerScript.rb.velocity.z);
                if (gameObject.name == "Rail 3")
                {
                    PlayerScript.rb.velocity = new Vector3(-4f, 0, PlayerScript.rb.velocity.z);
                }
            }
            if (col.gameObject.name == "Leg R" && PlayerScript.playerColor == "Blue")
            {
                PlayerScript.rb.velocity = new Vector3(2f, 0, PlayerScript.rb.velocity.z);
                if (gameObject.name == "Rail 3")
                {
                    PlayerScript.rb.velocity = new Vector3(4f, 0, PlayerScript.rb.velocity.z);
                }
            }
        }
        else
        {
            if (col.gameObject.name == "Leg L" && PlayerScript.playerColor == "Blue")
            {
                PlayerScript.rb.velocity = new Vector3(-2f, PlayerScript.rb.velocity.y, PlayerScript.rb.velocity.z);
                if (gameObject.name == "Rail 3")
                {
                    PlayerScript.rb.velocity = new Vector3(-4f, PlayerScript.rb.velocity.y, PlayerScript.rb.velocity.z);
                }
            }
            if (col.gameObject.name == "Leg R" && PlayerScript.playerColor == "Blue")
            {
                PlayerScript.rb.velocity = new Vector3(2f, PlayerScript.rb.velocity.y, PlayerScript.rb.velocity.z);
                if (gameObject.name == "Rail 3")
                {
                    PlayerScript.rb.velocity = new Vector3(4f, PlayerScript.rb.velocity.y, PlayerScript.rb.velocity.z);
                }
            }

        }

        //Test

    }
}



