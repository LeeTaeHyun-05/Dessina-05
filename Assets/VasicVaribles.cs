using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VasicVaribles : MonoBehaviour
{
    public int gold = 0;           //������
    public float Hp = 100;              //�Ǽ��� (�Ҽ����� �ִ� ����, ���� 'f' �ʼ�)
    public string playerName = "ȫ�浿";     //���ڿ� (������ ����)
    public bool isAlive = true;              //���� (��/������ ��Ÿ��)



    // Start is called before the first frame update
    void Start()
    {
        // == �� ���� ���� �� true
        // |= �� ���� �ٸ��� true
        // > ���� ���� �� ũ�� true
        // < ������ ���� �� ũ�� true 
        // >= ���� ���� �� ũ�ų� ������ true
        // <= ������ ���� �� ũ�ų� ������ true
        // �� �ּ��̴�

        if (gold > 50)
        {
            Debug.Log("�������� ������ �� �ֽ��ϴ�");
        }
        else if (gold == 40)
        {
            Debug.Log("��尡 40�� ���� �� �Դϴ�. 10��常 �� ������ �� �� �־��!");
        }
        //else //if ���� ������ ���� �ƴ� ��
        //{
        //    Debug.Log("��尡 �����մϴ�.");
        //}
    }

    //  Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))     //space�� ������ �� true
        {
            gold = gold + 10;       //gold�� 10��带 �߰��Ѵ�
            Debug.Log("���� ��� : " + gold);
        }
    }
}
