using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject entityToFollow;

    void LateUpdate()
    {
        Vector3 vectorOffset = new Vector3(0, 0, -10); 
        transform.position = entityToFollow.transform.position + vectorOffset;
    }
}