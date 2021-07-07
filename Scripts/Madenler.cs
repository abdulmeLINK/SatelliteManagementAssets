using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madenler : MonoBehaviour
{
    public Text bilinmeyenmaden, kalanzamantext;
    public int bilinmeyenmadensayısı;

    public ulong tıklanmazamanı;
    ulong fark;
    ulong v;
    float kalanzaman;
    ulong simdikizaman;
    float süre;
    public bool madenvakti;
    public ParaPanel stbr;
    public SATcomponents SATCOM;
    public GameObject manicam;
    public Button resarchbutton;



    void Start()
    {
        süre = PlayerPrefs.GetFloat("zamanı", süre);
        tıklanmazamanı = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı1"));
        stbr = manicam.GetComponent<ParaPanel>();
        SATCOM = manicam.GetComponent<SATcomponents>();
        madenvakti = bool.Parse(PlayerPrefs.GetString("madenvakti", madenvakti.ToString()));
        if (madenvakti == false)
        {
            resarchbutton.interactable = true;
        }
        if (madenvakti == true)
        {
            resarchbutton.interactable = false;
        }
        

        bilinmeyenmadensayısı = PlayerPrefs.GetInt("madenler", bilinmeyenmadensayısı);
    }

    // Update is called once per frame
    void Update()
    {

        simdikizaman = (ulong)System.DateTime.Now.Ticks;


        if (resarchbutton.interactable == false && madenvakti == true)
        {
            fark = simdikizaman - tıklanmazamanı;
            v = fark / System.TimeSpan.TicksPerMinute;
            kalanzaman = (süre - v);
            if (kalanzaman <= 0)
            {

                bilinmeyenmadensayısı -= 1;
                PlayerPrefs.SetInt("madenler", bilinmeyenmadensayısı);
                madenvakti = false;
                PlayerPrefs.SetString("madenvakti", madenvakti.ToString());

                stbr.para += 35000;
                PlayerPrefs.SetFloat("para", stbr.para);
                resarchbutton.interactable = true;
                kalanzamantext.text = "";
            }
            kalanzamantext.text = kalanzaman.ToString() + " DK";
        }
     
        bilinmeyenmaden.text = "+" + bilinmeyenmadensayısı.ToString();

    }
    
    public void Research()
    {
        if (bilinmeyenmadensayısı > 0)
        {

            madenvakti = true;
            PlayerPrefs.SetString("madenvakti", madenvakti.ToString());
            süre = 90;
            PlayerPrefs.SetFloat("zamanı", süre);
            resarchbutton.interactable = false;
            PlayerPrefs.SetString("tıklanmaZamanı1", System.DateTime.Now.Ticks.ToString());
            tıklanmazamanı = ulong.Parse(PlayerPrefs.GetString("tıklanmaZamanı1").ToString());

        }
        else
        {

        }

    }
}
