using BackEnd.Models;
namespace BackEnd.Business;

public interface IAsientoService
{
    List<AsientoGetDTO> GetAll();
    // GetAll(int id);
    void Add(Asiento asiento);
    Asiento Get(int id);
    //List<Asiento> GetFromFunction(int idFunction);
    public void Update(int asientoId, AsientoUpdateDTO asientoUpdate);
    void Delete(int id);
}