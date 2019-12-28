using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaApp.Entities.Models
{
    public class Idea
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool IsDeleted { get; set; }
        public User Submitter { get; set; }
        public Topic Topic { get; set; }
    }
}
