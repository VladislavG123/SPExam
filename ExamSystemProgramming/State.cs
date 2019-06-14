using System;

namespace ExamSystemProgramming
{
    public class State
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Status { get; set; }
        public DateTime DateTime { get; set; }

        public DownloadInfo DownloadInfo { get; set; }
    }
}