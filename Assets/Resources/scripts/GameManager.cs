using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BoardManager boardManager;

    public int playerPosition = 0;
    public int lastRoll = 0;
    public int hp = 3;
    public bool gameFinished = false;

    public TMP_Text rollText;
    public TMP_Text hpText;
    public TMP_Text statusText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (boardManager != null)
        {
            boardManager.MovePlayerTo(playerPosition);
        }

        UpdateUI();
        if (statusText != null)
            statusText.text = "Game started.";
    }

    public void RollDice()
    {
        if (gameFinished) return;

        if (lastRoll != 0)
        {
            if (statusText != null)
                statusText.text = "Already rolled. Use Move card.";
            return;
        }

        lastRoll = Random.Range(1, 7);

        if (statusText != null)
            statusText.text = "Rolled: " + lastRoll;

        UpdateUI();
    }

    public void MovePlayer()
    {
        if (gameFinished) return;

        if (lastRoll == 0)
        {
            if (statusText != null)
                statusText.text = "Use Roll card first.";
            return;
        }

        playerPosition += lastRoll;

        int maxIndex = boardManager.GetMaxTileIndex();
        if (playerPosition > maxIndex)
            playerPosition = maxIndex;

        boardManager.MovePlayerTo(playerPosition);
        lastRoll = 0;

        CheckCurrentTile();
        UpdateUI();
    }

    public void Heal()
    {
        if (gameFinished) return;

        hp += 1;

        if (statusText != null)
            statusText.text = "Heal used. HP +1";

        UpdateUI();
    }

    public void TrapPenalty()
    {
        if (gameFinished) return;

        hp -= 1;

        if (hp < 0) hp = 0;

        if (statusText != null)
            statusText.text = "Trap activated. HP -1";

        if (hp == 0)
        {
            gameFinished = true;
            if (statusText != null)
                statusText.text = "Game Over";
        }

        UpdateUI();
    }

    public void RestartGame()
    {
        playerPosition = 0;
        lastRoll = 0;
        hp = 3;
        gameFinished = false;

        boardManager.MovePlayerTo(playerPosition);

        if (statusText != null)
            statusText.text = "Game restarted.";

        UpdateUI();
    }

    private void CheckCurrentTile()
    {
        TileData tile = boardManager.GetTile(playerPosition);
        if (tile == null) return;

        switch (tile.tileType)
        {
            case TileType.Trap:
                hp -= 1;
                if (hp < 0) hp = 0;
                if (statusText != null)
                    statusText.text = "Stepped on Trap! HP -1";
                break;

            case TileType.Heal:
                hp += 1;
                if (statusText != null)
                    statusText.text = "Bonus tile! HP +1";
                break;

            case TileType.Finish:
                gameFinished = true;
                if (statusText != null)
                    statusText.text = "You win!";
                break;

            default:
                if (statusText != null)
                    statusText.text = "Moved to tile " + playerPosition;
                break;
        }

        if (hp <= 0)
        {
            hp = 0;
            gameFinished = true;
            if (statusText != null)
                statusText.text = "Game Over";
        }
    }

    private void UpdateUI()
    {
        if (rollText != null)
            rollText.text = "Roll: " + lastRoll;

        if (hpText != null)
            hpText.text = "HP: " + hp;
    }
}