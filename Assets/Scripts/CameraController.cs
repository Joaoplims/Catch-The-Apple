using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;



    private void Start()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* speed, Space.World);
    }

}
