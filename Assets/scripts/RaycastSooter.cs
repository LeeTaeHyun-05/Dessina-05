using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RaycastSooter : MonoBehaviour
{

    public ParticleSystem flashEffect;          //발사 이펙트 변수 선언

    //탄창 관련 변수 선언
    public int magazineCapacity = 30;          //탄창의 크기
    private int currentAmmo;                   //현재 총알의 갯수

    public TextMeshProUGUI ammoUI;

    public Image reloadingUI;
    public float reloadTime = 2f;
    private float timer = 0;
    private bool isReloading = false;

    //사운드 출력 기능 변수 선언
    public AudioSource audioSource;
    public AudioClip audioClip;    



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magazineCapacity;       //현재 총알의 갯수를 탄창의 크기만큼 변경
        //ammoUI.text = currentAmmo + "/" + magazineCapacity; 
        ammoUI.text = $"{currentAmmo}/{magazineCapacity}";     //현재 총알 개수를 UI에 표시

        reloadingUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0) && currentAmmo > 0 && isReloading == false)
        {
            audioSource.PlayOneShot(audioClip);  //발사 사운드 재생 
            currentAmmo--;                //총알을 1개 소비한다.
            flashEffect.Play();          //이펙트 재생
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
        RaycastHit hit;                                                  //Ray를 맞은 대상의 정보를 저장할 저장소

        if(Physics.Raycast(ray, out hit))                                //Raycast의 반환형은 bool로, Ray를 맞았다면 true 반환
        {
            Destroy(hit.collider.gameObject);                            //맞은 대상 오브젝트를 제거  
        }
    }

    void Reloading()
    {
        timer += Time.deltaTime;

        reloadingUI.fillAmount = timer / reloadTime;     //재장전 UI의 fill값을 현재 진행률로 업데이트

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
