using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqAdoNetDemo.DAO
{
    // T - тип сущности из класса-потомка
    public abstract class AbstractDAO<T>
    {
        protected DiseaseEntities1 mDb;
        public AbstractDAO(DiseaseEntities1 _db)
        {
            mDb = _db;
        }
        public T Find(int _id)
        {
            // PropNameCreator(typeof(T).Name)
            // PropertyInfo dbSetInfo = mDb.GetType().GetProperty(typeof(T).Name + "s");
            PropertyInfo dbSetInfo = mDb.GetType().GetProperty(PropNameCreator(typeof(T).Name));
            Object o = dbSetInfo.GetValue(mDb, null);
            MethodInfo find = o.GetType().GetMethod("Find");
            T result = (T)find.Invoke(o, new object[] { new object[] { _id } });
            return result;
        }

        public T Remove(T _entity)
        {
            T result = default(T);
            if (_entity != null)
            {
                PropertyInfo dbSetInfo = mDb.GetType().GetProperty(PropNameCreator(typeof(T).Name));
                Object o = dbSetInfo.GetValue(mDb, null);
                MethodInfo remove = o.GetType().GetMethod("Remove");
                result = (T)remove.Invoke(o, new object[] { _entity });
                mDb.SaveChanges();
            }
            else {
                throw new Exception("Entity not found!");
            }
            return result;
        }

        public T Save(T _entityForSave)
        {
            // Ищем в таблице, соответствующей сущности Т
            // строку с идентификатором как у объекта сущности _entityForSave
            Console.WriteLine(_entityForSave.GetType().GetProperty("Id").GetValue(_entityForSave));
            int userId =
                (int)(_entityForSave.GetType().GetProperty("Id").GetValue(_entityForSave));
            // Если такая строка уже есть в БД - делаем обновление
            if (userId != 0)
            {
                Console.WriteLine("update");
                T entityFromDb = Find((int)userId);
                Type type = typeof(T);
                foreach (var prop in type.GetProperties())
                {
                    prop.SetValue(entityFromDb, prop.GetValue(_entityForSave));
                }
                _entityForSave = entityFromDb;
            }
            // Если строки с таким ИД нет - делаем вставку новой строки
            else
            {
                Console.WriteLine("insert");
                PropertyInfo dbSetInfo = mDb.GetType().GetProperty(PropNameCreator(typeof(T).Name));
                Object o = dbSetInfo.GetValue(mDb, null);
                MethodInfo add = o.GetType().GetMethod("Add");
                add.Invoke(o, new object[] { _entityForSave });
            }
            mDb.SaveChanges();
            return _entityForSave;
        }

        private string PropNameCreator(string _name)
        {
            // Последняя буква названия сущности - y, перед которой идет гласная, или любая согласная
            // - окончание s
            // Book - Books, Publisher - Publishers
            // Day - Days
            if (Regex.IsMatch(_name, "[A-z]{1,}(?i:[aeiouy])[y]$")
                || Regex.IsMatch(_name, "[A-z]{1,}(?i:[^aeiouy])$"))
            {
                _name = _name + "s";
            }
            // Последняя буква - y, перед которой идет согласная 
            // Entity - Entities
            else
            {
                _name = _name.Remove(_name.Length - 1) + "ies";
            }
            return _name;
        }
    }
}
