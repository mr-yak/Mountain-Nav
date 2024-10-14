using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtMurchisonLabel : MonoBehaviour
{
    public Transform main_camera;

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 180+main_camera.localEulerAngles.y, 0);
    }
}
