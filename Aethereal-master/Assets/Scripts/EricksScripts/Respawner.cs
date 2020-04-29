using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawner : MonoBehaviour
{
    
    private GameObject respawn;
    public int playerScore;
    //STORING PLATFORMS
    List<Vector3> platformPos = new List<Vector3>();


    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 10;

    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        //STORING PLATFORMS
        StorePlatforms();

        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        //scoreText.text = playerScore.ToString("D4");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(10);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }

    }

    public void Respawn()
    {
        //RESETTING PLATFORMS
        Debug.Log("entered");
        ResetPlatforms();
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        
    }
    //RESETTING PLATFORMS
    public void StorePlatforms()
    {
        List<GameObject> objs = new List<GameObject>();
        objs.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        foreach(GameObject platform in objs)
        {
            platformPos.Add(platform.transform.position);
        }
    }
    public void ResetPlatforms()
    {
        List<GameObject> objs = new List<GameObject>();
        objs.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        int i = 0;
        foreach (GameObject platform in objs)
        {           
            platform.transform.position = platformPos[i];
            platform.GetComponent<Rigidbody2D>().isKinematic = true;
            platform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            platform.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            i++;
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddPoints(int amount)
    {
        playerScore += amount;
        scoreText.text = playerScore.ToString();
    }

}

