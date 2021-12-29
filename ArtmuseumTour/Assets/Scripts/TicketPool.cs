using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TicketPool : MonoBehaviour
{
    public GameObject TicketPrefab;
    public int TicketPoolSize = 3;
    public float spawnRate = 15f;    //15초마다 생성              
    public float TicketMin = -2f;    //생성위치: -2 ~ 2 랜덤              
    public float TicketMax = 2f;
    private GameObject[] Tickets;
    private int currentTicket = 0;
    private Vector2 objectPoolPosition = new Vector2(-15f, 0f);
    private float spawnXPosition = 12f;
    private float timeSinceLastSpawned;
    void Start()
    {
        timeSinceLastSpawned = 0f;
        Tickets = new GameObject[TicketPoolSize];  //3개를 만든다.
        for (int i = 0; i < TicketPoolSize; i++)
        {
            Tickets[i] = (GameObject)Instantiate(TicketPrefab,
                                    objectPoolPosition, Quaternion.identity);  //Ticket를 (-15, 0)에 일반방향으로 만들어라
        }
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;  //현재 시간
        if (GameControl.instance.gameOver == false &&
        timeSinceLastSpawned >= spawnRate)  //게임오버가 아니고 만든 시간이 15초 이상이면
        {
            timeSinceLastSpawned = 0f;  //리셋
            float spawnYPosition = Random.Range(TicketMin, TicketMax);  //-2 ~ 2사이에 랜덤하게 만들겠다.
            Start();  //Ticket.cs에서 Destroy된 티켓들을 다시 생성
            Tickets[currentTicket].transform.position =
            new Vector2(spawnXPosition, spawnYPosition);  //왔다갔다 하면서 만든다.
            currentTicket++;
            if (currentTicket >= TicketPoolSize)
            {
                currentTicket = 0;  //Ticket 3개 유지
            }
        }
    }
}
