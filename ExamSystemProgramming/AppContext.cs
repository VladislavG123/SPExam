namespace ExamSystemProgramming
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        
        public AppContext()
            : base("name=AppContext")
        {
        }

         public  DbSet<DownloadInfo> DownloadInfos { get; set; }
         public  DbSet<State> States { get; set; }
    }
    
}