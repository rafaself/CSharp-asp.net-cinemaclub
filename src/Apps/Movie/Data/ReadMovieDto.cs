namespace FirstAPI.Data.Dtos;

public class ReadMovieDto
{
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Duration { get; set; }
    public DateTime DateConsulted { get; set; } = DateTime.Now;
}