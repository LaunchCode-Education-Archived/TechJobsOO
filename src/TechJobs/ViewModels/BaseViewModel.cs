using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
		public string[] Columns { get; set; } = JobSearchType.GetAll();
        public string Title { get; set; } = "";
    }
}
