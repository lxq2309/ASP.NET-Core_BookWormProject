namespace BookWormProject.Data.Services
{
    public interface IEmailService
    {
        Task SendCodeAsync(string email, string code);
        Task SendPasswordAsync(string email, string password);
    }
}
