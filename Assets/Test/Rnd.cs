using NUDev.PlusSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("sa".RandomString(7));
        Debug.Log("sa".RandomString(7, "ABCDEFG"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
