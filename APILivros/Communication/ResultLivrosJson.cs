namespace APILivraria.Communication;
public enum Generos { Ficcao, Romance, Misterio };
public class ResultLivrosJson
{
    public int Id { get; set; } = 0;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    private Generos _genero { get; set; }
    public string Genero
    {
        get => Enum.GetName(typeof(Generos), _genero);
        set => _genero = (Generos)Enum.Parse(typeof(Generos), value);
    }
    public double Preco { get; set; } = 0;
    public double Quantidade { get; set; } = 0;
}
