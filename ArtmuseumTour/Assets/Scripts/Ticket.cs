using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)  //�ٸ� ��ü�� �浹�� �߻��ϸ�
    {
        Player player = other.GetComponent<Player>();  //player ���� ������Ʈ�� ������Ʈ�� ��´�.
        if (player != null)  //player�̰�
        {
            if (player.health < player.maxHealth && player.health!=0)  //���� ü���� maxHealth���� �۰� 0�� �ƴϸ�
            {
                player.ChangeHealth(1); //ü��+1
                player.PlaySound(collectedClip);  //PlaySoundȣ��
            }
            Destroy(gameObject);  //ticket�� ���ش�
        }
    }
}
