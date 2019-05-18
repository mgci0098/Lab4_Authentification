using Lab3.ViewModels;
using Laborator2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Services
{

    public interface ICommentService
    {
        IEnumerable<CommentGetModel> GetAllFiltered(String filter);
    }


    public class CommentService : ICommentService
    {

        private ObiectiveDbContext context;

        public CommentService(ObiectiveDbContext context)
        {
            this.context = context;
        }

  
        public IEnumerable<CommentGetModel> GetAllFiltered(String filter)
        {
                IQueryable<CommentGetModel> result = context
                                 .Comments
                                 .Select(c => CommentGetModel.DinObiectiv(c))
                                 .Where(c => c.Text.Contains(filter))
                                 ;
            return result;
        } 
    }
}
