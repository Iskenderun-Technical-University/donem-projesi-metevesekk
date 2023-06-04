using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi_Kutusu_Olustur : MonoBehaviour
{
     public List<GameObject> MermiKutusuNoktasi = new List<GameObject>();
    public GameObject Mermi_Kutusunun_Kendisi;
    public static bool Mermi_Kutusu_Varmi;
    public float MermiKutusu_Cikma_Frekansi;
    void Start()
    {
        StartCoroutine(Mermi_Kutusu_Yap());
        Mermi_Kutusu_Varmi = false;
    }

    IEnumerator Mermi_Kutusu_Yap()
    {
        while(true)
        {
        
            yield return null;
            if(!Mermi_Kutusu_Varmi) 
            {
                yield return new WaitForSeconds(MermiKutusu_Cikma_Frekansi);

                    int RandomSayi = Random.Range(0,5);
                    Instantiate(Mermi_Kutusunun_Kendisi,MermiKutusuNoktasi[RandomSayi].transform.position,MermiKutusuNoktasi[RandomSayi].transform.rotation);
                    Mermi_Kutusu_Varmi=true;
            }
        
        }
    }
}
