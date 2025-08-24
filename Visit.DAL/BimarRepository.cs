using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Shared;

namespace Visit.DAL
{
    public class BimarRepository
    {
        VisitDbContext db;
        public BimarRepository()
        {
            db = new VisitDbContext();
        }
        public bool Insert(BimarInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                Tbl_User tbl_User = new Tbl_User()
                {
                    FirstName = info.FirstName,
                    LastName = info.LastName,
                    MobileNumber = info.MobileNumber,
                    Email = info.Email,
                };
                db.Tbl_Users.Add(tbl_User);
                db.SaveChanges();
                info.BimarID = tbl_User.ID;
                Tbl_Bimar tbl_Bimar = new Tbl_Bimar();
                tbl_Bimar.BimarID = info.BimarID;
                tbl_Bimar.NationalCode = info.NationalCode;
                db.Tbl_Bimars.Add(tbl_Bimar);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
        public bool Delete(int id)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                var user = db.Tbl_Users.Where(u => u.ID == id).Single();
                db.Tbl_Users.Remove(user);
                var bimar = db.Tbl_Bimars.Where(b => b.BimarID == id).Single();
                db.Tbl_Bimars.Remove(bimar);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
        public bool Update(BimarInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                var user = db.Tbl_Users.Where(b => b.ID == info.BimarID).Single();
                user.FirstName = info.FirstName;
                user.LastName = info.LastName;
                user.MobileNumber = info.MobileNumber;
                user.Email = info.Email;
                //user.Picture=
                var bimar = db.Tbl_Bimars.Where(b => b.BimarID == info.BimarID).Single();
                bimar.NationalCode = info.NationalCode;
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
        public List<BimarDto> Select(string search)
        {
            try
            {
                var Bimars = db.Tbl_Bimars.AsNoTracking().Select(b => new BimarDto()
                {
                    BimarID = b.BimarID,
                    FirstName = b.Tbl_User.FirstName,
                    LastName = b.Tbl_User.LastName,
                    NationalCode = b.NationalCode,
                }).ToList();
                return Bimars.Where(b => search == "" ||
                b.FirstName.Contains(search) ||
                b.LastName.Contains(search) ||
                b.NationalCode.Contains(search)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool DuplicateNationalCode(string nc, int bimarID = 0)
        {
            bool duplicate = false;
            if (bimarID == 0)
            {
                duplicate = db.Tbl_Bimars.Where(x => x.NationalCode == nc).Any();
            }
            else
            {
                duplicate = db.Tbl_Bimars.Where(x => x.NationalCode == nc && x.BimarID != bimarID).Any();
            }
            return duplicate;
        }
        public bool DuplicateMobile(string mobile, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = db.Tbl_Users.Where(x => x.MobileNumber == mobile).Any();
            }
            else
            {
                duplicate = db.Tbl_Users.Where(x => x.MobileNumber == mobile && x.ID != id).Any();
            }
            return duplicate;
        }
        public bool DuplicateEmail(string email, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = db.Tbl_Users.Where(x => x.Email == email).Any();
            }
            else
            {
                duplicate = db.Tbl_Users.Where(x => x.Email == email && x.ID != id).Any();
            }
            return duplicate;
        }
    }
}
