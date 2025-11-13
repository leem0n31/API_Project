namespace WebApplication1.Contracts.Role
{
    public class UpdateRoleRequest
    {
        public int IdРоли { get; set; }

        public string НазваниеРоли { get; set; } = null!;

        public string? Описание { get; set; }

    }
}
