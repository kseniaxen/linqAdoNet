using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdoNetDemo.DAO
{
    public class PublisherDAO : AbstractDAO<Publisher>
    {
        public PublisherDAO(DiseaseEntities1 _db) : base(_db)
        {

        }
    }
}
