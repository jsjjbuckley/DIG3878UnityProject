using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;

    public void ControlClick()
    {
        panel.SetActive(true);
        button.SetActive(false);


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
