﻿using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Http;

namespace OncologyReceipts.Api
{
    [RoutePrefix("api/cycle")]
    public class CycleController : ApiBaseController<Cycle>
    {
        public CycleController(OncologyReceiptsContext context) : base(context)
        {

        }         

        public override async Task<Cycle> GetById(int id)
        {
            Cycle cycle = await context.Cycles.Include(c => c.Treatment).Include(c => c.CycleItems).FirstOrDefaultAsync(p => p.Id == id);

            return cycle;
        }    

        [Route("getAllForDiagnosticId/{diagnosticId:int}")]
        [HttpGet]
        public async Task<IList<Cycle>> GetAllForDiagnosticId(int diagnosticId)
        {
            List<Cycle> cycles = await context.Cycles.Include(c => c.Treatment).Where(c => c.DiagnosticId == diagnosticId).ToListAsync();

            return cycles;
        }

        [Route("cycleGraph")]
        [HttpPost]
        public async Task<Cycle> CycleGraph(Cycle cycle)
        {
            return await SaveGraph<CycleItem>(cycle, "CycleItems");
        }             
    }
}