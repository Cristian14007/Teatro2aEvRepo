using BackEnd.Models;
namespace BackEnd.Business;

public interface IAsientoService
{
    List<AsientosObra> GetAll();
    // GetAll(int id);
    void Add(AsientosObra Asientos);
    AsientosObra GetAsiento(int idFunction, int idAsiento);
    List<AsientosObra> GetFromFunction(int idFunction);
    void Update(AsientosObra Asientos);
    void Delete(int idFunction, int idAsiento);
}