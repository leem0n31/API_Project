namespace WebApplication1.Contracts.StudyGroup
{
    public class CreateStudyGroupRequest
    {

        public string НазваниеГруппы { get; set; } = null!;

        public int Курс { get; set; }

        public string? Факультет { get; set; }

       
    }
}
