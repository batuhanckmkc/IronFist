using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform cam, player, sideAngle, boxMachine;
    public Vector3 distancePlayer, distanceBoxMachine;


    private void Update()
    {
        cam.position = Vector3.Lerp(cam.position, player.position - distancePlayer, 1f);
        cam.LookAt(player);

        if(CollectFists.targetDetected == true)
        {
            cam.position = Vector3.Lerp(cam.position, sideAngle.position - distanceBoxMachine, 0.5f);
            cam.LookAt(boxMachine);
        }
    }
    private void FixedUpdate()
    {
        //cam.position = Vector3.Lerp(cam.position, player.position - distance, 1f);
        //cam.LookAt(player);
    }
}
