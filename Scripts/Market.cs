using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public Dropdown kameralar,antenler,electronics,engine,power;
    public ParaPanel ParaPanel1;
    public SATcomponents satcom;
    public List<string> item = new List<string> { };
    public List<string> itemAnten = new List<string> { };
    public List<string> itemElectronic = new List<string> { };
    public List<string> itemEngine = new List<string> { };
    public List<string> itemPower = new List<string> { };
    public GameObject teleskop, güç, motor, gövde, iletişim;
    public Button cms1,cms2,cms3,cms4;
    private bool cms1b, cms2b, cms3b, cms4b;
    private bool hr01, hr02, vhr01, vhr02;
    public Button hr01b, hr02b, vhr01b, vhr02b;
    private bool crctl, crctml, crcth, crctvh;
    public Button crctlb, crctmlb, crcthb, crctvhb;
    private bool pwr1, pwr2, pwr3, pwr4;
    public Button pwr1b, pwr2b, pwr3b, pwr4b;
    private bool eng1, eng2, eng3, eng4;
    public Button eng1b, eng2b, eng3b, eng4b;
    public Slider MainSlider, AstSlider;
    public Text loader, Mloader;
    
    void Start()
    {
      //Sıfırla();

        cms1b = bool.Parse(PlayerPrefs.GetString("kamerabool1",cms1b.ToString()));
        cms2b = bool.Parse(PlayerPrefs.GetString("kamerabool2", cms2b.ToString()));
        cms3b = bool.Parse(PlayerPrefs.GetString("kamerabool3", cms3b.ToString()));
        cms4b = bool.Parse(PlayerPrefs.GetString("kamerabool4", cms4b.ToString()));
        vhr01 = bool.Parse(PlayerPrefs.GetString("kameraboola3", vhr01.ToString()));
        vhr02 = bool.Parse(PlayerPrefs.GetString("kameraboola4", vhr02.ToString()));
        hr01 = bool.Parse(PlayerPrefs.GetString("kameraboola1", hr01.ToString()));
        hr02 = bool.Parse(PlayerPrefs.GetString("kameraboola2", hr02.ToString()));
        crctl = bool.Parse(PlayerPrefs.GetString("kameraboole1", crctl.ToString()));
        crctml = bool.Parse(PlayerPrefs.GetString("kameraboole2", crctml.ToString()));
        crcth = bool.Parse(PlayerPrefs.GetString("kameraboole3", crcth.ToString()));
        crctvh = bool.Parse(PlayerPrefs.GetString("kameraboole4", crctvh.ToString()));
        pwr1 = bool.Parse(PlayerPrefs.GetString("kameraboolp1", pwr1.ToString()));
        pwr2 = bool.Parse(PlayerPrefs.GetString("kameraboolp2", pwr2.ToString()));
        pwr3 = bool.Parse(PlayerPrefs.GetString("kameraboolp3", pwr3.ToString()));
        pwr4 = bool.Parse(PlayerPrefs.GetString("kameraboolp4", pwr4.ToString()));
        eng1 = bool.Parse(PlayerPrefs.GetString("kameraboolen1", eng1.ToString()));
        eng2 = bool.Parse(PlayerPrefs.GetString("kameraboolen2", eng2.ToString()));
        eng3 = bool.Parse(PlayerPrefs.GetString("kameraboolen3", eng3.ToString()));
        eng4 = bool.Parse(PlayerPrefs.GetString("kameraboolen4", eng4.ToString()));
       
        StartSatınAlmaDuzenleyicisi();
        StartSatınAlmaDüzenleyicisiAnten();
        StartSatınAlmaDüzenleyicisiElektronik();
        StartSatınAlmaDüzenleyicisiEngine();
        StartSatınAlmaDüzenleyicisiPower();
    }
    void Update()
    {
        //ScienceSlider();
       ParaPanel1.kasadabtc = PlayerPrefs.GetFloat("kasadabtc", ParaPanel1.kasadabtc);
        ParaPanel1.kasadaDolar = PlayerPrefs.GetFloat("kasadaDolar", ParaPanel1.kasadaDolar);
        ParaPanel1.kasadaEuro = PlayerPrefs.GetFloat("kasadaEuro", ParaPanel1.kasadaEuro);

       
       
    }
  
    public void TeleskopAc()
    {
        teleskop.SetActive(true);
        güç.SetActive(false);
        motor.SetActive(false);
        iletişim.SetActive(false);
        gövde.SetActive(false);
    }
    public void GüçAc()
    {
        teleskop.SetActive(false);
        güç.SetActive(true);
        motor.SetActive(false);
        iletişim.SetActive(false);
        gövde.SetActive(false);
    }
    public void MotorAc()
    {
        teleskop.SetActive(false);
        güç.SetActive(false);
        motor.SetActive(true);
        iletişim.SetActive(false);
        gövde.SetActive(false);
    }
    public void GövdeAc()
    {
        teleskop.SetActive(false);
        güç.SetActive(false);
        motor.SetActive(false);
        iletişim.SetActive(false);
        gövde.SetActive(true);
    }
    public void IletişimAc()
    {
        teleskop.SetActive(false);
        güç.SetActive(false);
        motor.SetActive(false);
        iletişim.SetActive(true);
        gövde.SetActive(false);
    }
    public void CMS1()
    {
        if (ParaPanel1.para >= 10000)
        {
            ParaPanel1.para -= 10000;
            PlayerPrefs.SetFloat("para", ParaPanel1.para);
            cms1b = true;
            PlayerPrefs.SetString("kamerabool1", cms1b.ToString());
            SatınAlmaDuzenleyicisi();
        }
    }
    public void CMS2()
    {
        if (ParaPanel1.kasadaDolar >= 10000)
        {
            ParaPanel1.kasadaDolar -= 10000;
            cms2b = true;

            PlayerPrefs.SetString("kamerabool1", cms1b.ToString());
            PlayerPrefs.SetString("kamerabool2", cms2b.ToString());
            SatınAlmaDuzenleyicisi();
        }
    }
    public void CMS3()
    {
        if (ParaPanel1.kasadaEuro >= 15000)
        {
            ParaPanel1.kasadaEuro -= 15000;
            cms3b = true;

            PlayerPrefs.SetString("kamerabool2", cms2b.ToString());
            PlayerPrefs.SetString("kamerabool3", cms3b.ToString());
            SatınAlmaDuzenleyicisi();
        }
    }
    public void CMS4()
    {
        if (ParaPanel1.kasadabtc >= 15)
        {
            ParaPanel1.kasadabtc -= 15;
            cms4b = true;

            PlayerPrefs.SetString("kamerabool3", cms3b.ToString());
            PlayerPrefs.SetString("kamerabool4", cms4b.ToString());
            SatınAlmaDuzenleyicisi();
        }
    }
    public void SatınAlmaDuzenleyicisi()
    {
       PlayerPrefs.SetFloat("kasadabtc",ParaPanel1.kasadabtc);
        PlayerPrefs.SetFloat("kasadaDolar", ParaPanel1.kasadaDolar);
        PlayerPrefs.SetFloat("kasadaEuro", ParaPanel1.kasadaEuro);
        cms1.interactable = true;
        cms2.interactable = false;
        cms3.interactable = false;
        cms4.interactable = false;
        if (cms1b && !cms2b)
            {                
                item.Add("CM-S1");
            cms1.interactable = false;
            cms2.interactable = true;
            cms3.interactable = false;
            cms4.interactable = false;
        }
        
            if (cms2b && !cms3b)
            {

                item.Add("CM-S2");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = true;
            cms4.interactable = false;

        }
        
       
            if (cms3b && !cms4b)
            {
                          item.Add("CM-S3");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = false;
            cms4.interactable = true;

        }
        
       
            if (cms4b)
            {         
                item.Add("CM-S4");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = false;
            cms4.interactable = false;
        }
    
        kameralar.AddOptions(item);
    }
    public void HR01()
    {
        if (ParaPanel1.para >= 10000)
        {
            ParaPanel1.para -= 10000;
            PlayerPrefs.SetFloat("para", ParaPanel1.para);
            hr01 = true;
            PlayerPrefs.SetString("kameraboola1", hr01.ToString());
            SatınAlmaDüzenleyicisiAnten();
        }
    }
    public void HR02()
    {
        if (ParaPanel1.kasadaDolar >= 10000)
        {
            ParaPanel1.kasadaDolar -= 10000;
            hr02 = true;


            PlayerPrefs.SetString("kameraboola2", hr02.ToString());
            SatınAlmaDüzenleyicisiAnten();
        }
    }
    public void VHR01()
    {
        if (ParaPanel1.kasadaEuro >= 15000)
        {
            ParaPanel1.kasadaEuro -= 15000;
            vhr01 = true;

            PlayerPrefs.SetString("kameraboola3", vhr01.ToString());
            SatınAlmaDüzenleyicisiAnten();
        }
    }
    public void VHR02()
    {
        if (ParaPanel1.kasadabtc >= 15)
        {
            ParaPanel1.kasadabtc -= 15;          
            vhr02 = true;
           PlayerPrefs.SetString("kameraboola4", vhr02.ToString());
            SatınAlmaDüzenleyicisiAnten();
        }
    }
    public void SatınAlmaDüzenleyicisiAnten()
    {
        hr01b.interactable = true;
        hr02b.interactable = false;
        vhr01b.interactable = false;
        vhr02b.interactable = false;
        if (hr01 && !hr02)
            {   
                itemAnten.Add("HR-01");
            hr01b.interactable = false;
            hr02b.interactable = true;
            vhr01b.interactable = false;
            vhr02b.interactable = false;
        }
        
       
           
            if (hr02 && !vhr01)
            {            
                itemAnten.Add("HR-02");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = true;
            vhr02b.interactable = false;

        }
        
       
            if (vhr01 && !vhr02)
            {           
                itemAnten.Add("VHR-01");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = true;
            vhr02b.interactable = false;
        }
        
       
          
            if (vhr02)
            { 
                itemAnten.Add("VHR-02");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = false;
            vhr02b.interactable = false;
        }
        antenler.AddOptions(itemAnten);
    }
    public void SatınAlmaDüzenleyicisiElektronik()
    {
        PlayerPrefs.SetFloat("kasadabtc", ParaPanel1.kasadabtc);
        PlayerPrefs.SetFloat("kasadaDolar", ParaPanel1.kasadaDolar);
        PlayerPrefs.SetFloat("kasadaEuro", ParaPanel1.kasadaEuro);
        crctlb.interactable = true;
        crctmlb.interactable = false;
        crcthb.interactable = false;
        crctvhb.interactable = false;
        if (crctl && !crctml)

            { 
                itemElectronic.Add("CRCT-L");
            crctlb.interactable = false;
            crctmlb.interactable = true;
            crcthb.interactable = false;
            crctvhb.interactable = false;
        }                       
            if (crctml && !crcth)
            {         
                itemElectronic.Add("CRCT-ML");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = true;
            crctvhb.interactable = false;
        }
        
      
           
            if (crcth && !crctvh)
            { 

                itemElectronic.Add("CRCT-H");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = false;
            crctvhb.interactable = true;

        }
        
        
            if (crctvh)
            {  
                itemElectronic.Add("CRCT-VH");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = false;
            crctvhb.interactable = false;

            }
       
        electronics.AddOptions(itemElectronic);
    }
    public void CRCTL()
    {
        if (ParaPanel1.para >= 10000)
        {
            ParaPanel1.para -= 10000;
            PlayerPrefs.SetFloat("para", ParaPanel1.para);
            crctl = true;
            PlayerPrefs.SetString("kameraboole1", crctl.ToString());
            SatınAlmaDüzenleyicisiElektronik();
        }
    }
    public void CRCTML()
    {
        if (ParaPanel1.kasadaDolar >= 10000)
        {
            ParaPanel1.kasadaDolar -= 10000;
            crctml = true;


            PlayerPrefs.SetString("kameraboole2", crctml.ToString());
            SatınAlmaDüzenleyicisiElektronik();
        }
    }
    public void CRCTH()
    {
        if (ParaPanel1.kasadaEuro >= 15000)
        {
            ParaPanel1.kasadaEuro -= 15000;
            crcth = true;

            PlayerPrefs.SetString("kameraboole3", crcth.ToString());
            SatınAlmaDüzenleyicisiElektronik();
        }
    }
    public void CRCTVH()
    {
        if (ParaPanel1.kasadabtc >= 15)
        {
            ParaPanel1.kasadabtc -= 15;
            crctvh = true;


            PlayerPrefs.SetString("kameraboole4", crctvh.ToString());
            SatınAlmaDüzenleyicisiElektronik();
        }
    }
    public void ENG1()
    {
        if (ParaPanel1.para >= 10000)
        {
            ParaPanel1.para -= 10000;
            eng1 = true;
            PlayerPrefs.SetString("kameraboolen1", eng1.ToString());
            SatınAlmaDüzenleyicisiEngine();
        }
    }
    public void ENG2()
    {
        if (ParaPanel1.kasadaDolar >= 10000)
        {
            ParaPanel1.kasadaDolar -= 10000;
            eng2 = true;


            PlayerPrefs.SetString("kameraboolen2", eng2.ToString());
            SatınAlmaDüzenleyicisiEngine();
        }
    }
    public void ENG3()
    {
        if (ParaPanel1.euro >= 15000)
        {
            ParaPanel1.euro -= 15000;
            eng3 = true;

            PlayerPrefs.SetString("kameraboolen3", eng3.ToString());
            SatınAlmaDüzenleyicisiEngine();
        }
    }
    public void ENG4()
    {
        if (ParaPanel1.kasadabtc >= 15)
        {
            ParaPanel1.kasadabtc -= 15;
            eng4 = true;


            PlayerPrefs.SetString("kameraboolen4", eng4.ToString());
            SatınAlmaDüzenleyicisiEngine();
        }
    }
    public void SatınAlmaDüzenleyicisiEngine()
    {
        PlayerPrefs.SetFloat("kasadabtc", ParaPanel1.kasadabtc);
        PlayerPrefs.SetFloat("kasadaDolar", ParaPanel1.kasadaDolar);
        PlayerPrefs.SetFloat("kasadaEuro", ParaPanel1.kasadaEuro);

        eng1b.interactable = true;
        eng2b.interactable = false;
        eng3b.interactable = false;
        eng4b.interactable = false;
        if (eng1 && !eng2)

            {
                itemEngine.Add("ENG-01");
            eng1b.interactable = false;
            eng2b.interactable = true;
            eng3b.interactable = false;
            eng4b.interactable = false;
        }
        
       
           
            if (eng2 && !eng3)
            {    
                itemEngine.Add("ENG-02");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = true;
            eng4b.interactable = false;
        }
        
       
           
            if (eng3 && !eng4)
            {           

                itemEngine.Add("ENG-03");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = false;
            eng4b.interactable = true;

        }
       
            if (eng4)
            {
                itemEngine.Add("ENG-04");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = false;
            eng4b.interactable = false;
        }
        
        engine.AddOptions(itemEngine);
    }
    public void PWR1()
    {
        if (ParaPanel1.para >= 10000)
        {
            ParaPanel1.para -= 10000;
            PlayerPrefs.SetFloat("para", ParaPanel1.para);
            pwr1 = true;
            PlayerPrefs.SetString("kameraboolp1", pwr1.ToString());
            SatınAlmaDüzenleyicisiPower();
        }
    }
    public void PWR2()
    {
        if (ParaPanel1.kasadaDolar >= 10000)
        {
            ParaPanel1.kasadaDolar -= 10000;
            pwr2 = true;
            PlayerPrefs.SetString("kameraboolp2", pwr2.ToString());
            SatınAlmaDüzenleyicisiPower();
        }
    }
    public void PWR3()
    {
        if (ParaPanel1.kasadaEuro >= 15000)
        {
            ParaPanel1.kasadaEuro -= 15000;
            pwr3 = true;
            PlayerPrefs.SetString("kameraboolp3", pwr3.ToString());
            SatınAlmaDüzenleyicisiPower();
        }
    }
    public void PWR4()
    {
        if (ParaPanel1.kasadabtc >= 15)
        {
            ParaPanel1.kasadabtc -= 15;
            pwr4 = true;
            PlayerPrefs.SetString("kameraboolp4", pwr4.ToString());
            SatınAlmaDüzenleyicisiPower();
        }
    }
    public void SatınAlmaDüzenleyicisiPower()
    {
        PlayerPrefs.SetFloat("kasadabtc", ParaPanel1.kasadabtc);
        PlayerPrefs.SetFloat("kasadaDolar", ParaPanel1.kasadaDolar);
        PlayerPrefs.SetFloat("kasadaEuro", ParaPanel1.kasadaEuro);
        pwr1b.interactable = true;
        pwr2b.interactable = false;
        pwr3b.interactable = false;
        pwr4b.interactable = false;
        if (pwr1 && !pwr2)
            {          
                itemPower.Add("PWR-01");
            pwr1b.interactable = false;
            pwr2b.interactable = true;
            pwr3b.interactable = false;
            pwr4b.interactable = false;
        }                       
            if (pwr2 && !pwr3)
            { 
                itemPower.Add("PWR-02");
            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = true;
            pwr4b.interactable = false;
        }                  
            if (pwr3 && !pwr4)
            {       
                itemPower.Add("PWR-03");
            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = false;
            pwr4b.interactable = true;
        }              
            if (pwr4)
            {
                itemPower.Add("PWR-04");
            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = false;
            pwr4b.interactable = true;

        }
        
        power.AddOptions(itemPower);
    }
   private void Sıfırla()
    {
        crctl = false;
        PlayerPrefs.SetString("kameraboole1", crctl.ToString());



        crctml = false;


        PlayerPrefs.SetString("kameraboole2", crctml.ToString());


        crcth = false;

        PlayerPrefs.SetString("kameraboole3", crcth.ToString());


        crctvh = false;


        PlayerPrefs.SetString("kameraboole4", crctvh.ToString());


        hr01 = false;
        PlayerPrefs.SetString("kameraboola1", hr01.ToString());


        hr02 = false;


        PlayerPrefs.SetString("kameraboola2", hr02.ToString());


        vhr01 = false;

        PlayerPrefs.SetString("kameraboola3", vhr01.ToString());


        vhr02 = false;


        PlayerPrefs.SetString("kameraboola4", vhr02.ToString());

        cms1b = false;
        PlayerPrefs.SetString("kamerabool1", cms1b.ToString());


        cms2b = false;

        PlayerPrefs.SetString("kamerabool1", cms1b.ToString());
        PlayerPrefs.SetString("kamerabool2", cms2b.ToString());



        cms3b = false;

        PlayerPrefs.SetString("kamerabool2", cms2b.ToString());
        PlayerPrefs.SetString("kamerabool3", cms3b.ToString());



        cms4b = false;

        PlayerPrefs.SetString("kamerabool3", cms3b.ToString());
        PlayerPrefs.SetString("kamerabool4", cms4b.ToString());
        eng1 = false;
        PlayerPrefs.SetString("kameraboolen1", eng1.ToString());

        eng2 = false;


        PlayerPrefs.SetString("kameraboolen2", eng2.ToString());


        eng3 = false;

        PlayerPrefs.SetString("kameraboolen3", eng3.ToString());


        eng4 = false;


        PlayerPrefs.SetString("kameraboolen4", eng4.ToString());
        pwr1 = false;
        PlayerPrefs.SetString("kameraboolp1", pwr1.ToString());


        pwr2 = false;


        PlayerPrefs.SetString("kameraboolp2", pwr2.ToString());


        pwr3 = false;

        PlayerPrefs.SetString("kameraboolp3", pwr3.ToString());


        pwr4 = false;


        PlayerPrefs.SetString("kameraboolp4", pwr4.ToString());

    }
    
    private void StartSatınAlmaDuzenleyicisi()
    {
        cms1.interactable = true;
        cms2.interactable = false;
        cms3.interactable = false;
        cms4.interactable = false;

        if (cms1b && !cms2b)
        {      
            item.Add("CM-S1");
            cms1.interactable = false;
            cms2.interactable = true;
            cms3.interactable = false;
            cms4.interactable = false;
        }

        if (cms2b && !cms3b)
        {
            item.Add("CM-S1");
            item.Add("CM-S2");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = true;
            cms4.interactable = false;
        }


        if (cms3b && !cms4b)
        {
            item.Add("CM-S1");
            item.Add("CM-S2");
            item.Add("CM-S3");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = false;
            cms4.interactable = true;
        }


        if (cms4b)
        {
            item.Add("CM-S1");
            item.Add("CM-S2");
            item.Add("CM-S3");
            item.Add("CM-S4");
            cms1.interactable = false;
            cms2.interactable = false;
            cms3.interactable = false;         
            cms4.interactable = false;

        }

        kameralar.AddOptions(item);
    }
    private void StartSatınAlmaDüzenleyicisiAnten()
    {
        hr01b.interactable = true;
        hr02b.interactable = false;
        vhr01b.interactable = false;
        vhr02b.interactable = false;
        if (hr01 && !hr02)
        {          
            itemAnten.Add("HR-01");
            hr01b.interactable = false;
            hr02b.interactable = true;
            vhr01b.interactable = false;
            vhr02b.interactable = false;
        }



        if (hr02 && !vhr01)
        {
            itemAnten.Add("HR-01");
            itemAnten.Add("HR-02");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = true;
            vhr02b.interactable = false;
        }


        if (vhr01 && !vhr02)
        {
            itemAnten.Add("HR-01");
            itemAnten.Add("HR-02");
            itemAnten.Add("VHR-01");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = false;
            vhr02b.interactable = true;
        }



        if (vhr02)
        {
            itemAnten.Add("HR-01");
            itemAnten.Add("HR-02");
            itemAnten.Add("VHR-01");
            itemAnten.Add("VHR-02");
            hr01b.interactable = false;
            hr02b.interactable = false;
            vhr01b.interactable = false;
            vhr02b.interactable = false;


        }
        antenler.AddOptions(itemAnten);
    }
    private void StartSatınAlmaDüzenleyicisiElektronik()
    {
        crctlb.interactable = true;
        crctmlb.interactable = false;
        crcthb.interactable = false;
        crctvhb.interactable = false;
        if (crctl && !crctml)
        {       
            itemElectronic.Add("CRCT-L");
            crctlb.interactable = false;
            crctmlb.interactable = true;
            crcthb.interactable = false;
            crctvhb.interactable = false;
        }



        if (crctml && !crcth)
        {
            itemElectronic.Add("CRCT-L");
            itemElectronic.Add("CRCT-ML");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = true;
            crctvhb.interactable = false;
        }



        if (crcth && !crctvh)
        {
            itemElectronic.Add("CRCT-L");
            itemElectronic.Add("CRCT-ML");
            itemElectronic.Add("CRCT-H");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = false;
            crctvhb.interactable = true;
        }


        if (crctvh)
        {
            itemElectronic.Add("CRCT-L");
            itemElectronic.Add("CRCT-ML");
            itemElectronic.Add("CRCT-H");
            itemElectronic.Add("CRCT-VH");
            crctlb.interactable = false;
            crctmlb.interactable = false;
            crcthb.interactable = false;
            crctvhb.interactable = false;

        }

        electronics.AddOptions(itemElectronic);
    }
    public void StartSatınAlmaDüzenleyicisiEngine()
    {
        eng1b.interactable = true;
        eng2b.interactable = false;
        eng3b.interactable = false;
        eng4b.interactable = false;

        if (eng1 && !eng2)
        {          
            itemEngine.Add("ENG-01");
            eng1b.interactable = false;
            eng2b.interactable = true;
            eng3b.interactable = false;
            eng4b.interactable = false;
        }



        if (eng2 && !eng3)
        {
            itemEngine.Add("ENG-01");
            itemEngine.Add("ENG-02");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = true;
            eng4b.interactable = false;

        }



        if (eng3 && !eng4)
        {
            itemEngine.Add("ENG-01");
            itemEngine.Add("ENG-02");
            itemEngine.Add("ENG-03");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = false;
            eng4b.interactable = true;
        }

        if (eng4)
        {
            itemEngine.Add("ENG-01");
            itemEngine.Add("ENG-02");
            itemEngine.Add("ENG-03");
            itemEngine.Add("ENG-04");
            eng1b.interactable = false;
            eng2b.interactable = false;
            eng3b.interactable = false;
            eng4b.interactable = true;
        }

        engine.AddOptions(itemEngine);
    }
    private void StartSatınAlmaDüzenleyicisiPower()
    {
        pwr1b.interactable = true;
        pwr2b.interactable = false;
        pwr3b.interactable = false;
        pwr4b.interactable = false;
        if (pwr1 && !pwr2)
        {
            itemPower.Add("PWR-01");

            pwr1b.interactable = false;
            pwr2b.interactable = true;
            pwr3b.interactable = false;
            pwr4b.interactable = false;
        }



        if (pwr2 && !pwr3)
        {
            itemPower.Add("PWR-01");
            itemPower.Add("PWR-02");

            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = true;
            pwr4b.interactable = false;
        }



        if (pwr3 && !pwr4)
        {
            itemPower.Add("PWR-01");
            itemPower.Add("PWR-02");
            itemPower.Add("PWR-03");

            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = false;
            pwr4b.interactable = true;
        }



        if (pwr4)
        {
            itemPower.Add("PWR-01");
            itemPower.Add("PWR-02");
            itemPower.Add("PWR-03");
            itemPower.Add("PWR-04");
            pwr1b.interactable = false;
            pwr2b.interactable = false;
            pwr3b.interactable = false;
            pwr4b.interactable = false;

        }

        power.AddOptions(itemPower);
    }
}
