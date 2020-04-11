using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.Find("Player").GetComponent<Player_Health_Seg_Shield_Ez>().playerScore == 100)
        {
            SceneManager.LoadScene(3);
        }
        

    }

 


}
