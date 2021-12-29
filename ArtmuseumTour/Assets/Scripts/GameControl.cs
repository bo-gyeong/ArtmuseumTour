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
    public float scrollSpeed = -1.5f;  //뒤로1.5씩 가도록
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //gameOver상태이고 마우스 버튼이 클릭 된 상태라면
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //게임 씬을 불러와라
    }
    public void PlayerHurt()  //다친 상태이면
    {
        gameOverText.SetActive(true);  //게임오버 텍스트 띄우기
        gameOver = true;  //게임오버
    }
    public void PlayerScored()
    {
        if (gameOver) return;    //게임오버일경우 스코어 추가 안됨
        score++;  //아니면 스코어추가
        scoreText.text = "Score: " + score.ToString();  //스코어 표시
    }
}
