using TMPro;
using UnityEngine;

public class PlayModeSelectController : SelectController
{
    [SerializeField] protected TextMeshProUGUI playerModeTxt;
    [SerializeField] protected Transform player1Transform;

    protected Vector2 player1SingleModeVector = new Vector2(660, 740);
    protected Vector2 player1MultiModeVector = new Vector2(960, 740);

    public void playerModeChoiceSet()
    {
        if (GameManager.Instance.PlayerMode)
        {
            GameManager.Instance.PlayerMode = false;
            player2.SetActive(true);
            player1Transform.position = player1SingleModeVector;
        }
        else if (!GameManager.Instance.PlayerMode)
        {
            GameManager.Instance.PlayerMode = true;
            player2.SetActive(false);
            player1Transform.position = player1MultiModeVector;
        }
    }

}
