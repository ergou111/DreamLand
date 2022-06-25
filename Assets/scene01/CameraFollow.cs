using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//player
    public float smoothing;//smooth

    public Vector2 minPosition;//min move
    public Vector2 maxPosition;//max move

    
    // Start is called before the first frame update
    void Start()
    {
        GameController.CameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();//Get component tag
    }

    void FixedUpdate()
    {
        if(target != null)
        {
            if(transform.position != target.position)//if canmera and player is not in same place 
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }


    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
