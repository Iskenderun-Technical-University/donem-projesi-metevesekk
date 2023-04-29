using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kovan : MonoBehaviour
{
    public AudioSource yereDusmeSesi;

    float lifetime = 0.2f;

    private void OnEnable()
    {
    Destroy(this, lifetime);
    }
    void Start()
    {
        yereDusmeSesi = GetComponent<AudioSource>();
        Destroy(gameObject,lifetime);

    }

    private void OnCollisionEnter(Collision collision) 
    {
        
        if(collision.gameObject.CompareTag("Yol"))
        {
            yereDusmeSesi.Play();

            if(!yereDusmeSesi.isPlaying)
            {
                Destroy(gameObject,1f);
            }
        }
    }

    void Update()
    {
        
    }
}
