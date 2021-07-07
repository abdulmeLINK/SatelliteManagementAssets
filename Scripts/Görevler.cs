using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Görevler : MonoBehaviour
{
    GameObject panel;
    public float Şart,Ödül;
    public string a;
    void Start()
    {   
        panel = gameObject;
       
    }
    void Update()
    {
        Şart = float.Parse(a);
        Debug.Log(a);
    }
}
