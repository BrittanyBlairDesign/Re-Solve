using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private GameObject thisTeleportLocation = null;

    //AllDoorsGameObjects
    [SerializeField] private GameObject thisL1FrontDoor = null;
    [SerializeField] private GameObject thisL1BackDoor = null;
    [SerializeField] private GameObject thisL1SideDoor = null;
    [SerializeField] private GameObject thisL2FrontDoor = null;
    [SerializeField] private GameObject thisL2BackDoor = null;
    [SerializeField] private GameObject thisL2SideDoor = null;
    [SerializeField] private GameObject thisL3SideDoor = null;
    [SerializeField] private GameObject thisL3FrontDoor = null;
    [SerializeField] private GameObject thisL4BackDoor = null;
    [SerializeField] private GameObject thisL4SideDoor = null;
    [SerializeField] private GameObject thisL5TopDoor = null;

    //DoorBooleans
    [SerializeField] private bool Levle1Front = false;
    [SerializeField] private bool Level1Back = false;
    [SerializeField] private bool Level1Side = false;
    [SerializeField] private bool Level2Front = false;
    [SerializeField] private bool Level2Back = false;
    [SerializeField] private bool Level2Side = false;
    [SerializeField] private bool Level3Front = false;
    [SerializeField] private bool Level3Side = false;
    [SerializeField] private bool Level4Side = false;
    [SerializeField] private bool Level4Back = false;
    [SerializeField] private bool Level5Top = false;


    //DoorSwitchBooleans
    [SerializeField] public bool MasterResetSwitch = false;

    [SerializeField] public bool Level1GroundSwitchFor2ndFloor = false;
    [SerializeField] public bool Level1SideSwitchForFrontDoor = false;
    [SerializeField] public bool Level2BackDoorSwitch = false;
    [SerializeField] public bool Level2FrontDoorSwitch = false;
    [SerializeField] public bool thisS3Switch = false;
    [SerializeField] public bool thisS4Switch = false;
    [SerializeField] public bool thisB4Switch = false;


    //MeshRenderers and colors
    private MeshRenderer thisMeshRenderer = null;

    //Colors
    [SerializeField] private Material thisGreenDoor = null;
    [SerializeField] private Material thisPurpleDoor = null;
    [SerializeField] private Material thisyellowDoor = null;
    [SerializeField] private Material ThisOrangeDoor = null;
    [SerializeField] private Material ThisRedDoor = null;

    //Timers
    [SerializeField] private float thisWaitTimer = 0.0f;
    [SerializeField] private float thisWaitDurration = 5.0f;


    //[SerializeField] private GameObject thisGlowCube = null;
    // [SerializeField] private Material TeleportMaterial = null;
    //[SerializeField] private Material TransparentMaterial = null;

    [SerializeField] private bool thisBlockPath = false;
    private bool thisCanTeleport = false;

    [SerializeField] private GameObject thisCharacterPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        thisWaitTimer = thisWaitDurration;
        thisMeshRenderer = GetComponent<MeshRenderer>();


        
       // thisCubeRenderer = thisGlowCube.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (thisCanTeleport)
        {
            if (thisWaitTimer > 0)
            {
                thisWaitTimer -= Time.deltaTime;
            }
        }
         // Level 1 doors
        if (Level1Back)
        {

            if (thisS3Switch)
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }
            else
            {
                thisTeleportLocation = thisL2BackDoor;
                thisMeshRenderer.material = thisGreenDoor;
            }
        }
        

     

        if (Level1Side)
        {



            if (Level2BackDoorSwitch)
            {
                thisTeleportLocation = thisL2BackDoor;

                thisMeshRenderer.material = thisyellowDoor;
                thisBlockPath = false;
            }
            else
            {
                thisMeshRenderer.material = ThisRedDoor;
                thisBlockPath = true;
            }
            

            
        }

        if (Levle1Front)
        {
            if (Level1SideSwitchForFrontDoor)
            {
                thisBlockPath = false;
                thisTeleportLocation = thisL2FrontDoor;
                thisMeshRenderer.material = ThisOrangeDoor;
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }
        }

        // Level 2 Doors 

        if (Level2Back)
        {
            if (Level2BackDoorSwitch)
            {
                thisTeleportLocation = thisL1SideDoor;
                thisMeshRenderer.material = thisyellowDoor;
                thisBlockPath = false;
            }
            else
            if (thisS3Switch)
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;

                Level2BackDoorSwitch = false;

            }
            else
            {
                thisTeleportLocation = thisL1BackDoor;
                thisMeshRenderer.material = thisGreenDoor;
                thisBlockPath = false;
            }
        }


        if (Level2Side)
        {
            if (thisS3Switch)
            {
                thisMeshRenderer.material = ThisRedDoor;

                thisBlockPath = true;

            }
            else
            if (Level1GroundSwitchFor2ndFloor)
            {
                thisTeleportLocation = thisL3SideDoor;
                thisMeshRenderer.material = thisPurpleDoor;

                thisBlockPath = false;
            }
            else
            if (thisB4Switch)
            {
                thisTeleportLocation = thisL4BackDoor;
                thisMeshRenderer.material = thisGreenDoor;
                thisBlockPath = false;
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }

        }

        if (Level2Front)
        {
            if (Level1SideSwitchForFrontDoor)
            {
                thisMeshRenderer.material = ThisOrangeDoor;
                thisTeleportLocation = thisL1FrontDoor;
                thisBlockPath = false;
            }
            else
            if (Level2FrontDoorSwitch)
            {
                if (thisB4Switch)
                {
                    thisTeleportLocation = thisL3FrontDoor;
                    thisBlockPath = false;
                }
                else
                {
                    thisBlockPath = true;
                }
                thisMeshRenderer.material = ThisOrangeDoor;
  
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }
        }

        // Level 3 Doors

        if (Level3Side)
        {
            if (thisS3Switch)
            {
                thisTeleportLocation = thisL4BackDoor;
                thisMeshRenderer.material = thisGreenDoor;

                thisBlockPath = false;

            }
            else
            if (Level1GroundSwitchFor2ndFloor)
            {
                thisTeleportLocation = thisL2SideDoor;
                thisMeshRenderer.material = thisPurpleDoor;
                thisBlockPath = false;
            }
            else
            if (thisB4Switch)
            {
                thisTeleportLocation = thisL4SideDoor;
                thisMeshRenderer.material = thisyellowDoor;

                thisBlockPath = false;
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }


        }

        if (Level3Front)
        {
            if (Level2FrontDoorSwitch)
            {
                thisMeshRenderer.material = ThisOrangeDoor;
                thisTeleportLocation = thisL2FrontDoor;
                thisBlockPath = false;
            }
            else
            if (thisS4Switch)
            {
                thisMeshRenderer.material = thisPurpleDoor;
                thisTeleportLocation = thisL5TopDoor;
                thisBlockPath = false;
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }
        }

        if(Level4Back)
        {
            thisBlockPath = true;
            thisMeshRenderer.material = ThisRedDoor;

            if (thisS3Switch)
            {
                thisTeleportLocation = thisL3SideDoor;
                thisMeshRenderer.material = thisGreenDoor;

                thisBlockPath = false;
            }
            else
            if (thisB4Switch)
            {
                thisTeleportLocation = thisL2SideDoor;
                thisMeshRenderer.material = thisGreenDoor;

                thisBlockPath = false;
            }

        }


        if (Level4Side)
        {
            if (Level2FrontDoorSwitch)
            {
                thisMeshRenderer.material = thisyellowDoor;
                thisTeleportLocation = thisL3SideDoor;
                thisBlockPath = false;
            }
            else
            {
                thisMeshRenderer.material = ThisRedDoor;
                thisBlockPath = true;
            }
        }

        if (Level5Top)
        {
            if (thisS4Switch)
            {
                thisMeshRenderer.material = thisPurpleDoor;
                
            }
            else
            {
                thisBlockPath = true;
                thisMeshRenderer.material = ThisRedDoor;
            }
        }
    }


    protected void OnTriggerStay(Collider other)
    {
        GameObject aOtherObject;

        aOtherObject = other.gameObject;

        MoveByTouch aCharacter;

        aCharacter = aOtherObject.GetComponent<MoveByTouch>();

        if (aCharacter != null)
        {

            if (thisBlockPath)
            {
               
            }
            else
            {
                if (thisWaitTimer > 0)
                {
                    thisCanTeleport = true;


                    //thisCubeRenderer.material = TeleportMaterial;

                }

                if (thisWaitTimer <= 0)
                {

                    print("Its a hit\n");


                    aCharacter.gameObject.SetActive(false);

                    Instantiate(thisCharacterPrefab, thisTeleportLocation.transform.position, Quaternion.identity);

                    thisCanTeleport = false;
                    thisWaitTimer = thisWaitDurration;
                    // thisCubeRenderer.material = TransparentMaterial;

                }
            }

           

        }

    }

    protected void OnTriggerExit(Collider other)
    {
        GameObject aOtherObject;

        aOtherObject = other.gameObject;

        MoveByTouch aCharacter;

        aCharacter = aOtherObject.GetComponent<MoveByTouch>();

        if (aCharacter != null)
        {
            thisCanTeleport = false;
            thisWaitTimer = thisWaitDurration;
           // thisCubeRenderer.material = TransparentMaterial;
        }
    }
}
