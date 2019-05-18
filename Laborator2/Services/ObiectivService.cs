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
        IEnumerable<ObiectivGetModel> GetAll(DateTime? from, DateTime? to);
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
            var existing = context.Obiective.Include(o => o.Comments).FirstOrDefault(obiectiv => obiectiv.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Obiective.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public IEnumerable<ObiectivGetModel> GetAll(DateTime? from, DateTime? to)
        {
            IQueryable<Obiectiv> result = context
                .Obiective
                .Include(o => o.Comments);

            if (from == null && to == null)
            {
                return result.Select(o => ObiectivGetModel.FromObiectiv(o));
            }

            if (from != null)
            {
                result = result.Where(o => o.Deadline >= from);
            }
            if (to != null)
            {
                result = result.Where(o => o.Deadline <= to);
            }

            return result.Select(o => ObiectivGetModel.FromObiectiv(o));

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
