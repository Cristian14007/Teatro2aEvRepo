using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Business{


    public class ObraService : IObraService
    {

        private readonly IObraRepository _obraRepository;

        public ObraService(IObraRepository obraRepository){
            _obraRepository = obraRepository;
        }
        public void Add(Obra obra)
        {
            _obraRepository.Add(obra);
        }

        public void Delete(int id)
        {
            _obraRepository.Delete(id);
        }

        public ObraGetDTO Get(int id)
        {
            var obra = _obraRepository.Get(id);

            return obra;
        }

        /* public ObraGetDTO GetDTO(int id){
            
            var obra = _obraRepository.GetDTO(id);

            return obra;
        } */

        public List<ObraGetDTO> GetAll()
        {
            var obras = _obraRepository.GetAll();

            return obras;
        }

        public void Update(int id, ObraUpdateDTO obraUpdate)
        {
            //_obraRepository.Update(obra);
            var obraDTO = _obraRepository.Get(id);
            if(obraDTO == null)
            {
                throw new KeyNotFoundException($"Obra con Id {id} no encontrada.");
            }

            var obra = obraDTO.ToObra();
            obra.Titulo = obraUpdate.Titulo;
            obra.Descripcion = obraUpdate.Descripcion;

            _obraRepository.Update(obra);
            //_obraRepository.SaveChanges();
        }
    }

}
