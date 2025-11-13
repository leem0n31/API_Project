namespace WebApplication1.Contracts.RoleAssignment
{
    public class GetRoleAssignmentResponse
    {
        public int IdНазначения { get; set; }

        public int IdПользователя { get; set; }

        public int IdРоли { get; set; }

        public DateTime? ДатаНазначения { get; set; }

        public int? Назначил { get; set; }
    }
}
