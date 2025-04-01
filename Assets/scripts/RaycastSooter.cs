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
        RaycastHit hit;                                                  //Ray�� ���� ����� ������ ������ �����

        if(Physics.Raycast(ray, out hit))                                //Raycast�� ��ȯ���� bool��, Ray�� �¾Ҵٸ� true ��ȯ
        {
            Destroy(hit.collider.gameObject);                            //���� ��� ������Ʈ�� ����  
        }
    }
}
