using UnityEngine;
using UnityEngine.SceneManagement;

public class MtHuttAnimationController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject rig;
    private Vector3 previousCameraPos;
    private int cursor = 5;
    private readonly string[] Anims = new string[]{"ToSummitSix","ToSouthFace","ToTowersTriple","ToVirginMile","ToOverview", "ToBase"};
    private bool exiting = false;
    void Start(){
        previousCameraPos=mainCamera.transform.position;
    }
    void Update(){
        if (Input.GetButtonDown("exit")){
            exiting=true;
            rig.transform.position = mainCamera.transform.position ;
            rig.transform.localEulerAngles = mainCamera.transform.localEulerAngles;
            GetComponent<Animator>().Play("ToMenuScreen");
            Invoke(nameof(BackToMenu), 2f);
        }
        else if (Input.GetButtonDown("left") && (previousCameraPos==mainCamera.transform.position) && !exiting){
            cursor++;
            if (cursor==6){
                cursor=0;
            }
            GetComponent<Animator>().Play(Anims[cursor]);
        }
        else if (Input.GetButtonDown("right") && (previousCameraPos==mainCamera.transform.position) && !exiting){
            GetComponent<Animator>().Play(Anims[cursor]+"b");  
            cursor--;
            if (cursor==-1){
                cursor=5;
            }
        }
        previousCameraPos=mainCamera.transform.position;
    }
    void BackToMenu(){
        SceneManager.LoadScene("MountainSelectionMap");
    }
}
