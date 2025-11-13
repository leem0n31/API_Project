namespace WebApplication1.Contracts.RoleAssignment
{
    public class CreateRoleAssignmentRequest
    {
      
        public int IdПользователя { get; set; }

        public int IdРоли { get; set; }

        public int? Назначил { get; set; }
    }

}
