using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public float upForce;
    private Rigidbody2D rb2d;
    private Animator anim;
    public int maxHealth = 3;  //최대 체력3
    public float timeInvincible = 4.0f;    // 4초 동안 무적
    public int health { get { return currentHealth; } }  //현재 체력 읽기만 할 수 있는 프로퍼티를 사용
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    public GameObject floor1;
    public GameObject floor2;
    AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (currentHealth != 0) //현재 체력이 0이 아닐 때
        {
            if (Input.GetMouseButtonDown(0))  //마우스 왼쪽버튼을 누르면 Input.GetTouch(0).phase==TouchPhase.Began
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));  //y값에 힘을 줌으로써 위로 올라가게 된다.
                anim.SetTrigger("Run1");  //Run1애니메이션 적용
            }
        }
        if (isInvincible)  //무적상태이면
        {
            invincibleTimer -= Time.deltaTime;  //남은무적시간-현재시간
            if (invincibleTimer < 0)
                isInvincible = false;     // 남은 무적시간이 없으면 무적 해지
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);  //현재 위치를 pos 변수에 대입
        if (pos.x < 0f) pos.x = 0f;  //왼쪽 화면 밖으로 나가면 아무리 왼쪽으로 이동하려고 해도 0f
        if (pos.x > 1f) pos.x = 1f;  //오른쪽 화면 밖으로 나가면 아무리 오른쪽으로 이동하려고 해도 1f
        if (pos.y < 0f) pos.y = 0f;  //아래쪽 화면 밖으로 나가면 아무리 아래쪽으로 이동하려고 해도 0f
        if (pos.y > 1f) pos.y = 1f;  //위쪽 화면 밖으로 나가면 아무리 위쪽으로 이동하려고 해도 1f
        transform.position = Camera.main.ViewportToWorldPoint(pos);  //현 위치에 삽입
    }
    void OnCollisionEnter2D(Collision2D other)  //다른 물체랑 충돌이 되면
    {
        if (other.gameObject == floor1 || other.gameObject == floor2)  //floor1이나 floor2와 충돌이 일어나면
        {
            currentHealth = 0;  //현재 체력 = 0
            rb2d.velocity = Vector2.zero;  //다칠 때 뒤로 밀리지 않도록
            anim.SetTrigger("Hurt");  //Hurt애니메이션 적용
            PlaySound(hitSound);  //hitSound재생
            GameControl.instance.PlayerHurt();  //PlayerHurt를 불러와라
        }
        if (currentHealth == 0)  //현재 체력이 0이면
        {
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Hurt");
            GameControl.instance.PlayerHurt();
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)  //amount가 음수이면
        {
            if (isInvincible) return;   // 무적이면 리턴, 체력감소 없음
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(hitSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  //음수 값이 나오면 0으로 통일 maxHealth이상의 값이 나와도 maxHealth로 통일
        Debug.Log(currentHealth + "/" + maxHealth);  //로그에다가 찍는다.
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);  //체력값 set
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);  //소리 재생
    }

}