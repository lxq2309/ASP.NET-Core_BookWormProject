namespace BookWormProject.ViewModels.User
{
    public class UserIndexViewModel
    {
        public Models.User CurrentUser { get; set; }
        public Models.User TargetUser { get; set; }
        public bool IsMyAccount { get; set; }
    }
}
