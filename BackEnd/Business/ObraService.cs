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

        public void Update(int obraId, ObraUpdateDTO obraUpdate)
        {
            //_obraRepository.Update(obra);
            var obra = _obraRepository.Get(obraId);
            if(obra == null)
            {
                throw new KeyNotFoundException($"Obra con Id {obraId} no encontrada.");
            }

            obra.Titulo = obraUpdate.Titulo;
            obra.Descripcion = obraUpdate.Descripcion;
            obra.Genero = obraUpdate.Genero;
            obra.Interpretes = obraUpdate.Interpretes;
            obra.Director = obraUpdate.Director;
            obra.Valoracion = obraUpdate.Valoracion;
            obra.Precio = obraUpdate.Precio;

            _obraRepository.Update(obra);
            _obraRepository.SaveChanges();
        }
    }

}
