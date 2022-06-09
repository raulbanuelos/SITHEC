using Microsoft.EntityFrameworkCore;
using SITEC.WEB_API.Data;
using SITEC.WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Repository
{
    public class HumanoRepository : IHumanoRepository
    {
        #region Atributtes
        private readonly HumanoContext _dbContext; 
        #endregion

        #region Constructors
        public HumanoRepository(HumanoContext dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

        public void DeleteHumano(int IdHumano)
        {
            var humano = _dbContext.Humanos.Find(IdHumano);

            if (humano == null)
                return;

            _dbContext.Humanos.Remove(humano);
            _dbContext.SaveChanges();
        }

        public Humano GetHumanoByID(int IdHumano)
        {
            return _dbContext.Humanos.Find(IdHumano);
        }

        public IEnumerable<Humano> GetHumanos()
        {
            return _dbContext.Humanos;
        }

        public void InsertHumano(Humano humano)
        {
            _dbContext.Add(humano);
            _dbContext.SaveChanges();
        }

        public void UpdateHumano(Humano humano)
        {
            _dbContext.Entry(humano).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
