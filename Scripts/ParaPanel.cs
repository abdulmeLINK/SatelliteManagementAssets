using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParaPanel : MonoBehaviour
{
    public int Toplamişçi;
    public int Guvenilirlik;
    public Text ParaText,leveltxt;
    public float para;
    public float bitcoinR;
    public Text BTCt;
    public GameObject borsap;
    private float zaman;
    public float Dolar;
    public Text dolart;
   public float kasadabtc;
    public float kasadaTL;
    public float kasadaDolar;
    public float kasadaEuro;
    public float BTCpara;
    public float dolarp;
    public float europ;
    public float TLp;
    public float euro;
    public Text eurot;
    public InputField dnstrmyz;
    public int level;
    public Dropdown Dönüştürülenler, Dönüşenler;
    public Text tt;
    public Text kasaBTC, kasaTL, kasaDOLAR, kasaEURO;
    public float toplamBTC, toplamTL, toplamDOLAR, toplamEURO;
    public Slider Deneyim;
    // Start is called before the first frame update
    void Start()
    {
       
        euro = Random.Range(5f, 7f);
        eurot.text = euro.ToString();
        Dolar = Random.Range(4f, 6f);
        dolart.text = Dolar.ToString();
        bitcoinR = Random.Range(6000, 8000);
        BTCt.text = bitcoinR.ToString();
        zaman = 10;
        kasadabtc = PlayerPrefs.GetFloat("kasadabtc", kasadabtc);
        kasadaDolar = PlayerPrefs.GetFloat("kasadaDolar", kasadaDolar);
        kasadaEuro = PlayerPrefs.GetFloat("kasadaEuro", kasadaEuro);
        kasaBTC.text = kasadabtc.ToString();
        kasaDOLAR.text = kasadaDolar.ToString();
        kasaEURO.text = kasadaEuro.ToString();
      
        level = PlayerPrefs.GetInt("level", level);
        Guvenilirlik = PlayerPrefs.GetInt("EXP",Guvenilirlik);
        
       ParaText.text = PlayerPrefs.GetFloat("para",para).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
      kasaTL.text = PlayerPrefs.GetFloat("para",para).ToString();
        ParaText.text = PlayerPrefs.GetFloat("para", para).ToString();
        para = PlayerPrefs.GetFloat("para", para);
        if (zaman > 0)
        {
            zaman -= Time.deltaTime;
        }
        else
        {
            euro = Random.Range(5f, 7f);
            eurot.text = euro.ToString();
            Dolar = Random.Range(4f, 6f);
            dolart.text = Dolar.ToString();
            bitcoinR = Random.Range(6000, 8000);
            BTCt.text = bitcoinR.ToString();
            zaman = 10;
        }
        SliderUpdate();
        if (Input.GetKeyDown(KeyCode.P))
        {
            para += 1000;
            PlayerPrefs.SetFloat("para", para);
            

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Guvenilirlik += 10;
            PlayerPrefs.SetInt("EXP", Guvenilirlik);

        }
    }
    public void donusturme()
    {
        float girilenyazı = float.Parse(dnstrmyz.text);

        kasadabtc = PlayerPrefs.GetFloat("kasadabtc", kasadabtc);
        kasadaDolar = PlayerPrefs.GetFloat("kasadaDolar", kasadaDolar);
        kasadaEuro = PlayerPrefs.GetFloat("kasadaEuro", kasadaEuro);
       

        if (dnstrmyz.text == "")
        {
            tt.text = "LÜTFEN MİKTAR GİRİN";
        }
        if (para >= girilenyazı)
        {
            if (Dönüşenler.value == 1 && Dönüştürülenler.value == 2)
            {

                BTCpara = girilenyazı / bitcoinR;
                tt.text = BTCpara.ToString();
                kasadabtc += BTCpara;
                kasaBTC.text = kasadabtc.ToString();
                para -= girilenyazı;
                dnstrmyz.text = "";
                BTCpara = 0;
                PlayerPrefs.SetFloat("para", para);
                PlayerPrefs.SetFloat("kasadabtc", kasadabtc);
            }
            if (Dönüşenler.value == 1 && Dönüştürülenler.value == 3)
            {

                dolarp = girilenyazı / Dolar;
                tt.text = dolarp.ToString();
                kasadaDolar += dolarp;

                kasaDOLAR.text = kasadaDolar.ToString();
                para -= girilenyazı;
                dnstrmyz.text = "";
                dolarp = 0;
                PlayerPrefs.SetFloat("para", para);
                PlayerPrefs.SetFloat("kasadaDolar", kasadaDolar);
            }
            if (Dönüşenler.value == 1 && Dönüştürülenler.value == 4)
            {
                Debug.Log("FunctionEnter");
                europ = girilenyazı / euro;
                tt.text = europ.ToString();
                kasadaEuro += europ;
                kasaEURO.text = kasadaEuro.ToString();
                para -= girilenyazı;
                dnstrmyz.text = "";
                europ = 0;
                PlayerPrefs.SetFloat("kasadaEuro", kasadaEuro);
                PlayerPrefs.SetFloat("para", para);
            }
        }
        else
        {
            tt.text = "DÖNÜŞTERECEĞİNİZ  MİKTAR PARANIZDAN KÜÇÜK VEYA PARANIZLA EŞİT OLMALI";
        }
        if (kasadabtc >= girilenyazı)
        {
            if (Dönüştürülenler.value == 1 && Dönüşenler.value == 2)
            {

                TLp = girilenyazı * bitcoinR;
                tt.text = TLp.ToString();
                para += TLp;
                PlayerPrefs.SetFloat("para", para);
                kasaTL.text = para.ToString();
                kasadabtc -= girilenyazı;
                kasaBTC.text = kasadabtc.ToString();
                dnstrmyz.text = "";
                TLp = 0;
                PlayerPrefs.SetFloat("para", para);
                PlayerPrefs.SetFloat("kasadabtc", kasadabtc);
            }
        }
        if (kasadaDolar >= girilenyazı)
        {
            if (Dönüştürülenler.value == 1 && Dönüşenler.value == 3)
            {

                TLp = girilenyazı * Dolar;
                tt.text = TLp.ToString();
               para += TLp;
                kasaTL.text = para.ToString();
                kasadaDolar -= girilenyazı;
                kasaDOLAR.text = kasadaDolar.ToString();
                dnstrmyz.text = "";
                TLp = 0;
                PlayerPrefs.SetFloat("para", para);
                PlayerPrefs.SetFloat("kasadaDolar", kasadaDolar);
            }
        }
        if (kasadaEuro >= girilenyazı)
        {
            if (Dönüştürülenler.value == 1 && Dönüşenler.value == 4)
            {

                TLp = girilenyazı * euro;
                tt.text = TLp.ToString();
                para += TLp;
                kasaTL.text = para.ToString();
                kasadaDolar -= girilenyazı;
                kasaDOLAR.text = kasadaDolar.ToString();
                dnstrmyz.text = "";
                TLp = 0;
                PlayerPrefs.SetFloat("para", para);
                PlayerPrefs.SetFloat("kasadaEuro", kasadaEuro);
            }
        }

    }
    
    public void SliderUpdate()
    {
        level = PlayerPrefs.GetInt("level", level);
        leveltxt.text = level.ToString();
        Deneyim.value = Guvenilirlik;
        if (Deneyim.value >= Deneyim.maxValue)
        {
            level++;
            PlayerPrefs.SetInt("level", level);
            Guvenilirlik = 0;
            PlayerPrefs.SetInt("EXP", Guvenilirlik);
        }
        Deneyim.maxValue = 20 * level;
    }
}
