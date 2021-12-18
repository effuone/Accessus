using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour
{
    public GameObject text;
    private float time;
    private Vector3 pos;
    private bool isCollided;
    private TextMesh timeCounter1;
    private TextMesh heightObject;

    // Update is called once per frame
    void Start()
    {
        pos = this.transform.position;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        timeCounter1 = GameObject.Find("timeCounter1").GetComponent<TextMesh>();
        heightObject = GameObject.Find("Height").GetComponent<TextMesh>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor1")
        {
            var selectedTime = time;
            TextMesh textObject1 = GameObject.Find("timeCounter1").GetComponent<TextMesh>();
            
            textObject1.text = selectedTime.ToString();
            isCollided = true;
            var zero = 0;
            heightObject.text = zero.ToString();
        }
    }
    void LateUpdate()
    {
        if(!isCollided)
        {
        time += Time.deltaTime % 60;
        timeCounter1.text = time.ToString() + 's';
        var height = 50 + (0.5 * Physics.gravity.y * Mathf.Pow(time, 2));
        heightObject.text = ((float)height).ToString();
        }
        
    }
}
