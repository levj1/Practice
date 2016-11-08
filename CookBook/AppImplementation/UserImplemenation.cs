using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterface;
using AppModel;

namespace AppImplementation
{
    public class UserImplemenation : IUser
    {
        private UserContext db = new UserContext();
        public void Delete(int Id)
        {
            Users foundModel =
                db.User
                .Where(a => a.ID.Equals(Id))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            db.User.Remove(foundModel);
            db.SaveChanges();
        }

        public void Insert(Users model)
        {
            db.User.Add(model);
            db.SaveChanges();
        }

        public IEnumerable<Users> SelectAll()
        {
            return db.User.AsEnumerable();
        }

        public Users SelectOne(int Id)
        {
            return db.User
                    .Where(a => a.ID.Equals(Id))
                    .FirstOrDefault();
        }

        public void Update(Users model)
        {
            Users foundModel =
                db.User
                .Where(a => a.ID.Equals(model.ID))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            foundModel.UserName = model.UserName;
            db.User.Add(foundModel);
            db.SaveChanges();
        }
    }
}
