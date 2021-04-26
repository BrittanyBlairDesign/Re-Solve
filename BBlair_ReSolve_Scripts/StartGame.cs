using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{

    public void SceneLoader(int SceneIndex)
    {
        
        SceneManager.LoadScene("Kodi");
    }

    public void OnInstruction()
    {
        SceneManager.LoadScene("Controls");
    }

}
