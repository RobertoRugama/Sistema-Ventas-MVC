using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface Obligatorio<CualquierClase>
    {
        void create(CualquierClase obj);
        void delete(CualquierClase obj);
        void update(CualquierClase obj);
        bool find(CualquierClase obj);
        List<CualquierClase> findAll();
    }
}
