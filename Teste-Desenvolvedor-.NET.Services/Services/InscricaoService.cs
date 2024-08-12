﻿
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public InscricaoService(IMapper mapper, DBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Inscricao> AdicionarInscricao(InscricaoModel model)
        {
            var inscricao = _mapper.Map<Inscricao>(model);

            if (inscricao.Notificacao.Any())
            {
                return inscricao;
            }

            await _dbContext.Inscricoes.AddAsync(inscricao);
            await _dbContext.SaveChangesAsync();
            return inscricao;
        }

        public async Task<Inscricao> AtualizarInscricao(Guid id, InscricaoModel model)
        {
            var inscricao = _mapper.Map<Inscricao>(model);
            var existe = await _dbContext.Inscricoes.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (existe == null)
            {
                return null;
            }

            existe.Atualizar(inscricao.Nome,inscricao.Status,inscricao.IdOferta,inscricao.IdLead,inscricao.IdProcessoSeletivo);

            if (existe.Notificacao.Any())
            {
                return existe;
            }

            _dbContext.Inscricoes.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarInscricao(Guid id)
        {
            var inscricao = await _dbContext.Inscricoes.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (inscricao == null)
            {
                return false;
            }

            inscricao.Delete();
            _dbContext.Inscricoes.Update(inscricao);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Inscricao>> GetAllInscricao()
        {
            return await _dbContext.Inscricoes.ToListAsync();
        }

        public async Task<Inscricao> GetInscricao(Guid id)
        {
            return await _dbContext.Inscricoes.Where(x => x.Deleted == false)
               .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
    
    
}