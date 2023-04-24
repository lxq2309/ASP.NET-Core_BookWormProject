namespace BookWormProject.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAttribute : Attribute
    {
        public string Role { get; }

        public RoleAttribute(string role)
        {
            Role = role;
        }
    }

}
