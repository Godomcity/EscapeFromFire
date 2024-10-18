using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDataHandler : MonoBehaviour
{
    // MainScene �÷��̾� ������ �ʿ��� ���� ������ �ʿ���.

    // ������ �ʿ��� ����
    // �÷��̾� 1�� �ε�����.

    // �ʿ����� ������ �𸣴� ����
    // �÷��̾� 2�� �ε�����

    // �÷��̾� ���� �ε������� �޴´� LIST��...

    // ������ �ش� ����Ʈ ��ȸ�ϸ� �ִ°� ���� �����ϴ� ����.

    List<PlayerSpawner.PlayerType> playerTypeContainer;

    private int maxDataCount;

    private void Awake()
    {
        maxDataCount = 2;
    }

    public void AddPlayer(int playerSpawnIndex)
    {
        if ((((int)PlayerSpawner.PlayerType.BLUE) > playerSpawnIndex) &&
            ((int)PlayerSpawner.PlayerType.YELLOW) < playerSpawnIndex)
            return;

        if (playerTypeContainer.Count > maxDataCount)
            return;

        playerTypeContainer.Add((PlayerSpawner.PlayerType)playerSpawnIndex);
    }
}
