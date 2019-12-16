using NUDev.PlusSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string st = "aaa";
        Debug.Log(st.RandomString(7));
        Debug.Log(st);
        Debug.Log(st.RandomString(7, "ABCDEFG"));
        Debug.Log(st);
        Debug.Log("I remember that".Split(3).Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
