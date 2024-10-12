using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MountainOverlayController : MonoBehaviour
{
    public GameObject mountain;
    public GameObject[] Guis = new GameObject[] { };
    public GameObject LayerTitle;

    private int cursor = 0;

    public Material[] materials = new Material[] { };

    private readonly string[] layertitles = new string[] { "Press       to change layers", "Slope Aspect", "Avalanche Danger Guide", "Elevation", "Slope Angle"};

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ok"))
        {
            cursor++;
            if (cursor > 4)
            {
                cursor = 0;
            }
            LayerTitle.GetComponent<TextMeshProUGUI>().text = layertitles[cursor];
            mountain.GetComponent<MeshRenderer>().material = materials[cursor];
            for(int i = 0; i<=4; i++) {
                if (i == cursor)
                {
                    Guis[i].SetActive(true);
                }
                else if (i != cursor)
                {
                    Guis[i].SetActive(false);
                }

            }

        }
    }
}
