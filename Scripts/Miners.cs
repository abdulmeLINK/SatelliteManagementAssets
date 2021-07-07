using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Miners : MonoBehaviour
{
    public int id;
    public string kayıt;
    private Slider Sliders1,Sliders2;
    public fırlatma firlatma;
    AnimMoverComponent btn;
    void Start()
    { 
       id = int.Parse(transform.Find("Text").GetComponent<Text>().text);
        kayıt = "miner" + id.ToString();

        Sliders1 = transform.GetChild(0).GetComponent<Slider>();
        Sliders2 = transform.GetChild(1).GetComponent<Slider>();
       
        btn = transform.GetChild(2).GetComponent<AnimMoverComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (id <= firlatma.Askeriuydu) {
          
            GetFromChildAndHandle();
        }
        
    }
    void GetFromChildAndHandle()
    {
        
         Sliders1.value += firlatma.askeriKalite*Time.deltaTime;
            if (Sliders1.maxValue == Sliders1.value)
            {
                Sliders2.value += 1;
            Sliders1.value = 0;
            }
            if(Sliders2.value == Sliders2.maxValue)
            {
            btn = transform.GetChild(2).GetComponent<AnimMoverComponent>();
            btn.Skor = PlayerPrefs.GetInt(kayıt, btn.Skor);
            btn.Skor += 1;         
            PlayerPrefs.SetInt(kayıt, btn.Skor);       
            Sliders2.value = 0;

        }
        
    }
}
