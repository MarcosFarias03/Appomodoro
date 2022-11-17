using ApiAppomodoro.Controllers.DTOS;
using ApiAppomodoro.Handlers;
using ApiAppomodoro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppomodoro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareasController
    {
        [HttpPost]

        public bool InsertarTarea([FromBody] PostTarea tarea)
        {
            try
            {
                return TareasHandler.InsertarTarea(new Tareas
                {
                    Tarea = tarea.Tarea
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpDelete]
        public bool EliminarTarea([FromBody] int Id)
        {
            try
            {
                return TareasHandler.EliminarTarea(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        public bool ModificarTarea([FromBody] PutTarea tarea)
        {
            try
            {
                return TareasHandler.ModificarTarea(new Tareas
                {
                    Id = tarea.Id,
                    Tarea = tarea.Tarea
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet("tarea")]
        public List<Tareas> MostrarTarea(string tarea)
        {
            return TareasHandler.MostrarTareas(tarea);
        }
    }
}
