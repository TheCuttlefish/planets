using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    #region My Variables
    public List<GameObject> planets = new List<GameObject>();
    public GameObject nextFruitList;
    public GameObject nextOnSpawner;
    public int number = 0;
    private float xInput;
    private bool canShoot = true;
    private int currentFruit, nextFruit;
    public GameObject score;
    public ParticleSystem glowEffect;
    public List<Text> allPlanetScores = new List<Text>();
    public List<int> allScores = new List<int>(11);
    float shootTimeout = 0;
    public SpriteRenderer arrow;// arrow for shooting
    public Gradient arrowColours = new Gradient();
    bool gameOver = false;
    #endregion

    #region Unity Methods
    private void Start()
    {
        
        SetNext();
        SetNext();// do it 2 time to set the current fruit to a number from nextFruit
    }
    void Update()
    {
        RestartButton();
        if (gameOver) return;//stop game on game over!!
        Movement();
        Shoot();
    }
    #endregion

    #region My Methods
    public void RestartButton()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }
    void Movement()
    {
        xInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(xInput * 20 * Time.deltaTime, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -14, 14), transform.position.y, 0);
    }
    public void ShowNew()
    {
        nextOnSpawner.transform.GetChild(currentFruit).gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void SetNext()
    {

        currentFruit = nextFruit;
        //flying planet
        GameObject _new = Instantiate(nextFruitList.transform.GetChild(nextFruit), nextFruitList.transform.position, Quaternion.identity).gameObject;
        _new.AddComponent<FlyToSpawn>();


        //-- end flying planet
        //on spawner hint
        for (int i = 0; i < nextOnSpawner.transform.childCount; i++) nextOnSpawner.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //showNew function is now showing this!

        //side hint
        for (int i = 0; i < nextFruitList.transform.childCount; i++)nextFruitList.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        nextFruit = Random.Range(0, 5);
        nextFruitList.GetComponent<ScaleNext>().StartScale();
        nextFruitList.transform.GetChild(nextFruit).gameObject.GetComponent<SpriteRenderer>().enabled = true;

        
       
    }


    void DebugSpawn(int _planet, KeyCode _key)
    {
        if (Input.GetKeyDown(_key))
        {
            Instantiate(planets[_planet], transform.position, Quaternion.identity);
            number++;
        }
    }


    public void GameOver()
    {
        gameOver = true;
    }

    void Shoot()
    {



        DebugSpawn(10, KeyCode.Alpha1);
        DebugSpawn(9, KeyCode.Alpha2);
        DebugSpawn(8, KeyCode.Alpha3);
        DebugSpawn(7, KeyCode.Alpha4);
        DebugSpawn(6, KeyCode.Alpha5);
        DebugSpawn(5, KeyCode.Alpha6);
        DebugSpawn(4, KeyCode.Alpha7);
        DebugSpawn(3, KeyCode.Alpha8);
        DebugSpawn(2, KeyCode.Alpha9);
        DebugSpawn(1, KeyCode.Alpha0);



        if (!canShoot)
        {

            
            shootTimeout += Time.deltaTime*1.4f;
            arrow.color = arrowColours.Evaluate(shootTimeout);
            if(shootTimeout > 1)
            {
                shootTimeout = 0;
                canShoot = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GetComponent<AudioSource>().pitch = Random.Range(2f, 3f);
            GetComponent<AudioSource>().Play();
            arrow.color = arrowColours.Evaluate(0);
            Instantiate(planets[currentFruit], transform.position, Quaternion.identity);
            canShoot = false;
            number++;
            SetNext();
        }
    }
    public void Merge( int _fruit, Vector3 _pos)
    {
        score.GetComponent<Score>().AddScore(_fruit);

        if (_fruit < planets.Count) Instantiate(planets[_fruit], _pos, Quaternion.identity);
        ParticleSystem p = Instantiate(glowEffect, _pos, Quaternion.identity);
        p.startSize = 0.3f + _fruit * 0.36f;
        allScores[_fruit - 1] += 1;
        allPlanetScores[_fruit - 1].text = allScores[_fruit - 1].ToString() + " x";
        number++;
    }
    #endregion
}
