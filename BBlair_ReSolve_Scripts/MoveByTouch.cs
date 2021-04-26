using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoveByTouch : MonoBehaviour
{

    [SerializeField] private GameObject VfxPrefab = null;

    public static NavMeshAgent thisAgent;
    private bool thisCanMove = true;

    private Vector3 thisTouchStart;

    [SerializeField] public GameObject thisCameraOrigin = null;
    private float RotationSpeed = 20.0f;
    private float thisHoldTimer = 0.0f;
    private float thisHoldDurration = 1.0f;
    private void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisCameraOrigin = GameObject.FindGameObjectWithTag("CameraRotate");

        thisHoldTimer = thisHoldDurration;
    }

     private void Update()
     {
         if (!thisCanMove)
         {
             if (Input.GetMouseButtonUp(0))
             {
                 thisCanMove = true;
                 print("Your good");
             }
         }

         if (Input.GetMouseButtonDown(0))
         {
             thisAgent.GetComponent<NavMeshAgent>().isStopped = false;
             RaycastHit aHit;
             Ray aRay = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (thisCanMove)
             {

                 if (Physics.Raycast(aRay, out aHit, Mathf.Infinity))
                 {
                     thisAgent.SetDestination(aHit.point);

                    Instantiate(VfxPrefab, aHit.point, Quaternion.identity);
                 }
             }


     }   }

     private void OnMouseDrag()
     {
         thisCanMove = false;
         print("MapMoving");
     }


  






}
