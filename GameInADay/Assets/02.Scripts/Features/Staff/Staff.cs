public class Staff
{
    public string Name;
    public string Type;
    public int GradeId;
    public int PayPerWeek;

    public ModelStaffGrade Grade => ModelStaffGrade.Get(GradeId);
}