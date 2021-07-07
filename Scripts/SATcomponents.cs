using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SATcomponents : MonoBehaviour
{
    public Button insabtn, panelacma;
  
    public int toplammaaliyet;
    public ParaPanel statbar;
    public Madenler madens;
    public GameObject camcam;
    public GameObject eminmisiniz;
    public Text eminmisinizText;
    public Dropdown Teleskop, Güç, Anten, Motor, Gövde;
    public Isci Isciler;
    public ulong tıklanmazamanı;
    ulong fark;
    ulong v;
    public float kalanzaman;
    ulong simdikizaman;
    public float süre;
    bool alınsın;
    public int uydusayısı;
    public int Quality;
    public Text Qualitytext;
    private int işçi;
    public bool Onay1;
    public GameObject panel,sliderzaman;
    public Slider ZamanEx;
    public Text Gösterge1, Gösterge2;
    public Animator anim;
    private int zaman1;
    void Start()
    {
        eminmisiniz.SetActive(false);
        statbar = camcam.GetComponent<ParaPanel>();
        tıklanmazamanı = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı"));
        süre = PlayerPrefs.GetFloat("zaman");
       madens = camcam.GetComponent<Madenler>();
        uydusayısı = PlayerPrefs.GetInt("uydusayısı", uydusayısı);
        Quality = PlayerPrefs.GetInt("Quality", Quality);
        //    Qualitytext.text = Quality.ToString();
       

        süre = PlayerPrefs.GetFloat("zaman");
        Onay1 = bool.Parse(PlayerPrefs.GetString("onay", Onay1.ToString()));
        if (tıklanmazamanı <= 0)
        {
            insabtn.interactable = true;

        }
        else
        {
            insabtn.interactable = false;
        }
        ZamanEx.maxValue = süre;
       
    }

    // Update is called once per frame
    void Update()
    {


        if (tıklanmazamanı > 0)
        {
            simdikizaman = (ulong)System.DateTime.Now.Ticks;


            süre = PlayerPrefs.GetFloat("zaman");

            tıklanmazamanı = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı", tıklanmazamanı.ToString()));
            fark = simdikizaman - tıklanmazamanı;
            v = fark / System.TimeSpan.TicksPerMinute;
            kalanzaman = (süre - v);
            if (kalanzaman <= 0)
            {
                Gösterge1.text = "";
                Gösterge2.text = "";
                Onay1 = bool.Parse(PlayerPrefs.GetString("onay", Onay1.ToString()));
                ZamansalUyduSayısı();
                kalanzaman = 0;
                tıklanmazamanı = 0;
                PlayerPrefs.SetString("tıklanmaZamanı", tıklanmazamanı.ToString());
               
            }
            if (kalanzaman > 0)
            {
                sliderzaman.SetActive(true);
                
                ZamanEx.maxValue = süre;
                ZamanEx.value = kalanzaman;
                Gösterge1.text = ZamanEx.maxValue.ToString() + "DK";
                Gösterge2.text = ZamanEx.value.ToString() + "DK";
            }
            if (kalanzaman == 0)
            {
                ZamanEx.value = kalanzaman;
            }
            if (kalanzaman <= 0)
            {
                insabtn.interactable = true;
                
            }
            else
            {
                insabtn.interactable = false;
            }

        }
        else
        {
            sliderzaman.SetActive(false);
           
        }
    }



    public void yap()
    {
        eminmisiniz.SetActive(true);
       
        if (Teleskop.value == 1)
        {
        
            Quality += 1;
            zaman1 += 10;
            toplammaaliyet += 3000;
            alınsın = true;
        }
        if (Teleskop.value == 2)
        {
            Quality += 2;

            zaman1 += 20;
            toplammaaliyet += 4500;
            alınsın = true;
        }
        if (Teleskop.value == 3)
        {
            Quality += 3;
            toplammaaliyet += 5200;
            zaman1 += 40;
            alınsın = true;
        }
        if (Teleskop.value == 4)
        {
            Quality += 3;
            toplammaaliyet += 7000;
            zaman1 += 80;
            alınsın = true;
        }
        if (Güç.value == 1)
        {
            Quality += 2;
           toplammaaliyet += 7800;
            zaman1 += 10;
            alınsın = true;
        }
        if (Güç.value == 2)
        {
            Quality += 2;
            toplammaaliyet += 8200;
            zaman1 += 20;
            alınsın = true;
        }
        if (Güç.value == 3)
        {
            Quality += 3;
            toplammaaliyet += 9000;
            zaman1 += 40;
            alınsın = true;
        }
        if (Güç.value == 4)
        {
            Quality += 3;
            zaman1 += 80;
            toplammaaliyet += 9500;
            alınsın = true;
        }
        if (Anten.value == 1)
        {
            Quality += 1;
            zaman1 += 10;
            toplammaaliyet += 5000;
            alınsın = true;
        }
        if (Anten.value == 2)
        {
            Quality += 2;
            zaman1 += 20;
            toplammaaliyet += 5500;
            alınsın = true;
        }
        if (Anten.value == 3)
        {
            Quality += 3;
            zaman1 += 40;
            toplammaaliyet += 5900;
            alınsın = true;
        }
        if (Anten.value == 4)
        {
            Quality += 3;
            zaman1 += 80;
            toplammaaliyet += 6400;
            alınsın = true;
        }
        if (Motor.value == 1)
        {
            Quality += 1;
            zaman1 += 10;
            toplammaaliyet += 24000;
            alınsın = true;
        }
        if (Motor.value == 2)
        {
            Quality += 2;
            zaman1 += 20;
            toplammaaliyet += 27000;
            alınsın = true;
        }
        if (Motor.value == 3)
        {
            Quality += 3;
            zaman1 += 40;
            toplammaaliyet += 29000;
            alınsın = true;
        }
        if (Motor.value == 4)
        {
            Quality += 3;
            zaman1 += 80;
            toplammaaliyet += 40000;
            alınsın = true;
        }
        if (Gövde.value == 1)
        {
            Quality += 1;
            zaman1 += 10;
            toplammaaliyet += 10000;
            alınsın = true;
        }
        if (Gövde.value == 2)
        {
            Quality += 2;
            zaman1 += 20;
            toplammaaliyet += 12000;
            alınsın = true;
        }
        if (Gövde.value == 3)
        {
            Quality += 3;
            zaman1 += 40;
            toplammaaliyet += 14000;
            alınsın = true;
        }
        if (Gövde.value == 4)
        {
            Quality += 3;
            zaman1 += 80;
            toplammaaliyet += 15500;
            alınsın = true;
        }
        
     
        eminmisiniz.SetActive(true);
        anim.SetBool("ileri", true);
        eminmisinizText.text = "Paranızdan " + toplammaaliyet + "TL" + " eksilecek kabul ediyor musunuz?";
       
    
        
    }
    public void EminmisinizEvet()
    {
      
        if (toplammaaliyet > statbar.para)
        {
            eminmisinizText.text = "YETERSİZ PARA !";
            anim.SetBool("GERİ", true);
            anim.SetBool("ileri", false);
        }

        if (toplammaaliyet <= statbar.para)
        {

            if (Motor.value == 0)
            {
               
                alınsın = false;
                eminmisiniz.SetActive(false);
            }
            if (Gövde.value == 0)
            {
               
                alınsın = false;
                eminmisiniz.SetActive(false);
            }
            if (Anten.value == 0)
            {
               
                alınsın = false;
                eminmisiniz.SetActive(false);

            }



            anim.SetBool("GERİ", true);
            anim.SetBool("ileri", false);
            Alınacaklar();
        }

       

    }
    public void eminmizinizHayir()
    {
        Teleskop.value = 0;
        Güç.value = 0;

        Anten.value = 0;
        Motor.value = 0;
        Gövde.value = 0;
        toplammaaliyet = 0;
        anim.SetBool("GERİ", true);
        anim.SetBool("ileri", false);

    }
    void Alınacaklar()
    {
        if (alınsın == true)
        {


            statbar.para -= toplammaaliyet;
            PlayerPrefs.SetFloat("para", statbar.para);
            toplammaaliyet = 0;
            
           
            insabtn.interactable = false;
         


            PlayerPrefs.SetInt("Quality", Quality);
            Quality = PlayerPrefs.GetInt("Quality", Quality);
           // Qualitytext.text = Quality.ToString();
          
            Onay1 = false;
            PlayerPrefs.SetString("onay", Onay1.ToString());
            SetTime(zaman1);
           
        }

    }
    public void ZamansalUyduSayısı()
    {
        if (!Onay1)
        {
            uydusayısı += 1;
            PlayerPrefs.SetInt("uydusayısı", uydusayısı);
            Onay1 = true;
            PlayerPrefs.SetString("onay", Onay1.ToString());
        }

    }
    public void UyduEkleme()
    {
        Vector3 a = new Vector3(1, 1, 1);
        Instantiate(panel, a, Quaternion.identity);
    }
    public void SetTime(float Time)
    {
        PlayerPrefs.SetFloat("zaman", Time);
        süre = PlayerPrefs.GetFloat("zaman");
        ZamanEx.maxValue = süre;
        PlayerPrefs.SetString("tıklanmaZamanı", System.DateTime.Now.Ticks.ToString());
        tıklanmazamanı = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı"));
        zaman1 = 0;
    }
    public void Hızlandırma(int Sıfır)
    {   
        PlayerPrefs.SetFloat("zaman", Sıfır);
        süre = PlayerPrefs.GetFloat("zaman");
    }
}
