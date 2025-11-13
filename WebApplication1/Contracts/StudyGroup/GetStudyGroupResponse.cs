namespace WebApplication1.Contracts.StudyGroup
{
    public class GetStudyGroupResponse
    {
        public int IdГруппы { get; set; }

        public string НазваниеГруппы { get; set; } = null!;

        public int Курс { get; set; }

        public string? Факультет { get; set; }

        public DateTime? ДатаСоздания { get; set; }
    }
}
