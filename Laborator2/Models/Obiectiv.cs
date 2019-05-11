using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator2.Models
{

    public class Obiectiv
    {

        public enum Importance
        {
            Low,
            Medium,
            High
        }

        public enum Stare
        {
            Open,
            InProgress,
            Closed,
        }



        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public DateTime Deadline { get; set; }

        [EnumDataType(typeof(Importance))]
        public Importance Importanta { get; set; }

        [EnumDataType(typeof(Stare))]
        public Stare Starea { get; set; }

        public Nullable<DateTime> closedAt { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
