using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5f;

    [SerializeField]
    private float maxApproachAngle = 45f;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
    Vector3 currentNormal = Vector3.zero;
	void FixedUpdate ()
    {  
        Ray ray = new Ray(transform.position, -transform.up);  
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            float angle_between = Vector3.Angle(hit.normal, currentNormal);
            if (angle_between <= maxApproachAngle)
            {
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

                if (Input.GetButton("Right"))
                {
                    rigidBody.MovePosition(rigidBody.position + (transform.right * Speed));
                }
                else if (Input.GetButton("Left"))
                {
                    rigidBody.MovePosition(rigidBody.position + (-transform.right * Speed));
                }
            }
            currentNormal = hit.normal;
        }  
    }
}
