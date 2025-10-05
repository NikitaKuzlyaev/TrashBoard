namespace TrashBoard.Domain
{
    /// <summary>
    /// Константы, задающие базовые правила домена для пользователей.
    /// </summary>  
    public class DomainRules
    {
        
        // Domain.User

        /// Минимальная длина логина Пользователя.
        public const int MinLoginLength = 6;
        /// Максимальная длина логина Пользователя.
        public const int MaxLoginLength = 20;
        /// Минимальная длина имени Пользователя.
        public const int MinUsernameLength = 6;
        /// Максимальная длина имени Пользователя.
        public const int MaxUsernameLength = 20;



        // Domain.Thread

        /// Минимальная длина имени Треда
        public const int MinThreadnameLength = 1;
        /// Максимальная длина имени Треда.
        public const int MaxThreadnameLength = 100;
        /// Минимальная длина описания Треда
        public const int MinThreadDescriptionLength = 0;
        /// Максимальная длина описания Треда.
        public const int MaxThreadDescriptionLength = 1000;



        // Domain.Board

        /// Минимальная длина имени Доски
        public const int MinBoardnameLength = 1;
        /// Максимальная длина имени Доски.
        public const int MaxBoardnameLength = 100;
        /// Минимальная длина описания Доски
        public const int MinBoardDescriptionLength = 0;
        /// Максимальная длина описания Доски.
        public const int MaxBoardDescriptionLength = 1000;



        // Domain.Page

        /// Минимальная длина имени Вкладки
        public const int MinPageLength = 1;
        /// Максимальная длина имени Вкладки.
        public const int MaxPageLength = 100;
        /// Минимальная длина контента Вкладки
        public const int MinPageContentLength = 0;
        /// Максимальная длина контента Вкладки.
        public const int MaxPageContentLength = 1000;
    }
}
