using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrop : MonoBehaviour
{
    AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Play( float _pitch )
    {
        ac.pitch = _pitch;//0,5 - 1,5
        ac.Play();
    }
}
