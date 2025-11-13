namespace WebApplication1.Contracts.User
{
    public class CreateUserRequest
    {

        public string Логин { get; set; } = null!;

        public string Пароль { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Имя { get; set; } = null!;

        public string Фамилия { get; set; } = null!;

        public string? Телефон { get; set; }


    }
}
