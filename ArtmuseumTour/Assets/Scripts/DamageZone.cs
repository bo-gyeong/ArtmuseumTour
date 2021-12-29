using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)  //LePenseur랑 다른 물체 충돌시 이벤트 발생
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)  //player랑 충돌이 나게 될 경우
        {
            player.ChangeHealth(-1); //체력-1
        }
    }
}
