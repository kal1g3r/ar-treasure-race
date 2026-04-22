using UnityEngine;

public enum TileType
{
    Normal,
    Trap,
    Heal,
    Finish
}

public class TileData : MonoBehaviour
{
    public TileType tileType = TileType.Normal;
}