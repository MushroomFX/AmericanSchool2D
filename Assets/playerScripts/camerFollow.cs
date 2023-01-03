using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 movePostition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePostition, ref velocity, damping);
    }
}
