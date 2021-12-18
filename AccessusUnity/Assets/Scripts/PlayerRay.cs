using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Rigidbody bulletPrefabs;
    public Transform pointer;
    public Transform shootPoint;
    private Clickable currentClickable;
    private Selectable currentSelectable;
    private TextMesh textObject;
    public GameObject cannon;
    public int betweenTime;
    private float collisionTime = 1f;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Seconds").GetComponent<TextMesh>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        
        float Vxz = Sxz/time;
        float Vy = Sy/time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }

    void LaunchProjectile()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            pointer.position = hit.point;
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            Clickable clickable = hit.collider.gameObject.GetComponent<Clickable>();
            if(selectable)
            {
                if(currentSelectable && currentSelectable != selectable)
                {
                    currentSelectable.Deselect();
                    currentTime = 0;
                }
                currentSelectable = selectable;
                selectable.Select();
                currentTime += Time.deltaTime % 60;
                Debug.Log(currentTime);
                Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, (float)collisionTime);
                cannon.transform.rotation = Quaternion.LookRotation(Vo);
                
                if(currentTime >=betweenTime)
                {
                    currentTime = 0;
                    
                    Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                    
                    obj.velocity = Vo;

                    TextMesh velocityObject = GameObject.Find("velocityValue").GetComponent<TextMesh>();
                    var velocity = Vo.magnitude;
                    velocityObject.text = velocity.ToString() + "m/s";

                    TextMesh angleObject = GameObject.Find("angleValue").GetComponent<TextMesh>();
                    var angle = 360f - cannon.transform.rotation.eulerAngles.x;
                    angleObject.text = angle.ToString() + '*';

                    TextMesh ditanceObject = GameObject.Find("distanceValue").GetComponent<TextMesh>();
                    var distance = hit.point - shootPoint.position;
                    ditanceObject.text = angle.ToString() + 'm';
                }
            }
            else
            {
                if(currentSelectable)
                {
                    currentTime = 0;
                    currentSelectable.Deselect();
                    currentSelectable = null;
                }
            } 
            if(clickable)
            {
                if(currentClickable && currentClickable != clickable)
                {
                    currentClickable.Deselect();
                    currentTime = 0;
                }
                currentClickable = clickable;
                clickable.Select();
                currentTime += Time.deltaTime % 60;
                // Debug.Log(currentTime);
                
                var text = textObject.text.ToString();
                collisionTime = float.Parse(text);
                
                if(currentTime >= 0.3)
                {
                    if(collisionTime - 0.1f == 0)
                    {
                        collisionTime += 0.1f;
                    }
                    if(clickable.operation == "Plus")
                    {
                        collisionTime+=0.1f;
                        currentTime = 0;   
                    }
                    else if(clickable.operation == "Minus")
                    {
                        collisionTime-=0.1f; 
                        currentTime = 0;
                    }
                    else
                    {
                        collisionTime-=0;
                        currentTime = 0;
                    }
                    textObject.text = collisionTime.ToString();
                }  
            }
            else
            {
                if(currentClickable)
                {
                    currentTime = 0;
                    currentClickable.Deselect();
                    currentClickable = null;
                }
            }
        }
        else
            {
                if(currentSelectable)
                {
                    currentSelectable.Deselect();
                    currentSelectable = null;
                }
            }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        
        LaunchProjectile();
    }
}
