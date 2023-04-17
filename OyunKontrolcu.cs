using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OyunKontrolcu : MonoBehaviour
{

    [Header("DÜŞMAN AYARLARI")]
    float health = 100;
    public Image HealthBar;
    
    [Header("DÜŞMAN AYARLARI")]
    public GameObject[] dusmanlar;
    public GameObject[] cikisNoktalari;
    public GameObject[] hedefNoktalari;
    public float spawnFrekansi;

    [Header("DİĞER AYARLAR")]
    public GameObject GameOverCanvas;

    
    


    void Start()
    {
        StartCoroutine(DusmanCikar());
        
    }

    IEnumerator DusmanCikar()
    {

        while(true)
        {
            yield return new WaitForSeconds(spawnFrekansi);
            int dusman = Random.Range(0,5);
            int cikisNoktasi = Random.Range(0,2);
            int hedefNoktasi = Random.Range(0,2);

            GameObject Obje = Instantiate(dusmanlar[dusman],cikisNoktalari[cikisNoktasi].transform.position, Quaternion.identity);
            Obje.GetComponent<Dusman>().HedefBelirle(hedefNoktalari[hedefNoktasi]);
        }
    }
   
    void Update()
    {
        
    }

    public void DarbeAl(float darbegucu)
    {
        health -= darbegucu;
        HealthBar.fillAmount = health/100;
        if(health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
