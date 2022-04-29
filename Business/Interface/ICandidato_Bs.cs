using Microsoft.AspNetCore.Mvc;
using Candidatos.modelo;
using System;

namespace Candidatos.Buseness.Interfaces
{
    public interface ICandidato_Bs
    {
        public List<Candidato> GetAll();
        public Task<Candidato> Novocandidato(Candidato novoCandidato);
        public Task<Candidato> GetCandidatoId(int id);
        public Task<Candidato> PutUpdade(Candidato novoCandidato);
        public Task<Candidato> Delete(int id);
        //public  int CalcularIdade(DateTime dataNascimento);
    }
}