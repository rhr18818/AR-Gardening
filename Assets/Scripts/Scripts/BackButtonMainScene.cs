using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonMainScene : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(0);
    }
    
    
}
