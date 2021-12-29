using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;  //�ڷ�1.5�� ������
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //gameOver�����̰� ���콺 ��ư�� Ŭ�� �� ���¶��
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //���� ���� �ҷ��Ͷ�
    }
    public void PlayerHurt()  //��ģ �����̸�
    {
        gameOverText.SetActive(true);  //���ӿ��� �ؽ�Ʈ ����
        gameOver = true;  //���ӿ���
    }
    public void PlayerScored()
    {
        if (gameOver) return;    //���ӿ����ϰ�� ���ھ� �߰� �ȵ�
        score++;  //�ƴϸ� ���ھ��߰�
        scoreText.text = "Score: " + score.ToString();  //���ھ� ǥ��
    }
}
