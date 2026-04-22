using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Transform[] tiles;
    public Transform playerPawn;

    public void MovePlayerTo(int index)
    {
        if (index < 0 || index >= tiles.Length) return;

        Vector3 tilePos = tiles[index].position;
        playerPawn.position = tilePos + new Vector3(0, 0.37f, 0);
    }

    public TileData GetTile(int index)
    {
        if (index < 0 || index >= tiles.Length) return null;
        return tiles[index].GetComponent<TileData>();
    }

    public int GetMaxTileIndex()
    {
        return tiles.Length - 1;
    }
}