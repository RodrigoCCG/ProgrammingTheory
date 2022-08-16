using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    private float cameraHeight = 10;

    void Update(){
        AdjustHeight();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }
    
    // ABSTRACTION
    private void AdjustHeight(){
        cameraHeight -= Input.mouseScrollDelta.y;
        if(cameraHeight > 15) cameraHeight = 15;
        if(cameraHeight < 5) cameraHeight = 5;
    }

    private void FollowPlayer(){
        transform.position = playerRef.transform.position + Vector3.up * cameraHeight;
    }
}
