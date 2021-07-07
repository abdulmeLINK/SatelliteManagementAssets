using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Isci : MonoBehaviour
{
    public Text işçiText;
    public int işçi;
    public ParaPanel stbar;
    public GameObject maincam;

    // Use this for initialization
    void Start()
    {
        stbar = maincam.GetComponent<ParaPanel>();

    }

    // Update is called once per frame
   
  
}
