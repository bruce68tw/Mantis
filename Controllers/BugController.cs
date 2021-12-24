using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using Mantis.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mantis.Controllers
{
    public class BugController : ApiCtrl
    {
        public async Task<ActionResult> Read()
        {
            await using var db = new Db();
            ViewBag.Projects = await _XpCode.GetProjectsAsync(db);
            ViewBag.Statuses = await _XpCode.GetStatusesAsync(db);
            ViewBag.Versions = await _XpCode.GetVersionsAsync(db);
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new BugRead().GetPageAsync(Ctrl, dt));
        }

        public async Task Export(string find)
        {
            await new BugRead().ExportAsync(Ctrl, _Str.ToJson(find));
        }

    }//class
}