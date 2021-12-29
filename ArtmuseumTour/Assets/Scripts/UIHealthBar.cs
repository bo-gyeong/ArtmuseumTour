using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthBar : MonoBehaviour
{
    // �ٸ� ��ũ��Ʈ���� ������ ����� �ʿ� ���� UIHealthBar��ũ��Ʈ�� �׼��� ����
    // private set : �ܺο��� �ش� ��ũ��Ʈ�� �������� ���ϵ��� �� 
    public static UIHealthBar instance { get; private set; }
    public Image mask;
    float originalSize;
    void Awake()
    {
        instance = this;   // ���� �ش� �Լ��� �����ϰ� �ִ� ������Ʈ �Ҵ� 
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;  // ����ũ�� ���� ũ��
    }
    public void SetValue(float value)
    {
        // ��Ŀ�� �Ǻ� �������� ����ũ�� ����ũ�� �������� �پ��� ����
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
