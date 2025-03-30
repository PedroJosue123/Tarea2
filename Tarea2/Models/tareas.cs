namespace Tarea2.Models;

public class tareas
{
    public String Id { get; set; }
    public String Nombre { get; set; }
    public String Detalles { get; set; }
    public DateTime Tiempo {get; set; }
    public Boolean estado { get; set; }

    public tareas(String id, String nombre, String detalles, DateTime tiempo, Boolean estado)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Detalles = detalles;
        this.Tiempo = tiempo;
        this.estado = estado;
    }
}