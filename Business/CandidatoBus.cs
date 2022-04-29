using Candidatos.Buseness.Interfaces;
using Candidatos.modelo;
using Candidatos.repositorio.Interfaces;

namespace Candidatos.repositorio.Buseness
{
    public class CandidatoBus : ICandidato_Bs
    {
        private readonly ICandidato_Rp _candidato;
        public CandidatoBus(ICandidato_Rp candidato)
        {
            _candidato = candidato;
        }
        public List<Candidato> GetAll()
        {
            return _candidato.GetAll();
        }
        public Task<Candidato> GetCandidatoId(int id)
        {
             using (var db = new repositorio.Contexto())
            {
                List<Candidato> lista = db.Candidato.Where(o => o.bAtivo == true).ToList();

                // List<Candidato> lista = db.Candidato.Where(o => o.bAtivo == true).ToList();
                //return lista;
                 return _candidato.GetCandidatoId(id);
            }
        }
        private int CalcularIdade (DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }      
        public async Task<Candidato> Novocandidato(Candidato novoCandidato)
        {
             
                var idade = CalcularIdade(novoCandidato.DataNascimento);
                if (idade >= 18)
                {
                    return await _candidato.Novocandidato(novoCandidato);
                }
                    return BadRequest();
        }

       

        public  Task<Candidato> PutUpdade(Candidato novoCandidato)
         {
             return _candidato.PutUpdade(novoCandidato);
         }
          public Task<Candidato> Delete(int id)
         {
             return _candidato.Delete(id);
         }


        //     public Candidato Put(Candidato novoCandidato)
        //     {
        //          var candidatoD = new CandidatoRP(); 
        //           var candidatoPut = candidatoD.Put(novoCandidato);
        //            return candidatoPut;
        //     }        
        //     public  ActionResult Delete(int id)
        //     {
        //          var candidatoD = new CandidatoRP(); 
        //           var candidatoDel = candidatoD.Delete(id);
        //            return candidatoDel;
        //     }
         private Candidato BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}