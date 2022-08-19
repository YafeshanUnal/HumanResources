using System.ComponentModel.DataAnnotations;

namespace jobapplication.Entity
{

    public class Worker
    {
        [Key]

        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string WorkerTitle { get; set; }
    }
}