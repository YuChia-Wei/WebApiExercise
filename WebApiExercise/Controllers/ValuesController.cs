using System.Collections.Generic;
using System.Web.Http;
using WebApiExercise.Models.DataModel;
using WebApiExercise.Repository;

namespace WebApiExercise.Controllers
{
    public class ValuesController : ApiController
    {
        private Repository<MyTestDataTable> myTestDataTableRepository;

        public ValuesController()
        {
            myTestDataTableRepository = new Repository<MyTestDataTable>(new MyTestDBEntities());
        }

        // GET api/values
        public IEnumerable<MyTestDataTable> Get()
        {
            return myTestDataTableRepository.LookupAll();
        }

        // GET api/values/5
        public MyTestDataTable Get(int id)
        {
            return myTestDataTableRepository.GetSingle(t => t.Id == id);
        }

        // POST api/values
        public void Post([FromBody]MyTestDataTable value)
        {
            myTestDataTableRepository.Create(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]MyTestDataTable value)
        {
            myTestDataTableRepository.Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            myTestDataTableRepository.Remove(myTestDataTableRepository.GetSingle(t => t.Id == id));
        }
    }
}