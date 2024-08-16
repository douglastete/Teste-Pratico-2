namespace APILivraria.Communication;

public class RequestRegisterLivroJson
{
    public required string Titulo { get; set; }
    public required string Autor { get; set; }
    public string Genero { get; set; } = string.Empty;
    public required double Preco { get; set; }
    public required double Quantidade { get; set; }
}
