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
    public class TransacoesController: ControllerBase
    {
        private readonly AppDbContext _context;
        public TransacoesController(AppDbContext context)
        {
            _context=context;
        }
        [HttpGet("transacoes")]
        public IActionResult Get()
        {
            var transacoes = _context.Transacoes.ToList();
            return Ok(transacoes);
        }

        [HttpPost]
        public IActionResult Post(Transacao transacao)
        {
            var conta = _context.ContasBancarias.Find(transacao.ContaId);
           if(conta == null)
            {
                return NotFound();
            }
            if(transacao.Tipo == "Saque")
            {
                if(transacao.Valor > conta.Saldo)
                {
                    return Conflict ("Saldo Insuficiente");
                } 
                conta.Saldo = conta.Saldo-transacao.Valor;
            }

            if (transacao.Valor > 10000)
            {
                Console.WriteLine($"🚩 ALERTA DE SEGURANÇA: Transação de alto valor detectada para a conta {conta.Id}!");
            }
            _context.Transacoes.Add(transacao);               
            _context.SaveChanges();
            return Ok(transacao);    
           
        }
    }
}