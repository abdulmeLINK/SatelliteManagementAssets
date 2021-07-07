using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimMoverComponent : MonoBehaviour
{
    public int Skor;
    public GameObject Target;
    GameObject kopya;
    public float destroyTime;
    bool clicked;
    public string kayıt;
    DataHandlerS veri;
    void Start()
    {
        veri = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataHandlerS>();  
        Skor = PlayerPrefs.GetInt(kayıt, Skor);
        veri.ScienceScor = PlayerPrefs.GetInt("bilimpuan", veri.ScienceScor);
     
    }
    public void Click()
    {
        if (veri.isAcitvate)
        {
            kopya = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
            kopya.transform.SetParent(transform, false);
            veri.ScienceScor = PlayerPrefs.GetInt("bilimpuan", veri.ScienceScor);
            veri.ScienceScor += Skor;
            PlayerPrefs.SetInt("bilimpuan", veri.ScienceScor);
            Skor = PlayerPrefs.GetInt(kayıt, Skor);
            Debug.Log(kayıt + ": " + Skor);
            PlayerPrefs.SetInt(kayıt, Skor = 0);
            clicked = true;
        }
    }
    public void Anim()
    {
        
      kopya.transform.position = Vector3.MoveTowards(kopya.transform.position, Target.transform.position, 250 * Time.deltaTime);
        if (kopya.transform.position == Target.transform.position)
        {
            Destroy(kopya);
            clicked = false;
        }
    }
    void Update()
    {
        kayıt = "miner" + gameObject.transform.GetComponentInParent<Miners>().id.ToString();
        Skor = PlayerPrefs.GetInt(kayıt, Skor);
        if (clicked)
        {
            Anim();
        }

        if (Skor > 0)                  
            GetComponentInChildren<Text>().text = PlayerPrefs.GetInt(kayıt, Skor).ToString();     
        else
            GetComponentInChildren<Text>().text = "";

    }
}
