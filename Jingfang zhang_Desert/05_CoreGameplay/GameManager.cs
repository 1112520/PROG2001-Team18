using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }


 
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        AudioManager.StopAllMute();
        AudioManager.PlayAudio("Start");
    }
}
