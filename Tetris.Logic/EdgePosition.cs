namespace Tetris.Logic
{
    public class EdgePosition
    {
        public int x;
        public int y;

        public EdgePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(EdgePosition left, EdgePosition right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(EdgePosition left, EdgePosition right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is EdgePosition e)
                return this == e;

            return false;
        }
    }
}
