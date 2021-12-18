using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    private float inbetween = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TextMesh textMesh= GameObject.Find("Counter").GetComponent<TextMesh>();
        var numberString = textMesh.text.ToString();
        int number = System.Convert.ToInt32(numberString);
        time += Time.deltaTime % 60;
        if(time > inbetween)
        {
            number--;
            textMesh.text = number.ToString();
            time = 0;
        }
        if(number - 1 == -1)
        {
            SceneManager.LoadScene (sceneName:"ProjectileMotion");
        }   
    }
}
