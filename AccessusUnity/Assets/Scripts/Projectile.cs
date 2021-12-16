// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Projectile : MonoBehaviour
// {
//     public Rigidbody bulletPrefabs;
//     public Transform shootPoint;
//     public Transform pointer;
//     public GameObject cursor;
//     public LayerMask layer;

//     private Camera cam;
//     void Start()
//     {
//         cam = Camera.main;
//     }
//     Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
//     {
//         Vector3 distance = target - origin;
//         Vector3 distanceXZ = distance;
//         distanceXZ.y = 0f;

//         float Sy = distance.y;
//         float Sxz = distanceXZ.magnitude;
        
//         float Vxz = Sxz/time;
//         float Vy = Sy/time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
//         Vector3 result = distanceXZ.normalized;
//         result *= Vxz;
//         result.y = Vy;

//         return result;
//     }

//     void LaunchProjectile()
//     {
//         Ray ray = new Ray(transform.position, transform.forward);
//         Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);
//         RaycastHit hit;
//         if(Physics.Raycast(ray, out hit))
//         {
//             float currentTime = 0;
//             currentTime += Time.deltaTime;
//             pointer.position = hit.point;
//             Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
//             if(selectable)
//             {
//                 if(currentSelectable && currentSelectable != selectable)
//                 {
//                     currentSelectable.Deselect();
//                 }
//                 currentSelectable = selectable;
//                 selectable.Select();
//                 Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);
//                 cannon.transform.rotation = Quaternion.LookRotation(Vo);
//                 if(currentTime > 3)
//                 {
                    
//                     Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
//                     obj.velocity = Vo;
//                 }
//             }
//                 else
//                 {
//                     if(currentSelectable)
//                     {
//                         currentSelectable.Deselect();
//                         currentSelectable = null;
//                     }
//                 } 
//         }
//         else
//             {
//                 if(currentSelectable)
//                 {
//                     currentSelectable.Deselect();
//                     currentSelectable = null;
//                 }
//             }
//         }
//         else
//         {
//             cursor.SetActive(false);
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         LaunchProjectile();
//     }
// }
