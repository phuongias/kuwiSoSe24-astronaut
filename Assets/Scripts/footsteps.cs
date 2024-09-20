using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepSounds;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.A)) {
            footstepSounds.enabled = true;
        }
        else
        {
            footstepSounds.enabled= false;
        }
    }
}
