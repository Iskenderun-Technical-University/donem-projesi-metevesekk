using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Silah : MonoBehaviour
{
    private const string StateName = "Taramalli";
    [Header ("AYARLAR")]
    public bool AtesEdebilirMi;
    float IceridenAtesEtmeFrekans;
    public float DisaridanAtesetmeFrekans;
    public float Menzil;
    
    [Header ("SESLER")]
    public AudioSource AtesSesi;
    public AudioSource MermiBitisSesi;
    public AudioSource MermiAlmaSesi;

    [Header ("EFEKTLER")]
    public ParticleSystem AtesEfekt;
    public ParticleSystem Mermiİzi;
    public ParticleSystem KanLekesi;

    [Header ("DİĞER")]
    public Camera POV;
    Animator animatorum;
    

    [Header ("SİLAH AYARLARI")]
    public int ToplamMermi;
    public int SarjorKapasite;
    public int KalanMermi;
    public TextMeshProUGUI ToplamMermiText;
    public TextMeshProUGUI KalanMermiText;
    public float DarbeGucu;

    public bool KovanCiksinMi;
    public GameObject KovanObje;
    public GameObject KovanCikisNoktasi;


    int KullanilanMermiSayisi;
    int ToplamDeger;
    

    void Start()
    {
        Yazdir();
        animatorum = GameObject.Find("Silah").GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(AtesEdebilirMi && Time.time>IceridenAtesEtmeFrekans && KalanMermi!=0)
            {
                AtesEt();
                IceridenAtesEtmeFrekans = Time.time + DisaridanAtesetmeFrekans;
            }

            if(KalanMermi==0)
            {
                MermiBitisSesi.Play();
            }
            
        }

        

        if(Input.GetKey(KeyCode.R))
        {
            if(KalanMermi < SarjorKapasite && ToplamMermi!=0)
            {
                if(KalanMermi!=0)
                {
                   SarjorDoldurmaTeknikFonksiyon("MermiVar");
                }

                else
                {
                    SarjorDoldurmaTeknikFonksiyon("MermiYok");
                }

            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            MermiAl();
        }
        

        
    }

    void MermiKaydet(int MermiSayisi)
    {
        MermiAlmaSesi.Play();
        ToplamMermi += MermiSayisi;
        Yazdir();
    }
    void MermiAl()
    {
         RaycastHit hit;
        if(Physics.Raycast(POV.transform.position,POV.transform.forward, out hit, 4))
        {
            if(hit.transform.gameObject.CompareTag("Mermi"))
            {
                MermiKaydet(hit.transform.gameObject.GetComponent<MermiKutusu>().Olusan_Mermi);
              //  Debug.Log(hit.transform.gameObject.GetComponent<MermiKutusu>().Olusan_Silah + "Evet Çarptı");
                Mermi_Kutusu_Olustur.Mermi_Kutusu_Varmi=false;
                Destroy(hit.transform.gameObject);
                
            }
        }   
    }

  /* private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Mermi"))
        {
            Debug.Log("Evet Çarptım");
        }
    } */
    void AtesEt()
    {
     /*  GameObject obje = Instantiate(KovanObje,KovanCikisNoktasi.transform.position,KovanCikisNoktasi.transform.rotation);
       Rigidbody rb = obje.GetComponent<Rigidbody>();
       rb.AddRelativeForce(new Vector3 (-10,1,0)*30); */
        
        AtesSesi.Play();
        AtesEfekt.Play();
        animatorum.Play("Taramalli");

        KalanMermi--;
        KalanMermiText.text = KalanMermi.ToString();

        RaycastHit hit;
        if(Physics.Raycast(POV.transform.position,POV.transform.forward, out hit, Menzil))
        {
            if(hit.transform.gameObject.CompareTag("Dusman"))
            {
            YokEt();
            hit.transform.gameObject.GetComponent<Dusman>().DarbeAl(DarbeGucu);
            }

            else
            {
            Instantiate(Mermiİzi,hit.point,Quaternion.LookRotation(hit.normal));
            
            }
            
        }
    }

    void YokEt()
    {
        RaycastHit hit2;
        if(Physics.Raycast(POV.transform.position,POV.transform.forward, out hit2, Menzil))
        {
        var Kopya = Instantiate(KanLekesi,hit2.point,Quaternion.LookRotation(hit2.normal));
        Destroy(Kopya, 0.1f);
        }
    }

    void Yazdir()
    {
        ToplamMermiText.text = ToplamMermi.ToString();
        KalanMermiText.text = KalanMermi.ToString();
    }

    void SarjorDoldurmaTeknikFonksiyon(string tur)
    {
        switch(tur)
        {
            case "MermiVar":

                if(ToplamMermi <= SarjorKapasite)
                {
                    ToplamDeger = KalanMermi += ToplamMermi;
                    if(ToplamDeger > SarjorKapasite)
                    {
                        KalanMermi = SarjorKapasite;
                        ToplamMermi = ToplamDeger - SarjorKapasite;
                        Yazdir();
                        
                    }
                    else
                    {
                        ToplamMermi=0;
                        KalanMermi += ToplamMermi;
                        Yazdir();
                        
                    }
                }
                else
                {
                    KullanilanMermiSayisi = SarjorKapasite - KalanMermi;
                    ToplamMermi = ToplamMermi - KullanilanMermiSayisi;
                    KalanMermi = SarjorKapasite;
                    Yazdir();
                }

                

                break;
            
            case "MermiYok":

                if(ToplamMermi <= SarjorKapasite)
                {
                    KalanMermi = ToplamMermi;
                    ToplamMermi = 0;
                    Yazdir();
                }
                else
                {
                    KullanilanMermiSayisi = SarjorKapasite - KalanMermi;
                    ToplamMermi = ToplamMermi - KullanilanMermiSayisi;
                    KalanMermi = SarjorKapasite;
                    Yazdir();
                }

                

                break;
        }
    }
}
