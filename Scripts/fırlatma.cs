using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fırlatma : MonoBehaviour {
    public Dropdown yörünge;
    public Dropdown görev,fırlatıcı;
    public int fırlatmaucreti;
    public Madenler maden;
    public GameObject mancam;
    public float süre1;
    public Image exp;
    public ParaPanel stb;

   public float imadenzaman;
    int bmaden;
    public float iiletişimzaman;
    public float parailetişim;
    public Button fırlatt;
    public ulong tıklanmazamanı1;
    ulong fark;
    ulong v;
    float kalanzaman;
    ulong simdikizaman;
   public int madenattırma;
   public int iletişim = 0;
    public bool askeri;
    public bool keşif;
    public GameObject fırlatmapenel;
    bool alınsın;
    public SATcomponents SATCOM;
    public BilgiT Bilgiyazı;
    public Text uydusayısıtxt;
    public int uydusayısı;
    private int GUVEN;
    public Text DunyaTXT, MarsTXT, AstreoidlerTXT, OnlineUyduTXT, OfflineUyduTXT;
    public int Dunya, Mars, Astreoid;
    public int askeriKalite;
    public int OlasıYüzdelikSayı;
    public float OlasıYüzdelikSayıZamani;
    public int OnlineUydu,OfflineUydu,Askeriuydu,İletişimuydusu,Keşifuydusu;
    public bool Tiklandimi;
    public AudioSource Uydusesi;
    public float Yenilemezamanı;
    public GameObject BilgiPenceresi;
    public bool pencereacilmadurumu;
    private bool Kabul,redd;
    public GameObject redBTN;
    public Text bilgiTXT;
    public bool falseyapıcı;
    private float Kapalışzamanı;
    public Text KeşifuydusuTXT;
    public Sprite Dunya1, Mars1, Astreoid1,unknown;
    public Image Target;
    public Text Durum;
   
    // Use this for initialization
    void Start() {
       
        iletişim = PlayerPrefs.GetInt("pararttırma", iletişim);
        iiletişimzaman = 30;
        imadenzaman = 25;
        SATCOM = mancam.GetComponent<SATcomponents>();
        stb = mancam.GetComponent<ParaPanel>();
        maden = mancam.GetComponent<Madenler>();
        tıklanmazamanı1 = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı1",tıklanmazamanı1.ToString()));
        Bilgiyazı = mancam.GetComponent<BilgiT>();
        madenattırma = PlayerPrefs.GetInt("pararttırma", madenattırma);
        GUVEN = 0;
        Dunya =PlayerPrefs.GetInt("yorungelerDunya", Dunya);
        Mars = PlayerPrefs.GetInt("yorungelerMars", Mars);
       SATCOM.Quality = PlayerPrefs.GetInt("Quality", SATCOM.Quality);
        SATCOM.Qualitytext.text = SATCOM.Quality.ToString();
        Astreoid =  PlayerPrefs.GetInt("yorungelerAstreoid", Astreoid);
        Askeriuydu = PlayerPrefs.GetInt("Askeriuydu", Askeriuydu);
        İletişimuydusu = PlayerPrefs.GetInt("İletişimuydusu", İletişimuydusu);
        Keşifuydusu = PlayerPrefs.GetInt("Keşifuydusu", Keşifuydusu);
        askeri = bool.Parse(PlayerPrefs.GetString("askeri"));
        OlasıYüzdelikSayıZamani = 30;
       Tiklandimi = bool.Parse( PlayerPrefs.GetString("tiklandimi", Tiklandimi.ToString()));
        süre1 =PlayerPrefs.GetFloat("zaman", süre1);
      
        OnlineUydu = PlayerPrefs.GetInt("onlineuydusayısı", OnlineUydu);
        Yenilemezamanı = 1;
        Debug.Log("start");
        
    }
	
	// Update is called once per frame
	 void Update() {
        
        simdikizaman = (ulong)System.DateTime.Now.Ticks;
        Tiklandimi = bool.Parse(PlayerPrefs.GetString("tiklandimi", Tiklandimi.ToString()));
        uydusayısıtxt.text = SATCOM.uydusayısı.ToString();
       
        OnlineUydu = Askeriuydu + İletişimuydusu + Keşifuydusu;
        PlayerPrefs.SetInt("onlineuydusayısı",OnlineUydu);
      DunyaTXT.text = PlayerPrefs.GetInt("yorungelerDunya", Dunya).ToString();
        MarsTXT.text = PlayerPrefs.GetInt("yorungelerMars", Mars).ToString();
        AstreoidlerTXT.text = PlayerPrefs.GetInt("yorungelerAstreoid", Astreoid).ToString();
        bmaden = Random.Range(1, 50);
        if(imadenzaman > 0)
        {

            imadenzaman -= Time.deltaTime;
        }

        if (imadenzaman <= 0)
        {
            bmaden = Random.Range(1, 100);
            imadenzaman = 25;
            if (bmaden <= 25 && Keşifuydusu > 0)
            {
                maden.bilinmeyenmadensayısı += 1*Keşifuydusu;
                PlayerPrefs.SetInt("madenler", maden.bilinmeyenmadensayısı);
                pencereacilmadurumu = true;
                Bilgiyazı.yanPaanelTXT.text = "Keşfedilmemiş yeni bir madeniniz var !";
            }
        }
        if(Keşifuydusu > 0)
        {
            KeşifuydusuTXT.text = "Keşifi uydusu sayısı :" + Keşifuydusu;
        }
        else
        {
            KeşifuydusuTXT.text = "Keşif uydunuz yok Uydu bileşenleri bölümünden uydu inşa edip , fırlatma bölümünden yollaya bilirsiniz." ;
        }
        if (pencereacilmadurumu)
        {
            Bilgiyazı.Yanpanel.SetActive(true);
            Kapalışzamanı = 3;
            falseyapıcı = true;
            pencereacilmadurumu = false;
        }
        if (falseyapıcı)
        {
            Kapalışzamanı -= Time.deltaTime;
            if(Kapalışzamanı < 0)
            {
                falseyapıcı = false;
                Bilgiyazı.Yanpanel.SetActive(false);
            }
        }

        if (Yenilemezamanı > 0)
        {
            Yenilemezamanı -= Time.deltaTime;
        }
        else
        {
            Askeriuydu = PlayerPrefs.GetInt("Askeriuydu", Askeriuydu);
            İletişimuydusu = PlayerPrefs.GetInt("İletişimuydusu", İletişimuydusu);
            Keşifuydusu = PlayerPrefs.GetInt("Keşifuydusu", Keşifuydusu);
            
            OnlineUydu= PlayerPrefs.GetInt("onlineuydusayısı", OnlineUydu);
            OnlineUyduTXT.text = OnlineUydu.ToString();
            
            OfflineUydu=PlayerPrefs.GetInt("offlineuydusayısı", OfflineUydu);
            OfflineUyduTXT.text = OfflineUydu.ToString();
            Yenilemezamanı = 1;
        }

        if (iiletişimzaman > 0)
        {

            iiletişimzaman -= Time.deltaTime;


        }
        if(İletişimuydusu > 0) { }
        if (iiletişimzaman <= 0)
        {
            if (İletişimuydusu > 0)
            {
                parailetişim = Random.Range(400, 800);
                SATCOM.Quality = PlayerPrefs.GetInt("Quality", SATCOM.Quality);
                stb.para += parailetişim * SATCOM.Quality * İletişimuydusu;
                PlayerPrefs.SetFloat("para", stb.para);
                stb.para = PlayerPrefs.GetFloat("para", stb.para);
                stb.ParaText.text = stb.para.ToString();
                pencereacilmadurumu = true;
                if (İletişimuydusu > 0)
                {
                    Bilgiyazı.yanPaanelTXT.text = "+" + parailetişim + " TL";
                }
            }
            iiletişimzaman = 30;
        }
        if(OlasıYüzdelikSayıZamani > 0)
        {
            OlasıYüzdelikSayıZamani -= Time.deltaTime;
        }
        else
        {
            
            OlasıYüzdelikSayı = Random.Range(1, 50);
            OlasıYüzdelikSayıZamani = 30;
        }
      
       
        if(OlasıYüzdelikSayı <= 12)
        {   
            stb.Guvenilirlik += 3*Askeriuydu;
            PlayerPrefs.SetInt("EXP", stb.Guvenilirlik);
            OlasıYüzdelikSayı = 25;
            pencereacilmadurumu = true;
            if (Askeriuydu > 0)
            {
                Bilgiyazı.yanPaanelTXT.text = "+" + 3 * Askeriuydu + " itibar puanı";
            }
        }
        Debug.Log("asda");
    }
    public void Fırlat()
    {
      

        if (yörünge.value == 1)
        {
           
            alınsın = true;
        }
        if (yörünge.value == 2)
        {
            
            alınsın = true;
        }
        if(yörünge.value == 3)
        {
          
            alınsın = true;
        }
        if (fırlatıcı.value == 1)
        {
           
            alınsın = true;


        }
        if (fırlatıcı.value == 2)
        {
          
            alınsın = true;


        }
        if (fırlatıcı.value == 3)
        {
           
            alınsın = true;

        }
        if (görev.value == 1)
        {
            alınsın = true;
        }
        if (görev.value == 2)
        {
            alınsın = true;
        }
        if (görev.value == 3)
        {
           
           
          
            alınsın = true;
        }
        if(görev.value == 4)
        {
            
           
            alınsın = true;
           
        }
        if (yörünge.value == 0)
        {
            alınsın = false;
        }
        if (görev.value == 0)
        {
            alınsın = false;
        }
        if (fırlatıcı.value == 0)
        {
            alınsın = false;
        }
        if(yörünge.value == 1 && görev.value == 2)
        {
            alınsın = false;
            Bilgiyazı.yanPaanelTXT.text = "Askeri uydular sadece dünya yörüngesine oturtulabilir";
            pencereacilmadurumu = true;
        }
        Alınacaklar();
    
    }
    public void Kapatpaneli()
    {
        fırlatmapenel.SetActive(false);
    }
    public void ACpaneli()
    {
        fırlatmapenel.SetActive(true);
    }
    void Alınacaklar()
    { if (alınsın == true && SATCOM.uydusayısı > 0)
        {
           
            if (yörünge.value == 1)
            {
                süre1 = 4;
                GUVEN += 10;
                Dunya += 1;
                DunyaTXT.text = Dunya.ToString();
                PlayerPrefs.SetInt("yorungelerDunya",Dunya);

            }
            if (yörünge.value == 2)
            {
                GUVEN += 20;
                süre1 = 20;
                Mars += 1;
               MarsTXT.text = Mars.ToString();
                PlayerPrefs.SetInt("yorungelerMars", Mars);
            }
            if (yörünge.value == 3)
            {
                GUVEN += 30;
                süre1 = 24;
                Astreoid += 1;
                AstreoidlerTXT.text = Astreoid.ToString();
                PlayerPrefs.SetInt("yorungelerAstreoid", Astreoid);
            }
            if (fırlatıcı.value == 1)
            {
                GUVEN += 10;
                fırlatmaucreti = 50000;

                stb.para -= fırlatmaucreti;
                PlayerPrefs.SetFloat("para", stb.para);
              


            }
            if (fırlatıcı.value == 2)
            {
                GUVEN += 20;
                fırlatmaucreti = 75000;

                stb.para -= fırlatmaucreti;
                PlayerPrefs.SetFloat("para", stb.para);
               


            }
            if (fırlatıcı.value == 3)
            {
                GUVEN += 30;
                fırlatmaucreti = 1000000;

                stb.para -= fırlatmaucreti;
                PlayerPrefs.SetFloat("para", stb.para);
             
            }
            if (görev.value == 1)
            {
                GUVEN += 10;
                
                İletişimuydusu += 1;
                PlayerPrefs.SetInt("İletişimuydusu", İletişimuydusu);
            }
            if (görev.value == 2)
            {
                Askeriuydu += 1;
                PlayerPrefs.SetInt("Askeriuydu", Askeriuydu);
                GUVEN += 20;
                
            }
            if (görev.value == 3)
            {
                GUVEN += 30;
                madenattırma = 1;
                PlayerPrefs.SetInt("pararttırma",madenattırma);
               Keşifuydusu += 1;
                PlayerPrefs.SetInt("Keşifuydusu", Keşifuydusu);
                
            }
           
            stb.Guvenilirlik += GUVEN;
           PlayerPrefs.SetInt("EXP", stb.Guvenilirlik);
            SATCOM.uydusayısı -= 1;
            PlayerPrefs.SetInt("uydusayısı", SATCOM.uydusayısı);
            fırlatmapenel.SetActive(false);
            tıklanmazamanı1 = (ulong)System.DateTime.Now.Ticks;
            PlayerPrefs.SetString("tıklanmaZamanı1", tıklanmazamanı1.ToString());
            tıklanmazamanı1 = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı1", tıklanmazamanı1.ToString()));
            Tiklandimi = true;
            PlayerPrefs.SetString("tiklandimi",Tiklandimi.ToString());
           
            stb.para = PlayerPrefs.GetFloat("para", stb.para);
            PlayerPrefs.SetFloat("zaman", süre1);

        }
    }
    public void UydusesiPLY()
    {
        Uydusesi.Play();
    }
    public void UydusesiSTP()
    {
        Uydusesi.Pause();
    }
    public void AcceptBTN2()
    {
        Kabul = true;
        redd = false;


    }
    public void RefuseBTN2()
    {
        redd = true;
        Kabul = false;



    }
    public void DropdownValueChecker()
    {
        if(yörünge.value == 0)
        {
            Target.sprite = unknown;
        }
        if (yörünge.value == 1)
        {
            Target.sprite = Dunya1;
        }
        if (yörünge.value == 2)
        {
            Target.sprite = Mars1;
        }
        if (yörünge.value == 3)
        {
            Target.sprite = Astreoid1;
        }

    }
    public void DurumChecker()
    {
        if (yörünge.value == 0)
        {
            Durum.text = "DURUM : HEDEF SEÇİN";

        }
        else
        {
            if (görev.value == 0)
            {
                Durum.text = "DURUM : GÖREV SEÇİN";
            }
            else
            {
                if (fırlatıcı.value == 0)
                {
                    Durum.text = "DURUM : ŞİRKET SEÇİN";
                }
                else
                {
                    Durum.text = "Fırlatma Aktif";
                    Durum.color = new Color(0,255,0);
                }

            }
        }
    }
   
}
