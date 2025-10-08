using TrashBoard.Domain.Utills;
using TrashBoard.Domain.ValueObjects;

namespace TrashBoard.Domain.Entities
{
    public class Board
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ThreadId { get; private set; }
        public Visibility Visibility { get; private set; }
        private readonly List<Page> pages = new List<Page>();
        public IReadOnlyCollection<Page> Pages => pages.AsReadOnly();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        private Board() 
        {
            this.Name = null!; // null-forgiving operator -> будет инициализировано EF
            this.Description = null!;
            this.Visibility = Visibility.Private;
        }  
        
        public Board(string name, string description, int threadId, Visibility visibility)
        {
            Validators.ValidateStringOnlyLenght(name, DomainRules.MinBoardnameLength, DomainRules.MaxBoardnameLength, "Board name");
            Validators.ValidateStringOnlyLenght(description, DomainRules.MinBoardDescriptionLength, DomainRules.MaxBoardDescriptionLength, "Description");

            this.Name = name;
            this.Description = description;
            this.ThreadId = threadId;
            this.Visibility = visibility;
        }

        public void ChangeVisibility(Visibility newVisibility)
        {
            this.Visibility = newVisibility;
        }

        public void Rename(string newName)
        {
            Validators.ValidateStringOnlyLenght(newName, DomainRules.MinBoardnameLength, DomainRules.MaxBoardnameLength, "Board name");
            this.Name = newName;
        }

        public void ChangeDescription(string newDescription)
        {
            Validators.ValidateStringOnlyLenght(newDescription, DomainRules.MinBoardDescriptionLength, DomainRules.MaxBoardDescriptionLength, "Description");
            this.Description = newDescription;
        }

        public Page AddPage(string name, string content, Visibility visibility)
        {
            if (!visibility.IsAtMost(this.Visibility))
                throw new Domain.DomainExceptions.DomainException("Page visibility cannot be more public than board visibility");

            var page = new Page(name, content, this.Id, visibility);
            pages.Add(page);
            return page;
        }

    }
}
