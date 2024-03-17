using BackEnd.Data;
using BackEnd.Business;
using BackEnd.Models;


namespace BackEnd.Business
{
    public class AsientoService : IAsientoService
    {

        private readonly IAsientoRepository _asientoRepository;
        

        public AsientoService(IAsientoRepository asientoRepository){
            _asientoRepository = asientoRepository;
        
        }
        public  List<AsientoGetDTO> GetAll()
        {
            var asientos = _asientoRepository.GetAll();
            
            return _asientoRepository.GetAll();
        }

        public  AsientoGetDTO Get(int id)
        {
            var asiento = _asientoRepository.Get(id);

            return asiento;
        }

        /* public  List<AsientosObra> GetFromFunction(int idFunction)
        {
            var Asiento = _AsientoRepository.GetFromFunction(idFunction);


            return Asiento;
        } */
          

    public  void Add(AsientoCreateDTO asientoCreateDTO)
    {
        var asiento = new Asiento();
        var newAsiento = asiento.modifyAsientoToDTO(asientoCreateDTO);      
        _asientoRepository.Add(newAsiento);
    }

    public  void Update(int id, AsientoUpdateDTO asientoUpdate)
    {
        
            var asientoDTO = _asientoRepository.Get(id);
            if(asientoDTO == null)
            {
                throw new KeyNotFoundException($"Asiento con Id {id} no encontrado.");
            }
            
            var asiento = asientoDTO.ToAsiento();
            asiento.Reservado = asientoUpdate.Reservado;
            

            _asientoRepository.Update(asiento);
            //_asientoRepository.SaveChanges();

            
    }

    public  void Delete(int id)
    {
        _asientoRepository.Delete(id);
    }
}


        
    }
