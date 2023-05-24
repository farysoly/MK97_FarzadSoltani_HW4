namespace MK97_FarzadSoltani_HW4.Infra;

public class GenericDefinition<T> : IDefinition<T> where T : class
{
    string fileDir = Environment.CurrentDirectory;

    public GenericDefinition(string storageName)
    {
        fileDir = $@"{fileDir}\{storageName}.txt";
    }
    public bool Create(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> Deserialize(string dbContent)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public string Serialize(List<T> entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(int id)
    {
        throw new NotImplementedException();
    }


}
