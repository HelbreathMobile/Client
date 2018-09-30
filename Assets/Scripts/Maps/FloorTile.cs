public class FloorTile : HBTile
{
    public bool tp;
    public bool move;

    public FloorTile(int x, int y, string resource, bool tp, bool move) : base(x, y, resource)
    {
        this.tp = tp;
        this.move = move;
    }
}