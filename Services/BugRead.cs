using Base.Models;
using Base.Enums;
using Base.Services;
using Newtonsoft.Json.Linq;
using BaseWeb.Services;
using System.Threading.Tasks;

namespace Mantis.Services
{
    public class BugRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select 
    p.name as projectName,
    b.summary, 
    c.name as statusName,
    u.username as userName,
    b.os_build, 
    b.date_submitted as created
from mantis_bug_table b
join mantis_project_table p on p.id=b.project_id
left join mantis_user_table u on b.handler_id=u.id
join xp_code c on c.type='status' and b.status=c.value
order by b.id
",
            TableAs = "b",
            Items = new QitemDto[] {
                new() { Fid = "project_id" },
                new() { Fid = "summary", Op = ItemOpEstr.Like },
                new() { Fid = "os_build" },  //version
                new() { Fid = "status" },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

        public async Task ExportAsync(string ctrl, JObject find)
        {
            await _WebExcel.ExportByReadAsync(ctrl, dto, find, "Bug.xlsx", _Xp.GetTplPath("Bug.xlsx"), 1);
        }

    } //class
}