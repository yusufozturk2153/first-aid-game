using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource source;
  
    void Start()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
