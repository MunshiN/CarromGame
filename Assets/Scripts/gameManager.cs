using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int count = 0;
    public GameObject gA;
    public GameObject gB;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 2 == 0)
        {
            gA.SetActive(true);
            gB.SetActive(false);
        }
        else
        {
            gA.SetActive(false);
            gB.SetActive(true);
        }
    }
}
