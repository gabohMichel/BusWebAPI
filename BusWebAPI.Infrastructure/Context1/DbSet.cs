using BusWebAPI.Domain.Common;
using Newtonsoft.Json;

namespace BusWebAPI.Infrastructure.Context1
{
    public class DbSet<T> : IDbSet<T> where T : class, IEntiryBase, new()
    {
        private readonly string pathFile;
        public DbSet()
        {
            string nameFile = typeof(T).Name;
            pathFile = Constants.PATH_JSON_FILE + nameFile + ".json";
        }
        public T Get(int key)
        {
            List<T> l = (List<T>)GetDataTable();
            return l.Where(o => o.Id.Equals(key)).FirstOrDefault();
        }
        public IEnumerable<T>? GetList()
        {
            return GetDataTable();
        }
        public T Add(T entity)
        {
            var l = (List<T>)GetDataTable();
            l.Add(entity);
            SaveTable(l);
            return entity;
        }
        public T Update(T entity) 
        {
            List<T> l = (List<T>)GetDataTable();
            var index = l.IndexOf(entity);
            if (index == -1)
                return null;

            l[index] = entity;

            if(!SaveTable(l))
                return null;

            return entity;
        }
        public bool Delete(T entity) 
        {
            List<T> l = (List<T>)GetDataTable();
            var index = l.IndexOf(entity);

            if (index == -1)
                return false;

            l.RemoveAt(index);

            if (!SaveTable(l))
                return false;

            return true;
        }
        private IEnumerable<T> GetDataTable()
        {
            string fileContent = string.Empty;
            try
            {
                fileContent = File.ReadAllText(pathFile);

                if (string.IsNullOrWhiteSpace(fileContent))
                    return new List<T>();
                return JsonConvert.DeserializeObject<List<T>>(fileContent);
            }
            catch (Exception e)
            {
                return new List<T>();
            }
        }
        private bool SaveTable(List<T> table)
        {
            string output = string.Empty;
            try
            {
                output = JsonConvert.SerializeObject(table);
                File.WriteAllText(pathFile, output);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
