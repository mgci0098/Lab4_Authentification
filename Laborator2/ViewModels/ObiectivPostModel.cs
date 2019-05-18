using Laborator2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Laborator2.Models.Obiectiv;

namespace Lab3.ViewModels
{
    public class ObiectivPostModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public DateTime Deadline { get; set; }
        public string Importanta { get; set; }
        public string Starea { get; set; }
        public Nullable<DateTime> closedAt { get; set; }

        public List<Comment> Comments { get; set; }


        public static Obiectiv ToObiectiv (ObiectivPostModel obiectiv)
        {
            //Transformare din string in Enum Importance
            Importance importanta = Importance.Low;
            if(obiectiv.Importanta == "Medium")
            {
                importanta = Importance.Medium;
            }
            else if(obiectiv.Importanta == "High")
            {
                importanta = Importance.High;
            }

            //Transformare din string in Enum Stare
            Stare stare = Stare.Open;
            if (obiectiv.Starea == "InProgress")
            {
                stare = Stare.InProgress;
            }
            else if (obiectiv.Starea == "Closed")
            {
                stare = Stare.Closed;
            }

            return new Obiectiv
            {
                Title = obiectiv.Title,
                Description = obiectiv.Description,
                Added = obiectiv.Added,
                Deadline = obiectiv.Deadline,
                closedAt = obiectiv.closedAt,
                Importanta = importanta,
                Starea = stare,
                Comments = obiectiv.Comments
            };
        }
    }
}
