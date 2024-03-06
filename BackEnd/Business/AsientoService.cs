using BackEnd.Data;
using BackEnd.Business;
using BackEnd.Models;


namespace BackEnd.Business
{
    public class AsientoService : IAsientoService
    {

        private readonly IAsientoRepository _AsientoRepository;
        

        public AsientoService(IAsientoRepository AsientoRepository){
            _AsientoRepository = AsientoRepository;
        
        }
        public  List<AsientosObra> GetAll()
        {
            var Asientos = _AsientoRepository.GetAll();
            // foreach (var pizza in pizzas)
            // {
            //     pizza.Ingredientes = _ingredientesRepository.GetIngredientesByPizzaId(pizza.Id);
            // }
            return Asientos;
        }

        public  AsientosObra GetAsiento(int idFunction, int idAsiento)
        {
            var Asiento = _AsientoRepository.GetAsiento(idFunction, idAsiento);

            // if (pizza != null)
            // {
            //     pizza.Ingredientes = _ingredientesRepository.GetIngredientesByPizzaId(pizza.Id);
            // }

            return Asiento;
        }

        public  List<AsientosObra> GetFromFunction(int idFunction)
        {
            var Asiento = _AsientoRepository.GetFromFunction(idFunction);

            // if (pizza != null)
            // {
            //     pizza.Ingredientes = _ingredientesRepository.GetIngredientesByPizzaId(pizza.Id);
            // }

            return Asiento;
        }
          

    public  void Add(AsientosObra Asiento)
    {
        _AsientoRepository.Add(Asiento);

            // foreach (var ingrediente in pizza.Ingredientes)
            // {
            //     _ingredientesRepository.AddIngredienteToPizza(ingrediente, pizza.Id);
            // }
    }

    public  void Update(AsientosObra Asiento)
    {
        _AsientoRepository.Update(Asiento);

            // _ingredientesRepository.UpdateIngredientesForPizza(pizza.Ingredientes, pizza.Id);
    }

    public  void Delete(int idFunction, int idAsiento)
    {
        _AsientoRepository.Delete(idFunction, idAsiento);
    }
}


        
    }
