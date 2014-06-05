using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using jiujitsutoolbox_apiService.DataObjects;
using jiujitsutoolbox_apiService.Models;

namespace jiujitsutoolbox_apiService.Controllers
{
    public class SchoolController : TableController<School>
    {
        jiujitsutoolbox_apiContext context;
        public SchoolController(jiujitsutoolbox_apiContext myContext)
        {
            this.context = myContext;
        }
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DomainManager = new EntityDomainManager<School>(context, Request, Services);
        }

        // GET tables/School
        public IQueryable<School> GetAllSchool()
        {
            return Query(); 
        }

        // GET tables/School/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<School> GetSchool(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/School/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<School> PatchSchool(string id, Delta<School> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/School/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostSchool(School item)
        {
            School current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/School/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSchool(string id)
        {
             return DeleteAsync(id);
        }

    }
}