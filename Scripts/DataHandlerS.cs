using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandlerS : MonoBehaviour
{
    public GameObject fillOB;
    public Text DurumTXT,FillobDurumtxt;
    public bool isAcitvate;
    public Text ScienceScorTXT;
    public int ScienceScor;
    void Start()
    {
      
        ScienceScor = PlayerPrefs.GetInt("bilimpuan",ScienceScor);
        ScienceScorTXT.text = ScienceScor.ToString();
        fillOB.transform.position = new Vector3(-195, transform.position.y, transform.position.z);
    }
    public void Tıklama()
    {
        fillOB.transform.position = new Vector3(195, transform.position.y, transform.position.z);
        isAcitvate = true;  
    }
    void Update()
    {
        ScienceScor = PlayerPrefs.GetInt("bilimpuan", ScienceScor);
        ScienceScorTXT.text = ScienceScor.ToString();
        if (fillOB.transform.position == new Vector3(195,transform.position.y,transform.position.z))
        {
            DurumTXT.text = "VERİ MADENLERİ AÇIK";
            FillobDurumtxt.text = "ON";
            FillobDurumtxt.color = new Color(0,255,0);
            DurumTXT.color = new Color(0, 255, 0);
        }
        else
        {
           
            DurumTXT.text = "VERİ MADENLERİ KAPALI";
            FillobDurumtxt.text = "OFF";
            FillobDurumtxt.color = new Color(0, 255, 0);
            DurumTXT.color = new Color(255, 0, 0);
        }

    }
    
}
