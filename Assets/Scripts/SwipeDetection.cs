using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Player player;
    private Vector2 startPos;
    public int pixelDistToDetect = 20;
    private bool FingerDown;

    private void Update()
    {
        if (FingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            FingerDown = true;
        }
        if (FingerDown )
        {
            // did we swipe up?
            if(Input.touches[0].position.y >= startPos.y + pixelDistToDetect) 
            {
                FingerDown = false;
                player.Move(Vector3.up);
            }
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                FingerDown = false;
                player.Move(Vector3.left);
            }
            else if (Input.touches[0].position.x  >= startPos.x + pixelDistToDetect)
            {
                FingerDown = false;
                player.Move(Vector3.right);
            }
        }
        if (FingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            FingerDown = false;
        }

        
    }
}
