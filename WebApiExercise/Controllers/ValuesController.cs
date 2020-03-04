using System.Collections.Generic;
using System.Web.Http;
using SkillTree_MVC_HW.Repository;
using WebApiExercise.Models.DataModel;

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
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            myTestDataTableRepository.Remove(myTestDataTableRepository.GetSingle(t => t.Id == id));
        }
    }
}