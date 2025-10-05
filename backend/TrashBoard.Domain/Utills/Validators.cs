using TrashBoard.Domain.DomainExceptions;

namespace TrashBoard.Domain.Utills
{
    public class Validators
    {
        public static void ValidateString(string str, int minLenght, int maxLenght, string fieldName = "string")
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < minLenght || str.Length > maxLenght)
                throw new DomainException($"{fieldName} must be {minLenght}-{maxLenght} characters");
        }

        public static void ValidateStringOnlyLenght(string str, int minLenght, int maxLenght, string fieldName = "string")
        {
            if (str == null || str.Length < minLenght || str.Length > maxLenght)
                throw new DomainException($"{fieldName} must be {minLenght}-{maxLenght} characters");
        }

        public static void ValidateString(string str, string fieldName = "string")
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new DomainException($"{fieldName} is required");
        }

    }
}
