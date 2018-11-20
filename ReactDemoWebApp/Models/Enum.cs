namespace ReactDemoWebApp.Models
{
    using System.ComponentModel;

    public enum Role
    {
        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }
}
