namespace FirstAPI.Data.Dtos;

public class ReadMovieDto
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public ICollection<ReadSessionDto> Sessions { get; set; }
    public DateTime DateConsulted { get; set; } = DateTime.Now;
}