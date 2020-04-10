using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    //newBlinking
    private Material matWhite;
    private Material matDefault;
    private Transform parentTrans;
    SpriteRenderer sr;

    //newLootDrop
    public GameObject itemToDrop;
    public GameObject deadSprite;

    void Awake()
    {
        currentHealth = startingHealth;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("getting collision");
        if (col.gameObject.tag == "Projectile")
        {
            currentHealth = currentHealth - 10;
            sr.material = matWhite;
            Invoke("ResetMaterial", 0.15f);
            //Debug.Log("killing stuff");
        }
        if (currentHealth <= 0)
        {
            //instantiate dead alien sprite
            GameObject tempItemSpawn2 = Instantiate(deadSprite, new Vector3(transform.position.x, transform.position.y-0.71f, transform.position.z), Quaternion.identity) as GameObject;
            tempItemSpawn2.transform.Rotate(0f, 0f, 90f);
            tempItemSpawn2.GetComponent<SpriteRenderer>().flipY = true;
            tempItemSpawn2.SetActive(true);
            //newLootDrop
            GameObject tempItemSpawn = Instantiate(itemToDrop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
 
            tempItemSpawn.SetActive(true);
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }

}

