using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cek : MonoBehaviour
{

    public GameObject background;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cek()
    {
        background.transform.position = gameObject.transform.position;
    }
}
