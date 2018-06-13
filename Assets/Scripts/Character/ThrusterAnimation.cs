using UnityEngine;
using System.Collections;

public class ThrusterAnimation : MonoBehaviour {
    private Animator Thrust;
   
    void Start()
    {
        Thrust = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("w"))
        {
            Thrust.SetTrigger("Thruster");
        }
        if (Input.GetKeyUp("w"))
        {
            Thrust.ResetTrigger("Thruster");
        }


    }

}

