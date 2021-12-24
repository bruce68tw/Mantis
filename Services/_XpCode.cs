using Base.Models;
using Base.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantis.Services
{
    //for dropdown input
    public static class _XpCode
    {
        //get codes from sql 
        public static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsAsync<IdStrDto>(sql);
            await _Fun.CheckCloseDb(db, emptyDb);
            return rows;
        }

        //get code table rows
        public static async Task<List<IdStrDto>> TypeToListAsync(string type, Db db = null)
        {
            var sql = $@"
select 
    value as Id, name as Str
from xp_code
where type='{type}'
order by sort";
            return await SqlToListAsync(sql, db);
        }

        public static async Task<List<IdStrDto>> GetProjectsAsync(Db db = null)
        {
            var sql = @"
select 
    convert(id,char) as Id, name as Str
from mantis_project_table
order by id
";
            return await SqlToListAsync(sql, db);
        }

        public static async Task<List<IdStrDto>> GetVersionsAsync(Db db = null)
        {
            var sql = @"
select distinct
    os_build as Id, os_build as Str
from mantis_bug_table
order by os_build
";
            return await SqlToListAsync(sql, db);
        }

        public static async Task<List<IdStrDto>> GetStatusesAsync(Db db = null)
        {
            return await TypeToListAsync("status", db);
        }

    }//class
}
