using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)  //다른 물체와 충돌이 발생하면
    {
        Player player = other.GetComponent<Player>();  //player 게임 오브젝트에 컴포넌트를 얻는다.
        if (player != null)  //player이고
        {
            if (player.health < player.maxHealth && player.health!=0)  //현재 체력이 maxHealth보다 작고 0이 아니면
            {
                player.ChangeHealth(1); //체력+1
                player.PlaySound(collectedClip);  //PlaySound호출
            }
            Destroy(gameObject);  //ticket을 없앤다
        }
    }
}
