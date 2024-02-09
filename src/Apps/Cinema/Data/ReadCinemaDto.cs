namespace FirstAPI.Data.Dtos;

public class ReadCinemaDto
{
    public string name = string.Empty;
    public ReadAddressDto Address { get; set; }
    public DateTime DataConsulted = DateTime.Now;
}