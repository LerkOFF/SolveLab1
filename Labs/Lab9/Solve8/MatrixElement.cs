namespace SolveLabs.Labs.Lab9
{
    public struct MatrixElement : IEquatable<MatrixElement>
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }

        public MatrixElement(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public bool Equals(MatrixElement other)
        {
            return Row == other.Row && Column == other.Column && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is MatrixElement other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column, Value);
        }

        public override string ToString()
        {
            return $"({Row}, {Column}) = {Value}";
        }
    }
}