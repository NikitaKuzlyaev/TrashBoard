namespace TrashBoard.Domain.ValueObjects
{
    public class Visibility
    {
        // Ordering: Private (0) < Protected (1) < Public (2)
        public static readonly Visibility Private = new Visibility("Private", 0);
        public static readonly Visibility Protected = new Visibility("Protected", 1);
        public static readonly Visibility Public = new Visibility("Public", 2);

        public string Value { get; }
        private int Order { get; }

        private Visibility(string value, int order)
        {
            Value = value;
            Order = order;
        }

        public bool IsAtMost(Visibility other)
        {
            return this.Order <= other.Order;
        }

        public override string ToString() => Value;

        public override bool Equals(object? obj)
        {
            return obj is Visibility other && Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static Visibility ParseVisibility(string s)
        {
            return s switch
            {
                "Public" => Visibility.Public,
                "Protected" => Visibility.Protected,
                "Private" => Visibility.Private,
                _ => throw new ArgumentOutOfRangeException(nameof(s), $"Unknown visibility: {s}")
            };
        }

    }
}
