using Microsoft.AspNetCore.Mvc;
using Candidatos.modelo;
using Candidatos.repositorio.Interfaces;

namespace Candidatos.repositorio
{
    public class CandidatoRp : ICandidato_Rp
    {
        public List<Candidato> GetAll()
        {
            using (var db = new repositorio.Contexto())
            {
                List<Candidato> lista = db.Candidato.Where(o => o.bAtivo == true).ToList();
                return lista;
            }
        }

        public async Task<Candidato> GetCandidatoId(int id)
        {
            using (var db = new repositorio.Contexto())
            {
                var candidato = db.Candidato.FirstOrDefault(x => x.ID == id && x.bAtivo == true);
                //var idade = candidato.DataNascimento.Year - DateTime.Now.Year ;

                return candidato;
            }
        }
        public async Task<Candidato> Novocandidato(Candidato novoCandidato)
        {

            using (var db = new repositorio.Contexto())
            {
                db.Candidato.Add(novoCandidato);
                await db.SaveChangesAsync();
                return novoCandidato;
            }

        }
        public async Task<Candidato> PutUpdade(Candidato novoCandidato)
        {
            using (var db = new repositorio.Contexto())
            {
                db.Candidato.Update(novoCandidato);
                await db.SaveChangesAsync();
                return novoCandidato;
            }
        }
        public async Task<Candidato> Delete(int id)
        {
            using (var db = new repositorio.Contexto())
            {
                var candidato = db.Candidato.Find(id);
                db.Candidato.Remove(candidato);
                db.SaveChanges();
                return candidato ;
            }
        }
    }
}
