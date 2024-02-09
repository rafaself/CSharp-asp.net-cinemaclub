namespace FirstAPI.Data.Dtos;

public class ReadAddressDto
{
    public int ID { get; set; }
    public string Street { get; set; } = string.Empty;
    public int Number { get; set; }
}