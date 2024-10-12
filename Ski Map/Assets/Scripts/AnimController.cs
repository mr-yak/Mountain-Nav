using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimController : MonoBehaviour
{
   
    public GameObject mainCamera;
    
    [HideInInspector]
    public GameStateManager gameState;
    public GameObject GameStateObject;

    void Start(){
        GameStateObject = GameObject.FindGameObjectsWithTag("GameState")[0];
        gameState = GameStateObject.GetComponent<GameStateManager>();
        if(gameState.inMtHutt){
            GetComponent<Animator>().Play("MtHuttScreenWipeExit");
        }
        else if(gameState.inMtMurchison)
        {
            GetComponent<Animator>().Play("MtMurchisonScreenWipeExit");
        }     
        gameState.inMtHutt = false;
        gameState.inMtMurchison = false;
    }

    void Update()
    {
        if ((Input.GetButtonDown("left")|| Input.GetButtonDown("right")) && (mainCamera.transform.position == new Vector3(-0.59f,1f,-1.44f)))
        {
            GetComponent<Animator>().Play("ToMtHutt");
        }
        else if ((Input.GetButtonDown("right") || Input.GetButtonDown("right")) && (mainCamera.transform.position == new Vector3(-1.12f,0.9f, -0.61f)))
        {
            GetComponent<Animator>().Play("ToMtMurchison");
        }
        if(Input.GetButtonDown("ok") && (mainCamera.transform.position == new Vector3(-1.12f, 0.9f, -0.61f)))
        {
            gameState.inMtHutt = true;
            GetComponent<Animator>().Play("MtHuttScreenWipeEntry");
            Invoke(nameof(MtHutt), 2f);
        }
        else if(Input.GetButtonDown("ok") && (mainCamera.transform.position == new Vector3(-0.59f, 1f, -1.44f)))
        {
            gameState.inMtMurchison = true;
            GetComponent<Animator>().Play("MtMurchisonScreenWipeEntry");
            Invoke(nameof(MtMurchison), 2f);
        }
    }

    void MtHutt()
    {
        SceneManager.LoadScene("MtHutt", LoadSceneMode.Single);
    }
    void MtMurchison()
    {
        SceneManager.LoadScene("MtMurchison(Backcountry)", LoadSceneMode.Single);
    }
}
