using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LePenseurPool : MonoBehaviour
{
    public GameObject LePenseurPrefab;
    public int LePenseurPoolSize = 5;         
    public float spawnRate = 3f;        //3�ʸ��� ����              
    public float LePenseurMin = -2f;    //������ġ: -2 ~ 2 ����              
    public float LePenseurMax = 2f;
    private GameObject[] LePenseurs;
    private int currentLePenseur = 0;
    private Vector2 objectPoolPosition = new Vector2(-15f, 0f);
    private float spawnXPosition = 12f;
    private float timeSinceLastSpawned;
    void Start()
    {
        timeSinceLastSpawned = 0f;
        LePenseurs = new GameObject[LePenseurPoolSize];  //5���� �����.
        for (int i = 0; i < LePenseurPoolSize; i++)
        {
            LePenseurs[i] = (GameObject)Instantiate(LePenseurPrefab,
                                    objectPoolPosition, Quaternion.identity);  //LePenseurPrefab�� (-15, 0)�� �Ϲݹ������� ������
        }
    }
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;  //���� �ð�
        if (GameControl.instance.gameOver == false &&
        timeSinceLastSpawned >= spawnRate)  //���ӿ����� �ƴϰ� ���� �ð��� 3�� �̻��̸�
        {
            timeSinceLastSpawned = 0f;  //����
            float spawnYPosition = Random.Range(LePenseurMin, LePenseurMax);  //-2 ~ 2���̿� �����ϰ� ����ڴ�.
            LePenseurs[currentLePenseur].transform.position =
            new Vector2(spawnXPosition, spawnYPosition);  //�Դٰ��� �ϸ鼭 �����.
            currentLePenseur++;
            if (currentLePenseur >= LePenseurPoolSize)
            {
                currentLePenseur = 0;  //LePenseur 5�� ����
            }
        }
    }
}
