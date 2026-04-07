using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalBankApi.Data;
using GlobalBankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBankApi.Controllers
{
    
    [ApiController]
    [Route("api/[Controller]")]
    public class ContasBancariasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasBancariasController(AppDbContext context)
        {
            _context=context;
        }


        [HttpGet("contas")]
        public IActionResult Get()
        {
            var contas = _context.ContasBancarias.ToList();
            return Ok(contas);
        }

        [HttpPost]
        public IActionResult Post(ContaBancaria conta)
        { 
            
            if(conta.Saldo <0){return BadRequest("O saldo não pode ser negativo");}
            else{
            _context.ContasBancarias.Add(conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get),new{id = conta.Id},conta);}
        
    }
}
}

 