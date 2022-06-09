using SITEC.WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Repository
{
    public interface IHumanoRepository
    {
        IEnumerable<Humano> GetHumanos();

        Humano GetHumanoByID(int IdHumano);

        void InsertHumano(Humano humano);

        void DeleteHumano(int IdHumano);

        void UpdateHumano(Humano humano);
    }
}
