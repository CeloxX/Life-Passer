using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{    
    void Start()
    {
        FindObjectOfType<LevelManager>().SplashScreenLoad();        
    }    
}
