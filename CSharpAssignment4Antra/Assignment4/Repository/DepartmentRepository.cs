using Assignment4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        List<Department> _list;
        public DepartmentRepository()
        {
            _list = new List<Department>();
        }
        public void Delete(int id)
        {
            Department d = GetById(id);
            if (d != null) { _list.Remove(d); }
        }

        public IEnumerable<Department> GetAll()
        {
            return _list;
        }

        public Department GetById(int id)
        {
            foreach (var dept in _list)
            {
                if(id == dept.Id) { return dept; }
            }
            return null;
        }

        public void Insert(Department entity)
        {
            _list.Add(entity);
        }

        public void Update(Department entity)
        {
            Department dept = GetById(entity.Id);
            if (dept != null)
            {
                dept.Location = entity.Location;
                dept.Name = entity.Name;
            }
        }
    }
}
