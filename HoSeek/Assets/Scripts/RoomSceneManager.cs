using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviour
{
    public GameObject[] roomPanels; // 4개의 방 화면 (정면, 오른쪽, 뒤, 왼쪽)
    public Button leftButton; // 왼쪽 이동 버튼
    public Button rightButton; // 오른쪽 이동 버튼

    private int currentRoomIndex = 0; // 현재 방 화면 인덱스 (0: 정면, 1: 오른쪽, 2: 뒤, 3: 왼쪽)

    void Start()
    {
        // 처음에는 정면 방 화면만 활성화
        UpdateRoomPanels();

        // UI 버튼 클릭 이벤트 설정
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        // 키보드 입력 처리
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    // 왼쪽으로 이동
    public void MoveLeft()
    {
        currentRoomIndex = (currentRoomIndex - 1 + roomPanels.Length) % roomPanels.Length;
        UpdateRoomPanels();
    }

    // 오른쪽으로 이동
    public void MoveRight()
    {
        currentRoomIndex = (currentRoomIndex + 1) % roomPanels.Length;
        UpdateRoomPanels();
    }

    // 현재 방 화면만 활성화하고 나머지는 비활성화
    private void UpdateRoomPanels()
    {
        for (int i = 0; i < roomPanels.Length; i++)
        {
            roomPanels[i].SetActive(i == currentRoomIndex);
        }
    }
}
