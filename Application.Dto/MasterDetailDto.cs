namespace Application.Dto
{
    public class MasterDetailDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public int MasterId { get; set; }
    }
}