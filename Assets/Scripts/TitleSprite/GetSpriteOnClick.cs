using UnityEngine;
using UnityEngine.UI;

public class GetSpriteOnClick : MonoBehaviour
{
    // Button을 할당
    public Button myButton;

    void Start()
    {
        // Button에 클릭 이벤트 추가
        myButton.onClick.AddListener(GetSpriteFromButton);
    }

    // 클릭한 Button에서 Sprite 값을 가져오는 함수
    void GetSpriteFromButton()
    {
        // Image 컴포넌트에 접근
        Image buttonImage = myButton.GetComponent<Image>();

        // Image 컴포넌트의 Sprite 값 가져오기
        Sprite buttonSprite = buttonImage.sprite;

        // 가져온 스프라이트를 로그로 출력
        Debug.Log("Clicked button's sprite: " + buttonSprite.name);
    }
}