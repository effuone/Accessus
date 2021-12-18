using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public abstract class XRLoaderScript : ScriptableObject
{
    // Start is called before the first frame update
    public virtual bool Initialize()
    {
        XRLoader xr = new XRLoader();
        return xr.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
