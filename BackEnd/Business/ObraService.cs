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

        public Obra Get(int id)
        {
            var obra = _obraRepository.Get(id);

            return obra;
        }

        public List<Obra> GetAll()
        {
            var obras = _obraRepository.GetAll();

            return _obraRepository.GetAll();
        }

        public void Update(Obra obra)
        {
            _obraRepository.Update(obra);
        }
    }

}
