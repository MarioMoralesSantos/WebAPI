using Microsoft.AspNetCore.Mvc;
using Services;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevelopersController : ControllerBase   // Aqui la clase DevelopersController implementa ControllerBase, ya que Es una clase de ASP.NET Core que contiene funcionalidades web.
                                                         // Al heredar de ControllerBase a DevelopersController le esta asignando permisos, para acceder a metodos y propiedades que permiten manejar solicitudes HTTP y devolver la misma.
    {
        private readonly IDevelopersService _developerService;
        private readonly IProjectsServices _projectService;
        public DevelopersController(IDevelopersService developersService, IProjectsServices projectService) // Constructor, en donde DeveloperController recibe dependencias en este caso IDeveloperServices, asi puede acceder a metodos y propiedades, enfocandose
        {                                                                  //en manejar solicitudes HTTP. developerService es una instancia de IDe que inyecta como dependencia en el controlador. 
            _developerService = developersService;  //Aqui se asigna la instancia pasando como argumento en el constructor de IDeveloperServices a _developerServices.
            _projectService = projectService;   
        }
        //Agregando un metodo Obtener.
        [HttpGet]
        public IActionResult GetDevelopers()  //Es una clase de ASP, que da el resultado de un controlador El metodo GetDevelopers() retorna en un objeto IActionResult, 
        {
            var developers = _developerService.GetDevelopers();

            return Ok(_developerService.GetDevelopers());  //devuelve un resultado exitoso HTTP 200, con la respuesta del metodo GetDevelopers del objeto developerServices, devolviendo una coleccion
        }                                                  // developer 

        //Agregando un metodo que acepte una solicitud post. 

        [HttpPost]
        public IActionResult AddDeveloper(int projectId, [FromBody] Developer developer)
        {
            var project = _projectService.GetProject(projectId);
            if(project== null)
            {
                return NotFound($"El proyecto con Id {projectId} no existe");
            }  
            var newDeveloper = _developerService.AddDeveloper(projectId, developer);
            if (newDeveloper == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetDevelopers), new { id = newDeveloper.Id }, newDeveloper);
        }



    }




    [ApiController]
    [Route("[controller]")]

    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsServices _projectService;

        public ProjectsController(IProjectsServices projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult GetProjects()  //El metodo GetDevelopers() retorna en un objeto IActionResult, esta representa el resultado de un controlador
        {
            return Ok(_projectService.GetProjects());
        }
    }
}



