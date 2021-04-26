using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KodiMovement : MonoBehaviour
{
    [SerializeField] private float thisSpeed = 0.0f;
    [SerializeField] private Vector3 thisDirection = Vector3.zero;


    public GameObject thisObjectToRotate;
    private float thisPreviousValue;
    private float thisCurrentRotation;

    private Rigidbody thisRigidbody = null;



    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
        onMovement();
    }

    protected void onMovement()
    {
        Vector3 aDirection = Vector3.zero;
        Vector3 aRotation = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            aDirection = Vector3.forward;
            aRotation.y = 0;
            thisObjectToRotate.transform.rotation.eulerAngles.Equals(aRotation);
        }

        if (Input.GetKey(KeyCode.S))
        {
            aDirection = Vector3.back;
            aRotation.y = -90;
            thisObjectToRotate.transform.rotation.eulerAngles.Equals(aRotation);
        }

        if (Input.GetKey(KeyCode.D))
        {
            aDirection = aDirection + Vector3.right;
            aRotation.y = 90;
            thisObjectToRotate.transform.rotation.eulerAngles.Equals(aRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            aDirection = aDirection + Vector3.left;
            aRotation.y = 180;
            thisObjectToRotate.transform.rotation.eulerAngles.Equals(aRotation);
        }

        thisDirection = aDirection;

        Vector3 aVelocity = Vector3.zero;

        aVelocity = thisSpeed * thisDirection;

        thisRigidbody.velocity = aVelocity;
    }

    protected void OnTriggerEnter(Collider other)
    {
        GameObject aOtherObject;
        aOtherObject = other.gameObject;

    }

    protected void OnCollisionEnter(Collision collision)
    {
        GameObject aOtherObject;
        aOtherObject = collision.gameObject;

     
    }


}
