using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthBar : MonoBehaviour
{
    // 다른 스크립트에서 참조를 사용할 필요 없이 UIHealthBar스크립트에 액세스 가능
    // private set : 외부에서 해당 스크립트를 변경하지 못하도록 함 
    public static UIHealthBar instance { get; private set; }
    public Image mask;
    float originalSize;
    void Awake()
    {
        instance = this;   // 현재 해당 함수를 실행하고 있는 오브젝트 할당 
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;  // 마스크의 가로 크기
    }
    public void SetValue(float value)
    {
        // 앵커와 피봇 기준으로 마스크의 가로크기 왼쪽으로 줄어들게 변경
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
