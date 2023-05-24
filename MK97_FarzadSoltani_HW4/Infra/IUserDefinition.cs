namespace MK97_FarzadSoltani_HW4.Infra;

public interface IDefinition<T>
{
    bool Create(T entity);
    bool Delete(T entity);
    bool Update(int id);
    List<T> GetAll();
    T GetById(int id);
    string Serialize(List<T> entity);
    List<T> Deserialize(string dbContent);

}
