using APILivraria.Communication;
using APILivraria.Mockup;
using APILivros.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace APILivraria.Controllers;
public class LivrosController : LivrariaBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ResultLivrosJson>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {        
        return Ok(GlobalData.globalDB.ListaLivros);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResultLivrosJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromRoute] int id)
    {
        ResultLivrosJson response = GlobalData.globalDB.Select(id);
        if (response.Id == 0)
        {
            return BadRequest();
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultRegisteredLivrosJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterLivroJson request)
    {
        string[] generos = Enum.GetNames<Generos>();
        if (!generos.Contains(request.Genero)) 
        {
            return BadRequest("Os gêneros permitidos são: " + String.Join(", ", generos));
        }

        int id = GlobalData.globalDB.Insert(request);
        var response = new ResultRegisteredLivrosJson { Id = id };
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateLivroJson request)
    {
        bool sucesso = GlobalData.globalDB.Update(id, request);
        if (!sucesso)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete([FromRoute] int id)
    {
        bool sucesso = GlobalData.globalDB.Delete(id);
        if (!sucesso)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
