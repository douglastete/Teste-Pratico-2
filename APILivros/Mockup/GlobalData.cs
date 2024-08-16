using APILivraria.Communication;

namespace APILivraria.Mockup;

public class GlobalData
{
    public static GlobalData globalDB = new GlobalData();
    public List<ResultLivrosJson>? ListaLivros { get; set; }

    public GlobalData()
    {
        ListaLivros = new List<ResultLivrosJson>();
    }

    public int Insert(RequestRegisterLivroJson obj)
    {
        if (obj == null)
        {
            return -1;
        };

        int id = globalDB.ListaLivros.Count + 1;

        ListaLivros.Add(new ResultLivrosJson
        {
            Id = id,
            Autor = obj.Autor,
            Genero = obj.Genero,
            Preco = obj.Preco,
            Quantidade = obj.Quantidade,
            Titulo = obj.Titulo
        });

        return id;
    }

    public ResultLivrosJson Select(int id)
    {
        foreach (var item in globalDB.ListaLivros)
        {
            if (item.Id == id)
            {
                return item;
            }
        };
        return new ResultLivrosJson();
    }
    public bool Update(int id, RequestUpdateLivroJson obj)
    {
        ResultLivrosJson itemUpdate = new ResultLivrosJson();
        foreach (var item in globalDB.ListaLivros)
        {
            if (item.Id == id)
            {
                itemUpdate = item;
                break;
            }
        };

        if (itemUpdate.Id == 0)
        {
            return false;
        }

        itemUpdate.Preco = obj.Preco;
        itemUpdate.Quantidade = obj.Quantidade;
        return true;
    }
    public bool Delete(int id)
    {
        ResultLivrosJson itemDelete = new ResultLivrosJson();
        foreach (var item in globalDB.ListaLivros)
        {
            if (item.Id == id)
            {
                itemDelete = item;
                break;
            }
        };

        if (itemDelete.Id == 0)
        {
            return false;
        }

        globalDB.ListaLivros.Remove(itemDelete);
        return true;
    }
}
