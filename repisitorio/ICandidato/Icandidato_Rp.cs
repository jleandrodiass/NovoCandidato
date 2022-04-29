using Microsoft.AspNetCore.Mvc;
using Candidatos.modelo;

namespace Candidatos.repositorio.Interfaces
{
    public interface ICandidato_Rp
    {
        public List<Candidato> GetAll();
        public  Task<Candidato>  Novocandidato(Candidato novoCandidato);
        public Task<Candidato> GetCandidatoId(int id);
        public  Task<Candidato> PutUpdade(Candidato novoCandidato);
         public Task<Candidato> Delete(int id);
        
    }
}