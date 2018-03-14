using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float speed = 1;
    public Transform target;

    private void LateUpdate()
    {
        Vector3 direction = (target.position - GetComponent<Camera>().transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);
        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * speed);
    }

}