namespace ReactDemo.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(GetConnectionString());
        //}

        //private static string GetConnectionString()
        //{
        //    const string server = "C229\\SQLEXPRESS2014";
        //    const string dbname = "ReactDemo";
        //    const string uid = "sa";
        //    const string pass = "admin123!@#";
        //    return "Data Source=" + server + ";Initial Catalog=" + dbname + ";Integrated Security=false;user id=" + uid + ";password=" + pass + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
