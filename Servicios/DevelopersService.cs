using System.Xml;


namespace Services
{
    public interface IDevelopersService
    {
        IEnumerable<Developer> GetDevelopers();
        Developer AddDeveloper(int projectId, Developer developer);
        Project GetProject(int projectId);

    }                                                           // Ofrecer informacion sobre los desarrolladores y agregar nuevos a un proyecto en especifico.
    public class DevelopersService : IDevelopersService   //La clase de tipo public DevelopersService va a implementar la interface IDevelopersServices para que así el controlador pueda acceder a la inyeccion de Dep.
    {
        private readonly List<Project> _projects = new List<Project>
        {
            new Project {Id = 1, Name = "Project 1"},
            new Project {Id = 2, Name = "Project 2"}
        };  
        private readonly List<Developer> _developers = new List<Developer> {  // Declaracion de variable _developers en donde se asigna una instancia de lista vacia de objetos Developer, siendo accesible en el controlador. 

            new Developer {Id = 1, Name = "Mario", ProjectId = 1, addedDate = DateTimeOffset.UtcNow},                  //Cada objeto que se agregue developer a la lista _developer de tipo Developer tendra su contenido.
            new Developer {Id = 2, Name = "Hernesto", ProjectId = 2, addedDate = DateTimeOffset.UtcNow}
        };
        public Developer AddDeveloper(int projectId, Developer developer)
        {
            var project = GetProject(projectId);
            if (project == null)
            {
                return null;
            }
            developer.ProjectId = projectId;
            developer.addedDate= DateTimeOffset.UtcNow;
            _developers.Add(developer);
            return developer;
        }
        
        public IEnumerable<Developer> GetDevelopers() => _developers;    //GetDevelopers() devuelve la lista completa de objetos Developer almacenados en la variable _developers   // => _developers; esta linea de codigo es lo mismo que utilizar un return, solo que es uina exprecion lambda.    // IEnumerable permite recorrer la secuencia de objetos. 

        public Project GetProject(int projectId)
        {
            return _projects.FirstOrDefault(p => p.Id == projectId);
        }

    }                                                                                            
                                                                                                

  
}
