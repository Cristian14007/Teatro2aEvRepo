using BackEnd.Models;
namespace BackEnd.Business;

public interface IAsientoService
{
    List<AsientoGetDTO> GetAll();
    // GetAll(int id);
    void Add(AsientoCreateDTO asientoCreateDTO);
    AsientoGetDTO Get(int id);
    //List<Asiento> GetFromFunction(int idFunction);
    public void Update(int id, AsientoUpdateDTO asientoUpdate);
    void Delete(int id);
}