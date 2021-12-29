using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LePenseur : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
            GameControl.instance.PlayerScored();  //player가 들어가게 되면 점수를 줘라
    }

}
