namespace Application.Dto
{
    public class LigueDto
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public bool  State { get; set; }
        public int? SoccerSubCategoryId { get; set; }
        public bool Outstanding { get; set; }
    }
}
