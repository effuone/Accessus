using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Rigidbody bulletPrefabs;
    public Transform pointer;
    public Transform shootPoint;
    public Selectable currentSelectable;
    private Material material;
    public GameObject cannon;
    public int betweenTime;
    public float collisionTime = 1f;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Material>();
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
    void OnCollisionEnter(Collision collision)
    {
        this.material = material;
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
                Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, collisionTime);
                    cannon.transform.rotation = Quaternion.LookRotation(Vo);
                if(currentTime >=betweenTime)
                {
                    currentTime = 0;
                    
                    Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                    obj.velocity = Vo;
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
