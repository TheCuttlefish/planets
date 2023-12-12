using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    GameObject spawner;
    GameObject endScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        endScreen = GameObject.Find("bg");
        spawner = GameObject.Find("spawn");
    }

    // Update is called once per frame
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawner.GetComponent<Spawner>().GameOver();
        endScreen.GetComponent<EndMenu>().GameOver();
        if(GameObject.Find("score")!= null)
        {
            GameObject.Find("final score").GetComponent<Text>().text = "SCORE: " +GameObject.Find("score").GetComponent<Score>().GetScore().ToString();
            GameObject.Find("score").SetActive(false);

        }
    }


    
        
   
}
