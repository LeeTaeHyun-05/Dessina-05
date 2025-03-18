using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VasicVaribles : MonoBehaviour
{
    public int gold = 0;           //정수형
    public float Hp = 100;              //실수형 (소수점이 있는 숫자, 끝에 'f' 필수)
    public string playerName = "홍길동";     //문자열 (문자의 집합)
    public bool isAlive = true;              //논리형 (참/거짓을 나타냄)



    // Start is called before the first frame update
    void Start()
    {
        // == 두 값이 같을 때 true
        // |= 두 값이 다르면 true
        // > 왼쪽 값이 더 크면 true
        // < 오른쪽 값이 더 크면 true 
        // >= 왼쪽 값이 더 크거나 같으면 true
        // <= 오른쪽 값이 더 크거나 같으면 true
        // 는 주석이다

        if (gold > 50)
        {
            Debug.Log("아이템을 구매할 수 있습니다");
        }
        else if (gold == 40)
        {
            Debug.Log("골드가 40원 보유 중 입니다. 10골드만 더 모으면 살 수 있어요!");
        }
        //else //if 안의 조건이 참이 아닐 때
        //{
        //    Debug.Log("골드가 부족합니다.");
        //}
    }

    //  Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))     //space를 눌렀을 때 true
        {
            gold = gold + 10;       //gold에 10골드를 추가한다
            Debug.Log("현재 골드 : " + gold);
        }
    }
}
