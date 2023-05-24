using Newtonsoft.Json;

namespace MK97_FarzadSoltani_HW4.Infra;

public static class FilesManager<T>
{
    public static string Serialize(List<T> entity)
    {
        var res = JsonConvert.SerializeObject(entity);
        return res;
    }
    public static List<T> Deserialize(string dbContent)
    {
        var res = JsonConvert.DeserializeObject<List<T>>(dbContent);
        if (res != null)
            return res.ToList();
        return new List<T>();
    }
}