using System.Web.Http;

namespace LORE.WebApi.Objects.Controllers
{
    public class WeaponController : ApiController
    {
        // Mock a data store:
        //private static List<CompanyModel> context = new List<CompanyModel>
        //{
        //    new CompanyModel { Id = 1, Name = "Microsoft" },
        //    new CompanyModel { Id = 2, Name = "Google" },
        //    new CompanyModel { Id = 3, Name = "Apple" }
        //};

        //[HttpGet]
        //public async Task<IEnumerable<CompanyModel>> Get()
        //{
        //    return await Task.Run(() => context);
        //}

        //[HttpGet]
        //public async Task<CompanyModel> Get(int id)
        //{
        //    return await Task.Run(() =>
        //    {
        //        var company = context.FirstOrDefault(c => c.Id == id);

        //        if (company == null)
        //            throw new HttpResponseException(HttpStatusCode.NotFound);

        //        return company;
        //    });
        //}

        //[HttpPost]
        //public async Task<IHttpActionResult> Post(CompanyModel company)
        //{
        //    return await Task.Run<IHttpActionResult>(() =>
        //    {
        //        if (company == null)
        //            return BadRequest("Argument Null");

        //        if (context.Any(c => c.Id == company.Id))
        //            return BadRequest("Company Exists");

        //        context.Add(company);
        //        return Ok();
        //    });
        //}

        //[HttpPut]
        //public async Task<IHttpActionResult> Put(CompanyModel company)
        //{
        //    return await Task.Run<IHttpActionResult>(() =>
        //    {
        //        if (company == null)
        //            return BadRequest("Argument Null");

        //        var existing = context.FirstOrDefault(c => c.Id == company.Id);
        //        if (existing == null)
        //            return NotFound();

        //        existing.Name = company.Name;
        //        return Ok();
        //    });
        //}

        //[HttpDelete]
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    return await Task.Run<IHttpActionResult>(() =>
        //    {
        //        var company = context.FirstOrDefault(c => c.Id == id);
        //        if (company == null)
        //            return NotFound();

        //        context.Remove(company);
        //        return Ok();
        //    });
        //}
    }
}
