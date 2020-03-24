using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    private void Start()
    {
        loadnext();
    }
    private void loadnext()
    {
        StartCoroutine(ActivationRoutine());
    }
    private IEnumerator ActivationRoutine()
    {

        //wait a second
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);


    }
}
