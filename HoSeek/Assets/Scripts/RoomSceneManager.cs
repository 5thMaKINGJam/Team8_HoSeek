using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviour
{
    public GameObject[] roomPanels; // 4���� �� ȭ�� (����, ������, ��, ����)
    public Button leftButton; // ���� �̵� ��ư
    public Button rightButton; // ������ �̵� ��ư

    private int currentRoomIndex = 0; // ���� �� ȭ�� �ε��� (0: ����, 1: ������, 2: ��, 3: ����)

    void Start()
    {
        // ó������ ���� �� ȭ�鸸 Ȱ��ȭ
        UpdateRoomPanels();

        // UI ��ư Ŭ�� �̺�Ʈ ����
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        // Ű���� �Է� ó��
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    // �������� �̵�
    public void MoveLeft()
    {
        currentRoomIndex = (currentRoomIndex - 1 + roomPanels.Length) % roomPanels.Length;
        UpdateRoomPanels();
    }

    // ���������� �̵�
    public void MoveRight()
    {
        currentRoomIndex = (currentRoomIndex + 1) % roomPanels.Length;
        UpdateRoomPanels();
    }

    // ���� �� ȭ�鸸 Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
    private void UpdateRoomPanels()
    {
        for (int i = 0; i < roomPanels.Length; i++)
        {
            roomPanels[i].SetActive(i == currentRoomIndex);
        }
    }
}
