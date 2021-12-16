using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CameraTransform;
    public float Size = 0.01f;

    // Update is called once per frame
    void LateUpdate()
    {
        float scale = Vector3.Distance(transform.position, CameraTransform.position);
        transform.localScale = Vector3.one * scale * Size;
    }
}
