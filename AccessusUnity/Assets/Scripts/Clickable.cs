using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    // Start is called before the first frame update
    public string operation;
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
