using TrashBoard.Domain.Utills;
using TrashBoard.Domain.ValueObjects;

namespace TrashBoard.Domain.Entities
{
    public class Page
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Content { get; private set; }
        public int BoardId { get; private set; }
        public Visibility Visibility { get; private set; }

        private Page()
        {
            this.Name = null!; // null-forgiving operator -> будет инициализировано EF
            this.Content = null!;
            this.Visibility = Visibility.Private;
        }

        public Page(string name, string content, int boardId, Visibility visibility)
        {
            Validators.ValidateStringOnlyLenght(name, DomainRules.MinPageLength, DomainRules.MaxPageLength, "Page name");
            Validators.ValidateStringOnlyLenght(content, DomainRules.MinPageContentLength, DomainRules.MaxPageContentLength, "Content");

            this.Name = name;
            this.Content = content;
            this.BoardId = boardId;
            this.Visibility = visibility;
        }

        public void ChangeVisibility(Visibility newVisibility)
        {
            this.Visibility = newVisibility;
        }

        public void Rename(string newName)
        {
            Validators.ValidateStringOnlyLenght(newName, DomainRules.MinPageLength, DomainRules.MaxPageLength, "Page name");
            this.Name = newName;
        }

        public void UpdateContent(string newContent)
        {
            Validators.ValidateStringOnlyLenght(newContent, DomainRules.MinPageContentLength, DomainRules.MaxPageContentLength, "Content");
            this.Content = newContent;
        }

    }
}
