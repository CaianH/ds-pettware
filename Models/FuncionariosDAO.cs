using System;
using System.Collections.Generic;
using System.Text;
using PETTWARE.Interfaces;

namespace PETTWARE.Models
{
    class FuncionariosDAO : IDAO<Funcionarios>
    {
        /*
         * insert
         * update
         * delete
         * list (select * from funcionario)
         * getbyid(int id) (select * from funcionario where cod_func = 1)
        */
        public void Delete(Funcionarios t)
        {
            throw new NotImplementedException();
        }

        public Funcionarios GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionarios t)
        {
            throw new NotImplementedException();
        }

        public List<Funcionarios> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionarios t)
        {
            throw new NotImplementedException();
        }
    }
}
