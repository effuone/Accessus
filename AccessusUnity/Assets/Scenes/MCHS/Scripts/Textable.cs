using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textable : MonoBehaviour
{
    private float time;
    private float currentTime;
    public float startTime;
    public float inbetween;
    public string gameObjectName;
    private string text;
    private TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GameObject.Find(gameObjectName).GetComponent<TextMesh>();
        text = textMesh.text; 
        textMesh.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime % 60;
        if(time > startTime)
        {
            textMesh.text = text;
            currentTime += Time.deltaTime % 60;
            if(currentTime > inbetween)
            {
                textMesh.text = "";
            }
        }
        else
        {
            
        }
    }
}
