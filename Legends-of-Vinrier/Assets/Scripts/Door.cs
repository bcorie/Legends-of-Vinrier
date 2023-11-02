using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int threshold;
    public int switchesFlicked;
    public Sprite[] sprites;
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
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0+switchesFlicked];
        }
    }
}
