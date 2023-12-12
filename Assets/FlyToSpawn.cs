using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToSpawn : MonoBehaviour
{

    GameObject spawn;
    float dist = 0.2f;
    float killTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("spawn");
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        dist -= (dist - 0.01f) / 0.2f * Time.deltaTime;
        transform.position -= (transform.position - spawn.transform.position) / dist * Time.deltaTime;
    }
    private void OnDestroy()
    {
        spawn.GetComponent<Spawner>().ShowNew();
    }
}
