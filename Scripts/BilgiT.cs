using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BilgiT : MonoBehaviour
{
    public GameObject BilgiPaneli, Yanpanel;
    public Text BilgiTEXT, süreTXT, yanPaanelTXT;
    public int GelmeOlasılıgı;
    public float DenetlemeSüresi;
    public bool Kabul, redd;
    public ParaPanel Stbr;
    public fırlatma Fırlatma;
    public GameObject KabulB, reddB;
    public int HangiYorunge;
    public bool AcılmaSayısı, verildi, Bekleniyor;
    void Start()
    {
        Fırlatma.Askeriuydu = PlayerPrefs.GetInt("uydusayısı", Fırlatma.Askeriuydu);
        Fırlatma.İletişimuydusu = PlayerPrefs.GetInt("uydusayısı", Fırlatma.İletişimuydusu);
        Fırlatma.OnlineUydu = PlayerPrefs.GetInt("uydusayısı", Fırlatma.OnlineUydu);
        Fırlatma.OfflineUydu = PlayerPrefs.GetInt("uydusayısı", Fırlatma.OfflineUydu);
        DenetlemeSüresi = 30f;
        AcılmaSayısı = bool.Parse(PlayerPrefs.GetString("acılmasayısı", AcılmaSayısı.ToString()));
        if (!AcılmaSayısı)
        {
            verildi = false;

            PlayerPrefs.SetString("acılmasayısı", AcılmaSayısı.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Bekleniyor)
        {
            DenetlemeSüresi -= Time.deltaTime;
        }
        if (DenetlemeSüresi <= 0)
        {
            if (!Bekleniyor)
            {
                GelmeOlasılıgı = Random.Range(1, 100);
            }

            if (GelmeOlasılıgı == 8 && Fırlatma.Askeriuydu > 0)
            {
                Bekleniyor = true;


            }
            else
            {
                DenetlemeSüresi = 30;
            }

            if (GelmeOlasılıgı == 25 && Fırlatma.İletişimuydusu > 0)
            {
                Bekleniyor = true;


            }
            else
            {
                DenetlemeSüresi = 30;
            }





        }
        if (Bekleniyor)
        {
            if (GelmeOlasılıgı == 8 && Fırlatma.Askeriuydu > 0)
            {

                Olasılıklar1();

            }
            if (GelmeOlasılıgı == 25 && Fırlatma.İletişimuydusu > 0)
            {

                Olasılıklar2();

            }
        }

        if (!AcılmaSayısı)
        {
            İlkPara();
        }


    }
    public void AcceptBTN()
    {
        Kabul = true;
        redd = false;


    }
    public void RefuseBTN()
    {
        redd = true;
        Kabul = false;



    }
    public void Olasılıklar1()
    {

        BilgiPaneli.SetActive(true);
        BilgiTEXT.text = "NASA sizden herhangi bir askeri uydu istiyor.Verirseniz itibarınız artacak";
        if (Kabul && Fırlatma.Askeriuydu > 0)
        {
            Stbr.Guvenilirlik += 50;
            PlayerPrefs.SetInt("EXP", Stbr.Guvenilirlik);
            Fırlatma.Askeriuydu -= 1;
            PlayerPrefs.SetInt("Askeriuydu", Fırlatma.Askeriuydu);
            Fırlatma.Dunya -= 1;
            PlayerPrefs.SetInt("yorungelerDunya", Fırlatma.Dunya);
            BilgiPaneli.SetActive(false);
            Fırlatma.OfflineUydu += 1;
            PlayerPrefs.SetInt("offlineuydusayısı", Fırlatma.OfflineUydu);

            Kabul = false;
            Bekleniyor = false;
            DenetlemeSüresi = 30f;
        }
        if (redd)
        {
            Stbr.Guvenilirlik -= 15;
            PlayerPrefs.SetInt("EXP", Stbr.Guvenilirlik);
            BilgiPaneli.SetActive(false);

            redd = false;
            Bekleniyor = false;
            DenetlemeSüresi = 30f;
        }


    }
    public void Olasılıklar2()
    {
        reddB.SetActive(false);
        BilgiPaneli.SetActive(true);
        BilgiTEXT.color = new Color(255, 0, 0);
        BilgiTEXT.text = "<Satellite_Crash>.crash.report:'UnknownLocationX?Y?Z?!(İletişim Uydusu Offline)";
        Stbr.Guvenilirlik -= 5;
        PlayerPrefs.SetInt("EXP", Stbr.Guvenilirlik);
        Fırlatma.İletişimuydusu -= 1;
        PlayerPrefs.SetInt("İletişimuydusu", Fırlatma.İletişimuydusu);
        Fırlatma.OfflineUydu += 1;
        PlayerPrefs.SetInt("offlineuydusayısı", Fırlatma.OfflineUydu);

        if (Kabul)
        {
            HangiYorunge = Random.Range(1, 4);
            if (HangiYorunge == 1)
            {
                Fırlatma.Dunya -= 1;
                PlayerPrefs.SetInt("yorungelerDunya", Fırlatma.Dunya);
            }
            if (HangiYorunge == 2)
            {
                Fırlatma.Mars -= 1;
                PlayerPrefs.SetInt("yorungelerMars", Fırlatma.Mars);
            }
            if (HangiYorunge == 3)
            {
                Fırlatma.Astreoid -= 1;
                PlayerPrefs.SetInt("yorungelerAstreoid", Fırlatma.Astreoid);
            }
            BilgiPaneli.SetActive(false);
            BilgiTEXT.color = new Color(255, 255, 255);
            Kabul = false;
            Bekleniyor = false;
            reddB.SetActive(true);
            DenetlemeSüresi = 30f;
        }
        if (redd)
        {

            BilgiPaneli.SetActive(false);
            BilgiTEXT.color = new Color(255, 255, 255);
            redd = false;
            Bekleniyor = false;
            DenetlemeSüresi = 30f;
        }



    }
    public void İlkPara()
    {

        if (!verildi)
        {
            Stbr.para += 300000;
            PlayerPrefs.SetFloat("para", Stbr.para);
            Stbr.Toplamişçi += 11;
            PlayerPrefs.SetInt("işçi", Stbr.Toplamişçi);
            BilgiPaneli.SetActive(true);
            BilgiTEXT.color = new Color(0, 0, 0);
            BilgiTEXT.text = "Satellite Managment'a HOŞ GELDİNİZ! İlk uydunuzu inşa etmeye başlayabilirsiniz.";
            reddB.SetActive(false);
            verildi = true;

        }
        if (Kabul)
        {

            BilgiPaneli.SetActive(false);
            BilgiTEXT.color = new Color(255, 255, 255);
            Kabul = false;
            reddB.SetActive(false);
            AcılmaSayısı = true;
            PlayerPrefs.SetString("acılmasayısı", AcılmaSayısı.ToString());
        }

    }
    public void PanelAnimasyonu()
    {
        Yanpanel.SetActive(true);

    }
    public void PanelAnimasyonRewind()
    {
        Yanpanel.SetActive(false);
    }
}
