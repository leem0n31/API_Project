namespace WebApplication1.Contracts.GroupMembership
{
    public class GetGroupMembershipResponse
    {
        public int IdЧленства { get; set; }

        public int IdПользователя { get; set; }

        public int IdГруппы { get; set; }

        public DateTime? ДатаВступления { get; set; }

        public bool? Активен { get; set; }
    }
}
