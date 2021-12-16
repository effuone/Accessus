using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeInSecondsP;
    public static int secondsP;
 
    internal void Update()
    {
        timeInSecondsP += Time.deltaTime;
        secondsP = (int)(timeInSecondsP % 60);
    }
}
