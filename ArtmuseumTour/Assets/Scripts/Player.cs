using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public float upForce;
    private Rigidbody2D rb2d;
    private Animator anim;
    public int maxHealth = 3;  //�ִ� ü��3
    public float timeInvincible = 4.0f;    // 4�� ���� ����
    public int health { get { return currentHealth; } }  //���� ü�� �б⸸ �� �� �ִ� ������Ƽ�� ���
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
        if (currentHealth != 0) //���� ü���� 0�� �ƴ� ��
        {
            if (Input.GetMouseButtonDown(0))  //���콺 ���ʹ�ư�� ������ Input.GetTouch(0).phase==TouchPhase.Began
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));  //y���� ���� �����ν� ���� �ö󰡰� �ȴ�.
                anim.SetTrigger("Run1");  //Run1�ִϸ��̼� ����
            }
        }
        if (isInvincible)  //���������̸�
        {
            invincibleTimer -= Time.deltaTime;  //���������ð�-����ð�
            if (invincibleTimer < 0)
                isInvincible = false;     // ���� �����ð��� ������ ���� ����
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);  //���� ��ġ�� pos ������ ����
        if (pos.x < 0f) pos.x = 0f;  //���� ȭ�� ������ ������ �ƹ��� �������� �̵��Ϸ��� �ص� 0f
        if (pos.x > 1f) pos.x = 1f;  //������ ȭ�� ������ ������ �ƹ��� ���������� �̵��Ϸ��� �ص� 1f
        if (pos.y < 0f) pos.y = 0f;  //�Ʒ��� ȭ�� ������ ������ �ƹ��� �Ʒ������� �̵��Ϸ��� �ص� 0f
        if (pos.y > 1f) pos.y = 1f;  //���� ȭ�� ������ ������ �ƹ��� �������� �̵��Ϸ��� �ص� 1f
        transform.position = Camera.main.ViewportToWorldPoint(pos);  //�� ��ġ�� ����
    }
    void OnCollisionEnter2D(Collision2D other)  //�ٸ� ��ü�� �浹�� �Ǹ�
    {
        if (other.gameObject == floor1 || other.gameObject == floor2)  //floor1�̳� floor2�� �浹�� �Ͼ��
        {
            currentHealth = 0;  //���� ü�� = 0
            rb2d.velocity = Vector2.zero;  //��ĥ �� �ڷ� �и��� �ʵ���
            anim.SetTrigger("Hurt");  //Hurt�ִϸ��̼� ����
            PlaySound(hitSound);  //hitSound���
            GameControl.instance.PlayerHurt();  //PlayerHurt�� �ҷ��Ͷ�
        }
        if (currentHealth == 0)  //���� ü���� 0�̸�
        {
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Hurt");
            GameControl.instance.PlayerHurt();
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)  //amount�� �����̸�
        {
            if (isInvincible) return;   // �����̸� ����, ü�°��� ����
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(hitSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  //���� ���� ������ 0���� ���� maxHealth�̻��� ���� ���͵� maxHealth�� ����
        Debug.Log(currentHealth + "/" + maxHealth);  //�α׿��ٰ� ��´�.
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);  //ü�°� set
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);  //�Ҹ� ���
    }

}