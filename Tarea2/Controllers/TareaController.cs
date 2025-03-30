using Microsoft.AspNetCore.Mvc;

namespace Tarea2.Controllers;
using Tarea2.Models;

[ApiController]
[Route("api/tarea")]
public class TareaController : ControllerBase
{
    private static tareas tarea1 = new tareas("1", "Lavar los platas",
        "Debo de lavar los platos antes que llegue mi mamá", new DateTime(2025, 3, 30, 14, 30, 0),
        true);

    private static tareas tarea2 = new tareas("2", "Hacer el laboratorio de empresariales",
        "Debo de hacer en grupo la tarea que dejo el profesor", new DateTime(2025, 3, 29, 15, 30, 0),
        true);

    private static List<tareas> Tareas = new List<tareas> { tarea1, tarea2 };
   
    
    [HttpGet]
    public IActionResult gettareas() => Ok(Tareas);

    [HttpGet("{id}")]
    public ActionResult gettarea(String id)
    {
        foreach (var tarea in Tareas)
        {
            if (tarea.Id == id)
            { return Ok(tarea);
            }
             
        }
    return NotFound($"No hay tarea con id {id}");
       
    }

    [HttpPost]
    public ActionResult Agregartarea ([FromBody] tareas tarea)
    {
        if (tarea == null)
        {
            return BadRequest("Los datos de la tarea son invaidos");
        }
        Tareas.Add(tarea);
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult EditarTarea([FromBody] tareas tareamodificad, String id)
    {
        foreach (var tarea in Tareas)
        {
            if (tarea.Id == id)
            {
                var index = Tareas.FindIndex(a => a is tareas indice && indice.Id == id);
                Tareas[index] = tareamodificad;
                return Ok(tareamodificad);
            }
        }
        return NotFound($"No hay tarea con id {id}");
    }
    [HttpDelete( "{id}")]
    public ActionResult eliminartarea(string id)
    {
        foreach (var tarea in Tareas)
        {
            if (tarea.Id == id)
            {
                Tareas.Remove(tarea);
                return Ok(tarea);
            }
        }
        return NotFound($"No existe la tarea con id {id}");
    }
}
    
    
