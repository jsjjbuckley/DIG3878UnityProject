using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Seg_Shield_Ez : MonoBehaviour
{
    
    private GameObject respawn;

    public int playerScore;
    //NEW
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
   
    //STORING PLATFORMS
    List<Vector3> platformPos = new List<Vector3>();


    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 10;
    [Tooltip("The amount of points a player loses on death.")]
    public int deathPenalty = 0;

    public Text scoreText;


    public GameObject[] lifeArr;
    public GameObject[] shieldArr;



    private int maxLife;
    private int maxShield;
    private int currLife;
    private int currShield;

    // Use this for initialization
    void Start()
    {
        //STORING PLATFORMS
        StorePlatforms();

        maxLife = lifeArr.Length;
        maxShield = shieldArr.Length;
        currShield = 0;
        currLife = maxLife;
        for (int i = 0; i < maxLife; i++)
        {
            lifeArr[i].SetActive(true);
        }
        for (int i = 0; i < maxShield; i++)
        {
            shieldArr[i].SetActive(false);
        }
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        //scoreText.text = playerScore.ToString("D4");

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            //NEW
            this.GetComponent<Animator>().SetBool("showDeathSprite", true);
           
         
            StartCoroutine(ActivationRoutine());
   



        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(10);
            AddShield();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
        else if (collision.CompareTag("Health"))
        {
            AddHealth();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Shield"))
        {
            AddShield();
            Destroy(collision.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    //NEW
    private IEnumerator ActivationRoutine()
    {

        //Freeze player to prevent detecting multiple deaths (and respawns)
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        //Disable key input for player (cuz it looks weird)
        GetComponent<Player_Move_Update>().enabled = false;
        //Turn on first gameObject.
        objectToActivate.SetActive(true);
        //Wait a second
        yield return new WaitForSeconds(1);
        //turn on other gameObject
        objectToActivate2.SetActive(true);
        //wait another second
        yield return new WaitForSeconds(1);
        //Make player react to physics and key input again (because they were disabled above)
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Player_Move_Update>().enabled = true;
        //turn off both gameObjects
        objectToActivate.SetActive(false);
        objectToActivate2.SetActive(false);
        //reset animation
        this.GetComponent<Animator>().SetBool("showDeathSprite", false);
        //make the homie respawn
        Respawn();

    }

    private void TakeDamage()
    {
        if (currShield > 0)
        {
            shieldArr[currShield - 1].SetActive(false);
            --currShield;
        }
        else
        {
            lifeArr[currLife - 1].SetActive(false);

            --currLife;
            if (currLife == 0)
            {
                Respawn();
            }
        }

    }

    private void AddHealth()
    {
        if (currLife < maxLife)
        {
            lifeArr[currLife].SetActive(true);
            ++currLife;
        }

    }

    private void AddShield()
    {
        if (currShield < maxShield)
        {
            shieldArr[currShield].SetActive(true);
            ++currShield;
        }
    }

    public void Respawn()
    {

        while (currLife < maxLife)
        {
            lifeArr[currLife].SetActive(true);
            ++currLife;
        }
        //RESETTING PLATFORMS
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

