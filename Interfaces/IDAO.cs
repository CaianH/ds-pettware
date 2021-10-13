using System;
using System.Collections.Generic;
using System.Text;

namespace PETTWARE.Interfaces
{
    /// <summary>
    /// interface (contrato) para Classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IDAO<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> List();

        T GetById(int id);
    }
}
