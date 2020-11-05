namespace FitnessApp.API.Services
{
    public interface IRecurringJobsService
    {
        void ClearTheDailyIntakeMacrosAndMoveItToHistory();
        void StartRecurringBackroundJobs();
    }
}