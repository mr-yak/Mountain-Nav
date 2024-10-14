using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public bool inMtHutt;
    public bool inMtMurchison;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        Invoke("ExitScene", 0.5f);
    }
    void ExitScene(){
        SceneManager.LoadScene("MountainSelectionMap");
    }
}
