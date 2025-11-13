namespace WebApplication1.Contracts.Role
{
    public class GetRoleResponse
    {
        public int IdРоли { get; set; }

        public string НазваниеРоли { get; set; } = null!;

        public string? Описание { get; set; }

        public DateTime? ДатаСоздания { get; set; }
    }
}
