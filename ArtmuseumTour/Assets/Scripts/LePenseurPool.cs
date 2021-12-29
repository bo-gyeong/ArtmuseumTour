using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LePenseurPool : MonoBehaviour
{
    public GameObject LePenseurPrefab;
    public int LePenseurPoolSize = 5;         
    public float spawnRate = 3f;        //3초마다 생성              
    public float LePenseurMin = -2f;    //생성위치: -2 ~ 2 랜덤              
    public float LePenseurMax = 2f;
    private GameObject[] LePenseurs;
    private int currentLePenseur = 0;
    private Vector2 objectPoolPosition = new Vector2(-15f, 0f);
    private float spawnXPosition = 12f;
    private float timeSinceLastSpawned;
    void Start()
    {
        timeSinceLastSpawned = 0f;
        LePenseurs = new GameObject[LePenseurPoolSize];  //5개를 만든다.
        for (int i = 0; i < LePenseurPoolSize; i++)
        {
            LePenseurs[i] = (GameObject)Instantiate(LePenseurPrefab,
                                    objectPoolPosition, Quaternion.identity);  //LePenseurPrefab를 (-15, 0)에 일반방향으로 만들어라
        }
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;  //현재 시간
        if (GameControl.instance.gameOver == false &&
        timeSinceLastSpawned >= spawnRate)  //게임오버가 아니고 만든 시간이 3초 이상이면
        {
            timeSinceLastSpawned = 0f;  //리셋
            float spawnYPosition = Random.Range(LePenseurMin, LePenseurMax);  //-2 ~ 2사이에 랜덤하게 만들겠다.
            LePenseurs[currentLePenseur].transform.position =
            new Vector2(spawnXPosition, spawnYPosition);  //왔다갔다 하면서 만든다.
            currentLePenseur++;
            if (currentLePenseur >= LePenseurPoolSize)
            {
                currentLePenseur = 0;  //LePenseur 5개 유지
            }
        }
    }
}
