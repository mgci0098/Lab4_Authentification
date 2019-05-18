using Laborator2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class ObiectivGetModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public DateTime Deadline { get; set; }
        public int NumberOfComments { get; set; }


        public static ObiectivGetModel FromObiectiv (Obiectiv obiectiv)
        {
            return new ObiectivGetModel
            {
                Title = obiectiv.Title,
                Description = obiectiv.Description,
                Added = obiectiv.Added,
                Deadline = obiectiv.Deadline,
                NumberOfComments = obiectiv.Comments.Count
            };
        }
    }
}
