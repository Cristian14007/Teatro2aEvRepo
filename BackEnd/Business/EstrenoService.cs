using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Business{


    public class EstrenoService : IEstrenoService
    {

        private readonly IEstrenoRepository _EstrenoRepository;

        public EstrenoService(IEstrenoRepository EstrenoRepository){
            _EstrenoRepository = EstrenoRepository;
        }
        public void Add(EstrenoCreateDTO EstrenoCreateDTO)
        {
            var Estreno = new Estreno();
            var newEstreno = Estreno.modifyEstrenoToDTO(EstrenoCreateDTO);
            _EstrenoRepository.Add(newEstreno);
        }

        public void Delete(int id)
        {
            _EstrenoRepository.Delete(id);
        }

        public EstrenoGetDTO Get(int id)
        {
            var Estreno = _EstrenoRepository.Get(id);

            return Estreno;
        }

        /* public EstrenoGetDTO GetDTO(int id){
            
            var Estreno = _EstrenoRepository.GetDTO(id);

            return Estreno;
        } */

        public List<EstrenoGetDTO> GetAll()
        {
            var Estrenos = _EstrenoRepository.GetAll();

            return Estrenos;
        }

        public void Update(int id, EstrenoUpdateDTO EstrenoUpdate)
        {
            //_EstrenoRepository.Update(Estreno);
            var EstrenoDTO = _EstrenoRepository.Get(id);
            if(EstrenoDTO == null)
            {
                throw new KeyNotFoundException($"Estreno con Id {id} no encontrada.");
            }

            var Estreno = EstrenoDTO.ToEstreno();
            Estreno.Titulo = EstrenoUpdate.Titulo;
            

            _EstrenoRepository.Update(Estreno);
            //_EstrenoRepository.SaveChanges();
        }
    }

}