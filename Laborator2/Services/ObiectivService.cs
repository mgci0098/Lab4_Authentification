using Lab3.ViewModels;
using Laborator2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Services
{
    public interface IObiectivService
    {
        PaginatedList<ObiectivGetModel> GetAll(DateTime? from, DateTime? to, int page);
        Obiectiv Create(ObiectivPostModel obiectiv);
        Obiectiv Upsert(int id, ObiectivPostModel obiectiv);
        Obiectiv Delete(int id);
    }

    public class ObiectivService : IObiectivService
    {

        private ObiectiveDbContext context;

        public ObiectivService(ObiectiveDbContext context)
        {
            this.context = context;
        }


        public Obiectiv Create(ObiectivPostModel obiectiv)
        {
            Obiectiv toAdd = ObiectivPostModel.ToObiectiv(obiectiv);
            context.Obiective.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Obiectiv Delete(int id)
        {
            var existing = context.Obiective
                .Include(o => o.Comments)
                .FirstOrDefault(obiectiv => obiectiv.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Obiective.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public PaginatedList<ObiectivGetModel> GetAll(DateTime? from, DateTime? to, int page)
        {
            IQueryable<Obiectiv> result = context
                .Obiective
                .OrderBy(f => f.Id)
                .Include(o => o.Comments);

            PaginatedList<ObiectivGetModel> paginatedResult = new PaginatedList<ObiectivGetModel>();
            paginatedResult.CurrentPage = page;

            if (from != null)
            {
                result = result.Where(o => o.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(o => o.Deadline <= to);
            }

            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<ObiectivGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<ObiectivGetModel>.EntriesPerPage)
                .Take(PaginatedList<ObiectivGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(o => ObiectivGetModel.FromObiectiv(o)).ToList();

            return paginatedResult;
        }

        public Obiectiv Upsert(int id, ObiectivPostModel obiectiv)
        {
            var existing = context.Obiective.AsNoTracking().FirstOrDefault(o => o.Id == id);
            if (existing != null)
            {
                if (obiectiv.Starea.Equals(Obiectiv.Stare.Closed))
                {
                    obiectiv.closedAt = DateTime.Now;
                }
                else
                {
                    obiectiv.closedAt = (DateTime?)null;
                }

                Obiectiv toUpdate = ObiectivPostModel.ToObiectiv(obiectiv);
                toUpdate.Id = id;

                context.Obiective.Update(toUpdate);
                context.SaveChanges();
                return toUpdate;
            }

            Obiectiv toAdd = ObiectivPostModel.ToObiectiv(obiectiv);

            context.Obiective.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }
    }
}
