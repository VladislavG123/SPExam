using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemProgramming
{
    public class DownloadInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public string LocalPath { get; set; }
       
        public List<State> State { get; set; }
    }
}
