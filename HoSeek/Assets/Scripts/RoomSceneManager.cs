using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviour
{
    public GameObject[] roomPanels; 
    public Button leftButton; 
    public Button rightButton; 

    private int currentRoomIndex = 0; 

    void Start()
    {
        UpdateRoomPanels();

        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    public void MoveLeft()
    {
        currentRoomIndex = (currentRoomIndex - 1 + roomPanels.Length) % roomPanels.Length;
        UpdateRoomPanels();
    }

    public void MoveRight()
    {
        currentRoomIndex = (currentRoomIndex + 1) % roomPanels.Length;
        UpdateRoomPanels();
    }

    private void UpdateRoomPanels()
    {
        for (int i = 0; i < roomPanels.Length; i++)
        {
            roomPanels[i].SetActive(i == currentRoomIndex);
        }
    }
}
