namespace MK97_FarzadSoltani_HW4.Infra;

public interface IDefinition<T>
{
    void CreateFile();
    bool Insert(T entity);
    bool Delete(int id);
    bool Update(T entity);
    List<T> GetAll();
    T GetById(int id);
    string Serialize(List<T> entity);
    List<T> Deserialize(string dbContent);

}
