using JobApplicationProject;
using JobApplicationProject.Models;
using swaggertest.ViewModels;

namespace swaggertest.Services
{
    public class StatusService
    {

        private AppDbContext context;

        public StatusService(AppDbContext context)
        {

            this.context = context;

        }

        public void AddStatus(StatusVM status)
        {
            var _status = new ApplicationStatus()
            {
                StatusName = status.StatusName
            };

            context.ApplicationStatuses.Add(_status);
            context.SaveChanges();
        }

    }
}
