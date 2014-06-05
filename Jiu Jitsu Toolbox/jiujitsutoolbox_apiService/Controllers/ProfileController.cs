using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using jiujitsutoolbox_apiService.Models;
using jiujitsutoolbox_apiService.DataObjects;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace jiujitsutoolbox_apiService.Controllers
{
    [RoutePrefix("profile")]
    public class ProfileController : ApiController
    {
        jiujitsutoolbox_apiContext context;
        public ProfileController(jiujitsutoolbox_apiContext dbContext)
        {
            this.context = dbContext;
        }
        public ApiServices Services { get; set; }

        // GET api/Profile
        public IEnumerable<Profile> Get()
        {
            return context.Profiles.AsEnumerable();
        }

        public async Task<int> Post(Profile profile)
        {
            try
            {
                context.Profiles.Add(profile);
                return await context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                //  throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                Services.Log.Info(exceptionMessage);

            }

            return 0;
        }
    }
}
