using TrashBoard.Domain.ValueObjects;
using TrashBoard.Domain.Utills;

namespace TrashBoard.Domain.Entities
{
    public class Thread
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CreatorId { get; private set; }

        public Visibility Visibility { get; private set; }
        private readonly List<Board> boards = new List<Board>();
        public IReadOnlyCollection<Board> Boards => boards.AsReadOnly();

        private Thread()
        {
            this.Name = null!;
            this.Description = null!;
            this.Visibility = Visibility.Private;
        }

        public Thread(string name, string description, int creatorId, Visibility visibility)
        {
            Validators.ValidateStringOnlyLenght(name, DomainRules.MinThreadnameLength, DomainRules.MaxThreadnameLength, "Thread name");
            Validators.ValidateStringOnlyLenght(description, DomainRules.MinThreadDescriptionLength, DomainRules.MaxThreadDescriptionLength, "Description");

            this.Name = name;
            this.Description = description;
            this.CreatorId = creatorId;
            this.Visibility = visibility;
        }

        public void ChangeVisibility(Visibility newVisibility)
        {
            this.Visibility = newVisibility;
        }

        public void Rename(string newName)
        {
            Validators.ValidateStringOnlyLenght(newName, DomainRules.MinThreadnameLength, DomainRules.MaxThreadnameLength, "Thread name");
            this.Name = newName;
        }

        public void ChangeDescription(string newDescription)
        {
            Validators.ValidateStringOnlyLenght(newDescription, DomainRules.MinThreadDescriptionLength, DomainRules.MaxThreadDescriptionLength, "Description");
            this.Description = newDescription;
        }

        public Board AddBoard(string name, string description, Visibility visibility)
        {
            if (!visibility.IsAtMost(this.Visibility))
                throw new Domain.DomainExceptions.DomainException("Board visibility cannot be more public than thread visibility");

            var board = new Board(name, description, this.Id, visibility);
            boards.Add(board);
            return board;
        }
    }
}
