using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TicketPool : MonoBehaviour
{
    public GameObject TicketPrefab;
    public int TicketPoolSize = 3;
    public float spawnRate = 15f;    //15�ʸ��� ����              
    public float TicketMin = -2f;    //������ġ: -2 ~ 2 ����              
    public float TicketMax = 2f;
    private GameObject[] Tickets;
    private int currentTicket = 0;
    private Vector2 objectPoolPosition = new Vector2(-15f, 0f);
    private float spawnXPosition = 12f;
    private float timeSinceLastSpawned;
    void Start()
    {
        timeSinceLastSpawned = 0f;
        Tickets = new GameObject[TicketPoolSize];  //3���� �����.
        for (int i = 0; i < TicketPoolSize; i++)
        {
            Tickets[i] = (GameObject)Instantiate(TicketPrefab,
                                    objectPoolPosition, Quaternion.identity);  //Ticket�� (-15, 0)�� �Ϲݹ������� ������
        }
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;  //���� �ð�
        if (GameControl.instance.gameOver == false &&
        timeSinceLastSpawned >= spawnRate)  //���ӿ����� �ƴϰ� ���� �ð��� 15�� �̻��̸�
        {
            timeSinceLastSpawned = 0f;  //����
            float spawnYPosition = Random.Range(TicketMin, TicketMax);  //-2 ~ 2���̿� �����ϰ� ����ڴ�.
            Start();  //Ticket.cs���� Destroy�� Ƽ�ϵ��� �ٽ� ����
            Tickets[currentTicket].transform.position =
            new Vector2(spawnXPosition, spawnYPosition);  //�Դٰ��� �ϸ鼭 �����.
            currentTicket++;
            if (currentTicket >= TicketPoolSize)
            {
                currentTicket = 0;  //Ticket 3�� ����
            }
        }
    }
}
