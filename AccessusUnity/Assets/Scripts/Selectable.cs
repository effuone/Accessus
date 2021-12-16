using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // Start is called before the first frame update
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
