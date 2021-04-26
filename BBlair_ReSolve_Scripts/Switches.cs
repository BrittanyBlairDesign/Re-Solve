using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
                    //SWITCH BOOLS
    [SerializeField] public bool MasterResetSwitch = false;
    // Level 1 switches
    [SerializeField] public bool Level1GroundSwitchFor2ndFloor = false;
    [SerializeField] public bool Level1SideSwitchForFrontDoor = false;
    //Level 2 switches
    [SerializeField] public bool Level2BackDoorSwitch = false;
    [SerializeField] public bool Level2FrontDoorSwitch = false;
    //Level 3 Switches
    [SerializeField] public bool thisS3Switch = false;
    //Level 4 Switches
    [SerializeField] public bool thisS4Switch = false;
    [SerializeField] public bool thisB4Switch = false;

                    // SWITCH OBJECTS
    [SerializeField] public GameObject ResetSwitch = null;
    // Level 1 switches
    [SerializeField] public GameObject GroundSwitchFor2ndFloor = null;
    [SerializeField] public GameObject SideSwitchForFrontDoor = null;
    //Level 2 switches
    [SerializeField] public GameObject B2DoorSwitch = null;
    [SerializeField] public GameObject B2FrontDoorSwitch = null;
    //Level 3 Switches
    [SerializeField] public GameObject S3Switch = null;
    //Level 4 Switches
    [SerializeField] public GameObject S4Switch = null;
    [SerializeField] public GameObject B4Switch = null;

                    //DOOR OBJECTS
    //Level 1
    [SerializeField] public GameObject Level1BackDoor = null;
    [SerializeField] public GameObject Level1SideDoor = null;
    [SerializeField] public GameObject Level1Frontdoor = null;
    // Level 2
    [SerializeField] public GameObject Level2BackDoor = null;
    [SerializeField] public GameObject Level2Side = null;
    [SerializeField] public GameObject Level2FrontDoor = null;
    //Level 3
    [SerializeField] private GameObject Level3Front = null;
    [SerializeField] private GameObject Level3Side = null;
    //level 4
    [SerializeField] private GameObject Level4Side = null;
    [SerializeField] private GameObject Level4Back = null;
    //Level4
    [SerializeField] private GameObject Level5Top = null;

    //Mesh renderer
    private MeshRenderer thisMeshrenderer = null;

    //Materials
    [SerializeField] public Material thisEmmisiveSwitchBlue = null;
    [SerializeField] public Material thisSwitchBlue = null;

    private int SwitchHits = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisMeshrenderer = GetComponent<MeshRenderer>();
        thisMeshrenderer.material = thisSwitchBlue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject aOtherObject;

        aOtherObject = other.gameObject;

        MoveByTouch aCharacter;

        aCharacter = aOtherObject.GetComponent<MoveByTouch>();

        if (aCharacter != null)
        {
            if (SwitchHits == 1)
            {

                thisMeshrenderer.material = thisSwitchBlue;
            }

            if (SwitchHits == 0)
            {

                thisMeshrenderer.material = thisEmmisiveSwitchBlue;
            }

            if (Level1SideSwitchForFrontDoor)
            {
                if(SwitchHits == 0)
                {
                    Teleportation aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();

                    aTeleportation.Level1SideSwitchForFrontDoor = true;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = true;

                }

                if(SwitchHits ==1)
                {
                    Teleportation aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();

                    aTeleportation.Level1SideSwitchForFrontDoor = false;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = false;
                }

            }

            if (Level1GroundSwitchFor2ndFloor)
            {

                if(SwitchHits == 0)
                {
                    Teleportation aTeleportation = Level2Side.GetComponent<Teleportation>();

                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;
                    aTeleportation.thisS3Switch = false;

                    aTeleportation = Level3Side.GetComponent<Teleportation>();

                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;
                    aTeleportation.thisS3Switch = false;
                }

                if(SwitchHits == 1)
                {
                    Teleportation aTeleportation = Level2Side.GetComponent<Teleportation>();
                    aTeleportation.Level1GroundSwitchFor2ndFloor = false;

                    aTeleportation = Level3Side.GetComponent<Teleportation>();
                    aTeleportation.Level1GroundSwitchFor2ndFloor = false;

                }


            }

            if (Level2BackDoorSwitch)
            {
                print(SwitchHits);

                if (SwitchHits == 0)
                {
                    Teleportation aTeleportation = Level2BackDoor.GetComponent<Teleportation>();


                    aTeleportation.Level2BackDoorSwitch = true;

                    aTeleportation = Level1SideDoor.GetComponent<Teleportation>();
                    aTeleportation.Level2BackDoorSwitch = true;

                }

                if( SwitchHits == 1)
                {

                    Teleportation aTeleportation = Level2BackDoor.GetComponent<Teleportation>();


                    aTeleportation.Level2BackDoorSwitch = false;

                    aTeleportation = Level1SideDoor.GetComponent<Teleportation>();
                    aTeleportation.Level2BackDoorSwitch = false;

                }

            }

            if (Level2FrontDoorSwitch)
            {
                if(SwitchHits == 0)
                {

                    Switches aEffectedSwitch = B4Switch.GetComponent<Switches>();

                    if ( aEffectedSwitch.SwitchHits == 1)
                    {

                        Teleportation aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                        aTeleportation.Level2FrontDoorSwitch = true;
                        aTeleportation.Level1SideSwitchForFrontDoor = false;

                        aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();
                        aTeleportation.Level1SideSwitchForFrontDoor = false;

                        Switches aDifferentSwitch = SideSwitchForFrontDoor.GetComponent<Switches>();
                        aDifferentSwitch.SwitchHits = 0;

                        aTeleportation = Level3Front.GetComponent<Teleportation>();
                        aTeleportation.Level2FrontDoorSwitch = true;


                        aTeleportation = Level4Side.GetComponent<Teleportation>();
                        aTeleportation.Level2FrontDoorSwitch = true;
                    }

                }
                
                if(SwitchHits == 1)
                {
                    Teleportation aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();

                    aTeleportation.Level1SideSwitchForFrontDoor = true;
                    aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = true;
                }
            }


            if (thisS3Switch)
            {

                if (SwitchHits == 0)
                {
                    Switches aEffectedSwitch = GroundSwitchFor2ndFloor.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 0;

                    aEffectedSwitch = B2DoorSwitch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 0;

                    Teleportation aTeleportation = Level3Side.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = true;
                    aTeleportation.Level1GroundSwitchFor2ndFloor = false;
                    aTeleportation.thisB4Switch = false;

                    aTeleportation = Level2Side.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = true;
                    aTeleportation.Level1GroundSwitchFor2ndFloor = false;

                    aTeleportation = Level1BackDoor.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = true;

                    aTeleportation = Level2BackDoor.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = true;

                    aTeleportation = Level4Back.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = true;

                }

                if (SwitchHits == 1)
                {

                    Switches aEffectedSwitch = GroundSwitchFor2ndFloor.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 1;

                    aEffectedSwitch = B2DoorSwitch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 1;

                    Teleportation aTeleportation = Level3Side.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = false;
                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;
                    aTeleportation.thisB4Switch = false;

                    aTeleportation = Level2Side.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = false;
                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;

                    aTeleportation = Level1BackDoor.GetComponent<Teleportation>();

                    aTeleportation.thisS3Switch = false;

                    aTeleportation = Level2Side.GetComponent<Teleportation>();

                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;
                    aTeleportation.thisS3Switch = false;

                    aTeleportation = Level3Side.GetComponent<Teleportation>();

                    aTeleportation.Level1GroundSwitchFor2ndFloor = true;
                    aTeleportation.thisS3Switch = false;

                    aTeleportation = Level4Back.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = false;

                }

                
            }



            if (thisB4Switch)
            {
                if (SwitchHits == 0)
                {
                    Switches aEffectedSwitch = GroundSwitchFor2ndFloor.GetComponent<Switches>();
                    aEffectedSwitch = S3Switch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 0;

                    Teleportation aTeleportation = Level3Side.GetComponent<Teleportation>();
                    aTeleportation.thisB4Switch = true;
                    aTeleportation.thisS3Switch = false;

                    aTeleportation = Level4Back.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = false;
                    aTeleportation.thisB4Switch = true;

                    aTeleportation = Level2Side.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = false;
                    aTeleportation.thisB4Switch = true;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.thisB4Switch = true;
                }

                if(SwitchHits == 1)
                {
                    Switches aEffectedSwitch = GroundSwitchFor2ndFloor.GetComponent<Switches>();
                    aEffectedSwitch = S3Switch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 1;

                    Teleportation aTeleportation = Level3Side.GetComponent<Teleportation>();
                    aTeleportation.thisB4Switch = false;
                    aTeleportation.thisS3Switch = true;

                    aTeleportation = Level4Back.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = true;
                    aTeleportation.thisB4Switch = false;

                    aTeleportation = Level2Side.GetComponent<Teleportation>();
                    aTeleportation.thisS3Switch = true;
                    aTeleportation.thisB4Switch = false;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.thisB4Switch = false;
                }


            }

            if (thisS4Switch)
            {

                if(SwitchHits == 0)
                {
                    Switches aEffectedSwitch = B2FrontDoorSwitch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 0;

                    Teleportation aTeleportation = Level3Front.GetComponent<Teleportation>();
                    aTeleportation.thisS4Switch = true;
                    aTeleportation.Level2FrontDoorSwitch = false;

                    aTeleportation = Level5Top.GetComponent<Teleportation>();
                    aTeleportation.thisS4Switch = true;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = true;

                    aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = true;
                }
                
                if(SwitchHits == 1)
                {
                    Switches aEffectedSwitch = B2FrontDoorSwitch.GetComponent<Switches>();
                    aEffectedSwitch.SwitchHits = 1;

                    Teleportation aTeleportation = Level3Front.GetComponent<Teleportation>();
                    aTeleportation.thisS4Switch = false;

                    aTeleportation = Level5Top.GetComponent<Teleportation>();
                    aTeleportation.thisS4Switch = false;

                    aTeleportation = Level2FrontDoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = false;
                    aTeleportation = Level1Frontdoor.GetComponent<Teleportation>();
                    aTeleportation.Level1SideSwitchForFrontDoor = false;
                }

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject aOtherObject;

        aOtherObject = other.gameObject;

        MoveByTouch aCharacter;

        aCharacter = aOtherObject.GetComponent<MoveByTouch>();

        if(aCharacter != null)
        {
            if (SwitchHits == 0)
            {
                SwitchHits = 1;
            }
            else
            if (SwitchHits == 1)
            {
                SwitchHits = 0;
            }
        }
    }
}
