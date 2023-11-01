using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float threshold;
    public float switchesFlicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchesFlicked == threshold)
        {
            gameObject.SetActive(false);
        }
    }
}
