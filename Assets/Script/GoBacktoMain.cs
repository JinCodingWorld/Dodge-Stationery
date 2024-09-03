using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GoBacktoMain : MonoBehaviour
{

    void Start()
    {

    }

    public void GoBackMain()
    {
        SceneManager.LoadScene(0); 
    }

   
    void Update()
    {
        
    }
}

