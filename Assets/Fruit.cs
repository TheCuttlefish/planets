using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject spawn;
    public int fruitNum;
    public int number;
    bool matched = false;
    GameObject bounceSound;
    Rigidbody2D rb;
    bool firstTouch = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawn = GameObject.Find("spawn");
        number = spawn.GetComponent<Spawner>().number;
        bounceSound = GameObject.Find("bounceSound");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "fruit") return;

        if (!firstTouch) bounceSound.GetComponent<PlayDrop>().Play(1 + (float)(10 - fruitNum) / 10);
        firstTouch = true;
        
        
        if (collision.gameObject.GetComponent<Fruit>().fruitNum == fruitNum )
        {
            if (collision.gameObject.GetComponent<Fruit>().matched || matched) return; // if both objects are not matched
            matched = true;// match this object
            
            if (number > collision.gameObject.GetComponent<Fruit>().number)
            {
               // print(fruitNum);
                spawn.GetComponent<Spawner>().Merge(fruitNum, (transform.position + collision.transform.position) / 2);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                
            }
        }
    }
}
