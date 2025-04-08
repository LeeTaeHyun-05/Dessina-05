using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RaycastSooter : MonoBehaviour
{

    public ParticleSystem flashEffect;          //�߻� ����Ʈ ���� ����

    //źâ ���� ���� ����
    public int magazineCapacity = 30;          //źâ�� ũ��
    private int currentAmmo;                   //���� �Ѿ��� ����

    public TextMeshProUGUI ammoUI;

    public Image reloadingUI;
    public float reloadTime = 2f;
    private float timer = 0;
    private bool isReloading = false;

    //���� ��� ��� ���� ����
    public AudioSource audioSource;
    public AudioClip audioClip;    



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magazineCapacity;       //���� �Ѿ��� ������ źâ�� ũ�⸸ŭ ����
        //ammoUI.text = currentAmmo + "/" + magazineCapacity; 
        ammoUI.text = $"{currentAmmo}/{magazineCapacity}";     //���� �Ѿ� ������ UI�� ǥ��

        reloadingUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0) && currentAmmo > 0 && isReloading == false)
        {
            audioSource.PlayOneShot(audioClip);  //�߻� ���� ��� 
            currentAmmo--;                //�Ѿ��� 1�� �Һ��Ѵ�.
            flashEffect.Play();          //����Ʈ ���
            ammoUI.text = $"{currentAmmo}/{magazineCapacity}";       
            ShootRay();
        }    

        if(Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            reloadingUI.gameObject.SetActive (true);
        }

        if(isReloading == true)
        {
            Reloading();
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

    void Reloading()
    {
        timer += Time.deltaTime;

        reloadingUI.fillAmount = timer / reloadTime;     //������ UI�� fill���� ���� ������� ������Ʈ

        if(timer >= reloadTime)
        {
            timer = 0;
            isReloading = false ;
            currentAmmo = magazineCapacity;
            ammoUI.text = $"{currentAmmo}/{magazineCapacity}";
            reloadingUI.gameObject.SetActive(false);
        }
    }
}
