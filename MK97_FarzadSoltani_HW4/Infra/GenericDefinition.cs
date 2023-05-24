using Newtonsoft.Json;
using System.Reflection;

namespace MK97_FarzadSoltani_HW4.Infra;

public class GenericDefinition<T> : IDefinition<T> where T : class
{
    string db = Environment.CurrentDirectory;
    List<T> list;

    public GenericDefinition(string fileName)
    {
        db = $@"{db}\{fileName}.txt";
        list = new List<T>();
        if (!File.Exists(db))
            CreateFile();
    }
    public void CreateFile()
    {
        File.Create(db);
    }
    public bool Insert(T entity)
    {
        var content = File.ReadAllText(db);
        list.Clear();
        list = Deserialize(content);
        list.Add(entity);
        content += Serialize(list);
        File.WriteAllText(db, content);
        return true;
    }

    public bool Delete(int id)
    {
        Type itemType = typeof(T);
        PropertyInfo keyProperty = itemType.GetProperty("Id");
        var content = File.ReadAllText(db);
        list.Clear();
        list = Deserialize(content);
        foreach (T item in list)
        {
            object itemKey = keyProperty.GetValue(item);
            if (itemKey != null && itemKey.Equals(id))
            {
                list.Remove(item);

            }
        }
        content += Serialize(list);
        File.WriteAllText(db, content);
        return true;
    }

    public List<T> GetAll()
    {
        return Deserialize(File.ReadAllText(db));
    }

    public T GetById(int id)
    {
        Type itemType = typeof(T);
        PropertyInfo keyProperty = itemType.GetProperty("Id");
        foreach (T item in list)
        {
            object itemKey = keyProperty.GetValue(item);
            if (itemKey != null && itemKey.Equals(id))
            {
                return item;

            }
        }
        return null;
    }


    public bool Update(T entity)
    {
        var content = File.ReadAllText(db);
        list.Clear();
        list = Deserialize(content);
        Type type = typeof(T);
        PropertyInfo idKey = type.GetProperty("Id");
        var entityId = idKey.GetValue(entity);
        for (int i = 0; i < list.Count; i++)
        {
            var listId = idKey.GetValue(list[i]);
            if (listId == entityId)
            {
                list[i] = entity;
            }
        }
        content += Serialize(list);
        File.WriteAllText(db, content);
        return true;
    }

    public string Serialize(List<T> entity)
    {
        var res = JsonConvert.SerializeObject(entity);
        return res;
    }
    public List<T> Deserialize(string dbContent)
    {
        var res = JsonConvert.DeserializeObject<List<T>>(dbContent);
        return res.ToList();
    }
}
