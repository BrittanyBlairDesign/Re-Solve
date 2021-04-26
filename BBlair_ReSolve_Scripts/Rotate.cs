using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Rotate : MonoBehaviour
{
    // Select rotating Object and slider
    public GameObject thisObjectToRotate;
    public Slider thisSlider;
    public Vector3 thisDirection;

    [SerializeField] public GameObject thisCameraOrigin = null;
    private float RotationSpeed = 20.0f;
    private float thisHoldTimer = 0.0f;
    private float thisHoldDurration = 1.0f;

    private bool thisRotateRight = false;
    private bool thisRotateLeft = false;
    private void Start()
    {
        thisCameraOrigin = GameObject.FindGameObjectWithTag("CameraRotate");

        thisHoldTimer = thisHoldDurration;
    }

    float distance = 10;


    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    private GameObject playerCharacter = null;

    private Button aTurnButton = null;

    // Preserve the original and current orientation
    public float thisPreviousValue;

    /*void Awake()
    {
        // Assign a callback for when this slider changes
        this.thisSlider.onValueChanged.AddListener(this.OnSliderChanged);

        // And current value
        this.thisPreviousValue = this.thisSlider.value;

    }

    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.thisPreviousValue;
        this.thisObjectToRotate.transform.Rotate(Vector3.up * delta * 360);

        // Set our previous value for the next change
        this.thisPreviousValue = value;
    }*/

    private void Update()
    {
        if (thisRotateRight)
        {
            float aTurnDirection;

            aTurnDirection = -20.0f;

            float aTurnAngle = RotationSpeed * aTurnDirection * Time.deltaTime;

            // Calculate the turn vector from the turn angle.

            Vector3 aTurnVector = aTurnAngle * Vector3.up;

            // You have to tell Unity to rotate a thing
            // to actually turn the thing to the left or right.

            thisCameraOrigin.gameObject.transform.Rotate(aTurnVector);

            thisHoldTimer = thisHoldDurration;
        }

        if (thisRotateLeft)
        {
            float aTurnDirection;

            aTurnDirection = 20.0f;

            float aTurnAngle = RotationSpeed * aTurnDirection * Time.deltaTime;

            // Calculate the turn vector from the turn angle.

            Vector3 aTurnVector = aTurnAngle * Vector3.up;

            // You have to tell Unity to rotate a thing
            // to actually turn the thing to the left or right.

            thisCameraOrigin.gameObject.transform.Rotate(aTurnVector);

            thisHoldTimer = thisHoldDurration;
        }
    }


    private void OnMouseDrag()
    {
        /*
        float RotX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
        RotX = RotX / 20;
        transform.RotateAround(Vector3.up, -RotX);
        /*
        float TransY = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;
        TransY = TransY / 50;
        transform.RotateAround(Vector3.right, TransY);

          Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
          transform.Translate(0, -touchDeltaPosition.y * RotationSpeed, 0);

          transform.position = new Vector3(
              Mathf.Clamp(transform.position.x, -35.0f, 25.0f),
              Mathf.Clamp(transform.position.y, 0.0f, 190.0f),
              Mathf.Clamp(transform.position.z, -35.0f, 25.0f)
              );*/

    }

    public void onRotateLeft()
    {

        thisRotateLeft = true;

    }


    public void onRotateRight()
    {

        thisRotateRight = true;


    }

    public void RButtonup()
    {
        thisRotateRight = false;
    }

    public void LButtonup()
    {
        thisRotateLeft = false;
    }


}
