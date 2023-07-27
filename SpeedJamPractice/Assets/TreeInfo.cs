using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo : MonoBehaviour
{
    bool isActiveTree;
    public Transform SpawnLocation;
    public float scaleRate = 1.1f;
    Vector3 baseScale = Vector3.one;

    public void SetAsActive(bool isActive)
    {
        isActiveTree = isActive;
    }

    private void Update()
    {
        if (isActiveTree)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.localScale += transform.localScale * (scaleRate * Time.deltaTime); //fixedUpdate or lateUpdate since it's got a rigidbody and we're doing scale?
            }
        }
    }


    public Vector3 GetSpawnLocation()
    {
        return SpawnLocation.position;
    }




}
