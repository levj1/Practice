using AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterface
{
    public interface IUser
    {
        void Insert(Users model);
        void Update(Users model);
        void Delete(int Id);
        Users SelectOne(int Id);
        IEnumerable<Users> SelectAll();
    }
}
