using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    private void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;  //x�����ŭ�� ���̸� ����(20.48)
    }
    private void Update()
    {
        if (transform.position.x < -groundHorizontalLength)  //-groundHorizontalLength���� ������
            RepositionBackground();  // RepositionBackground�� �θ���.
    }
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;  //Floor(1)���� ���� �ٽ� Floorī��
    }
}
