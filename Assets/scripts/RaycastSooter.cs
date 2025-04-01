using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSooter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0))
        {
            ShootRay();
        }    
    }


    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;                                                  //Ray를 맞은 대상의 정보를 저장할 저장소

        if(Physics.Raycast(ray, out hit))                                //Raycast의 반환형은 bool로, Ray를 맞았다면 true 반환
        {
            Destroy(hit.collider.gameObject);                            //맞은 대상 오브젝트를 제거  
        }
    }
}
