namespace Application.Dto
{
    public class EstadoDto<type>
    {
        public type Id { get; set; }
        public bool Status { get; set; }
        public string Value { get; set; }
    }
}