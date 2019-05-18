using Laborator2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.ViewModels
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public int ObiectivId { get; set; }

        public static CommentGetModel DinObiectiv(Comment comment)
        {
            return new CommentGetModel
            {
                Id = comment.Id,
                Text = comment.Text,
                Important = comment.Important,
                ObiectivId = comment.ObiectivId
            };
        }


    }
}
