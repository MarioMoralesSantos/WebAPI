namespace Services
{
    public interface IProjectsServices
    {
       
        IEnumerable<Project> GetProjects();
        Project GetProject(int ProjectId);
    }
    public class ProjectsServices : IProjectsServices
    {
        private readonly List<Project> _projects = new List<Project>      // Estos proyectos se encargan de ofrecer informacion de los proyectos.
        {
            new Project {Id = 1, Name = "Project A", IsActive = true, addedDate = DateTimeOffset.UtcNow},
            new Project {Id = 2, Name = "Project B", IsActive = false, addedDate = DateTimeOffset.UtcNow}
        };
        public IEnumerable<Project> GetProjects() => _projects;

        public Project GetProject(int projectId)
        {
            var project= _projects.FirstOrDefault(p => p.Id == projectId);
           
            return project;
        }

      
    }
}
