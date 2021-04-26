using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LightHouseON : MonoBehaviour
{
    [SerializeField] private Material lightHouseON = null;
    private MeshRenderer thisMeshRen= null;
    private bool thisSpin = false;
    [SerializeField] private float thisSpinRate = 60.0f;

    private bool thisCountDown;
    private float thisScreenTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisMeshRen = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thisSpin)
        {
            float aSpinAngle = thisSpinRate * Time.deltaTime;
            Vector3 aSpinVector = aSpinAngle * Vector3.up;

            this.transform.Rotate(aSpinVector);
        }

        if (thisCountDown)
        {
            
            if (thisScreenTimer > 0)
            {
                thisScreenTimer -= Time.deltaTime;
            }
            if (thisScreenTimer <= 0)
            {
                SceneManager.LoadScene("Won");
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject aOtherObject;

        aOtherObject = other.gameObject;

        MoveByTouch aCharacter;
        aCharacter = aOtherObject.GetComponent<MoveByTouch>();

        if(aCharacter != null)
        {
            thisMeshRen.material = lightHouseON;
            thisSpin = true;
            if (!thisCountDown)
            {
                thisScreenTimer = 2.0f;
                thisCountDown = true;
            }
            
            
        }
    }
}
