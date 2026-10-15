namespace TicketSystem.Api.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Local { get; set; } = string.Empty;
    }
}

