using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)  //LePenseur�� �ٸ� ��ü �浹�� �̺�Ʈ �߻�
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)  //player�� �浹�� ���� �� ���
        {
            player.ChangeHealth(-1); //ü��-1
        }
    }
}
