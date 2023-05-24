using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace MK97_FarzadSoltani_HW4.Infra
{
    public class GenericDefinition<T> : IDefinition<T> where T : class
    {
        private string db;
        private List<T> dbList;

        public GenericDefinition(string fileName)
        {
            db = Path.Combine(Environment.CurrentDirectory, $"{fileName}.txt");
            dbList = new List<T>();
            if (!File.Exists(db))
                CreateFile();
            else
                dbList = GetAll();
        }

        public void CreateFile()
        {
            File.Create(db).Close();
        }

        public bool Insert(T entity)
        {
            int maxId = GetMaxId();
            PropertyInfo idProperty = typeof(T).GetProperty("Id");
            idProperty.SetValue(entity, maxId + 1);

            dbList.Add(entity);
            SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Type itemType = typeof(T);
            PropertyInfo keyProperty = itemType.GetProperty("Id");

            for (int i = dbList.Count - 1; i >= 0; i--)
            {
                T item = dbList[i];
                object itemKey = keyProperty.GetValue(item);
                if (itemKey != null && itemKey.Equals(id))
                {
                    dbList.RemoveAt(i);
                }
            }

            SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            string content = File.ReadAllText(db);
            return FilesManager<T>.Deserialize(content);
        }

        public T GetById(int id)
        {
            Type itemType = typeof(T);
            PropertyInfo keyProperty = itemType.GetProperty("Id");

            foreach (T item in dbList)
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
            Type type = typeof(T);
            PropertyInfo idKey = type.GetProperty("Id");
            object entityId = idKey.GetValue(entity);

            for (int i = 0; i < dbList.Count; i++)
            {
                T item = dbList[i];
                object listId = idKey.GetValue(item);
                if (listId != null && listId.Equals(entityId))
                {
                    dbList[i] = entity;
                    break;
                }
            }

            SaveChanges();
            return true;
        }

      

        private int GetMaxId()
        {
            PropertyInfo idProperty = typeof(T).GetProperty("Id");
            int maxId = dbList.Any() ? dbList.Select(item => (int)idProperty.GetValue(item)).Max() : 0;
            return maxId;
        }

        private void SaveChanges()
        {
            string content = FilesManager<T>.Serialize(dbList);
            File.WriteAllText(db, content);
        }
        public object GetIdValue(T entity)
        {
            Type type = typeof(T);
            PropertyInfo idKey = type.GetProperty("Id");
            return idKey.GetValue(entity);
        }
    }
}


