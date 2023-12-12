using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndMenu : MonoBehaviour
{

    float timer = 0f;
    bool gameOver = false;
    public List<CanvasGroup> items = new List<CanvasGroup>();
    // Start is called before the first frame update
    void Awake()
    {


        foreach (var item in items) item.alpha = 0;
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            if (timer < 1f)
            {
                timer += Time.deltaTime;
                foreach(var item in items) item.alpha = timer;

            }
        }
        
    }
}
