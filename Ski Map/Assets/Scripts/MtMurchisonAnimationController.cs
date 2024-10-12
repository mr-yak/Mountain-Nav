using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MtMurchisonAnimationController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject rig;
    public GameObject UI;

    private Vector3 previousCameraPos;

    private int cursor = 3;

    private readonly string[] Anims = new string[] {"ToGlac1","ToGlac2", "ToBackFace", "ToHut"};

    private bool exiting = false;
    void Start()
    {
        previousCameraPos = mainCamera.transform.position;
    }
    void Update()
    {
        if (Input.GetButtonDown("exit")){
            exiting = true;
            UI.SetActive(false);
            rig.transform.position = mainCamera.transform.position;
            rig.transform.localEulerAngles = mainCamera.transform.localEulerAngles;
            GetComponent<Animator>().Play("ToMenuScreen");
            Invoke(nameof(BackToMenu), 2f);
        }
        else if (Input.GetButtonDown("left") && (previousCameraPos == mainCamera.transform.position) && !exiting){
            cursor++;
            if (cursor == 4){
                cursor = 0;
            }
            GetComponent<Animator>().Play(Anims[cursor]);
        }
        else if (Input.GetButtonDown("right") && (previousCameraPos == mainCamera.transform.position) && !exiting){
            GetComponent<Animator>().Play(Anims[cursor] + "b");
            cursor--;
            if (cursor == -1){
                cursor = 3;
            }
        }
        previousCameraPos = mainCamera.transform.position;
    }
    void BackToMenu(){
        SceneManager.LoadScene("MountainSelectionMap");
    }
}
