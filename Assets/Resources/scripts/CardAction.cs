using UnityEngine;
using Vuforia;

public enum CardType
{
    Roll,
    Move,
    Heal,
    Trap,
    Restart
}

public class CardAction : MonoBehaviour
{
    public CardType cardType;

    private ObserverBehaviour observer;
    private bool actionTriggered = false;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
    }

    void Update()
    {
        if (observer == null) return;

        bool tracked = observer.TargetStatus.Status == Status.TRACKED ||
                       observer.TargetStatus.Status == Status.EXTENDED_TRACKED;

        if (tracked && !actionTriggered)
        {
            TriggerAction();
            actionTriggered = true;
        }

        if (!tracked)
        {
            actionTriggered = false;
        }
    }

    void TriggerAction()
    {
        if (GameManager.Instance == null) return;

        switch (cardType)
        {
            case CardType.Roll:
                GameManager.Instance.RollDice();
                break;

            case CardType.Move:
                GameManager.Instance.MovePlayer();
                break;

            case CardType.Heal:
                GameManager.Instance.Heal();
                break;

            case CardType.Trap:
                GameManager.Instance.TrapPenalty();
                break;

            case CardType.Restart:
                GameManager.Instance.RestartGame();
                break;
        }
    }
}