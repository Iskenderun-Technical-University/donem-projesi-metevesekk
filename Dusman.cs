using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Dusman : MonoBehaviour
{
    NavMeshAgent ajan;
    GameObject Hedef;
    public float health;
    public float DusmanDarbeGucu;
    OyunKontrolcu oyunKontrol;
    void Start()
    {
        ajan = GetComponent<NavMeshAgent>();
    }
    
    public void HedefBelirle(GameObject objem)
    {
        Hedef = objem;
    }
    
    void Update()
    {
        ajan.SetDestination(Hedef.transform.position);
    }

    public void DarbeAl(float DusmanDarbeGucu)
    {
        health -= DusmanDarbeGucu;

        if(health<=0)
        {
            oldun();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Masumlar"))
        {
            //oyunKontrol.DarbeAl(DusmanDarbeGucu);
            GameObject anaKontrol = GameObject.FindWithTag("anaKontrol");
            anaKontrol.GetComponent<OyunKontrolcu>().DarbeAl(DusmanDarbeGucu);
        }
    }
    void oldun()
    {
        Destroy(gameObject);
    }
}
