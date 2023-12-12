using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleNext : MonoBehaviour
{
    float scale = 1f;

    public void StartScale()
    {
        scale = 0f;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        if(scale < 1)
        {
            scale += Time.deltaTime;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            scale = 1;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        
    }
}
