using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Shared;

namespace Visit.DAL
{
    public class DoctorRepository
    {
        VisitDbContext db;
        public DoctorRepository()
        {
            db = new VisitDbContext();
        }
        public bool Insert(DoctorInfo info)
        {
            var tran=db.Database.BeginTransaction();
            try
            {
                Tbl_User tbl_User = new Tbl_User()
                {
                    FirstName = info.FirstName,
                    LastName = info.LastName,
                    MobileNumber = info.LastName,
                    Email = info.Email
                    //Picture
                };
                db.Tbl_Users.Add(tbl_User);
                db.SaveChanges();
                info.DoctorID = tbl_User.ID;
                Tbl_Doctor tbl_Doctor = new Tbl_Doctor()
                {
                    DoctorID = info.DoctorID,
                    CodeNezamPezeshki = info.CodeNezamPezeshki,
                };
                db.Tbl_Doctors.Add(tbl_Doctor);
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
            var tran= db.Database.BeginTransaction();
            try
            {
                var user = db.Tbl_Users.Where(d => d.ID == id).Single();
                var doctor = db.Tbl_Doctors.Where(d => d.DoctorID == id).Single();
                db.Tbl_Users.Remove(user);
                db.Tbl_Doctors.Remove(doctor);
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
        public bool Update(DoctorInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                var doctor = db.Tbl_Users.Where(d => d.ID == info.DoctorID).Single();
                var doctor2 = db.Tbl_Doctors.Where(d => d.DoctorID == info.DoctorID).Single();
                doctor.FirstName = info.FirstName;
                doctor.LastName = info.LastName;
                doctor.MobileNumber = info.MobileNumber;
                doctor.Email = info.Email;
                //doctor.Picture
                doctor2.CodeNezamPezeshki = info.CodeNezamPezeshki;
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
        public List<DoctorDto> Select(string search)
        {
            try
            {
                var doctor = db.Tbl_Doctors.AsNoTracking().Select(d => new DoctorDto()
                {
                    DoctorID = d.DoctorID,
                    FirstName = d.Tbl_User.FirstName,
                    LastName = d.Tbl_User.LastName,
                    CodeNezamPezeshki = d.CodeNezamPezeshki
                }).ToList();
                return doctor.Where(d => search == "" ||
                d.FirstName.Contains(search) ||
                d.LastName.Contains(search) ||
                d.CodeNezamPezeshki.Contains(search)).ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool DuplicateMobile(string mobile, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = db.Tbl_Users.AsNoTracking().Where(x => x.MobileNumber == mobile).Any();
            }
            else
            {
                duplicate = db.Tbl_Users.AsNoTracking().Where(x => x.MobileNumber == mobile && x.ID != id).Any();
            }
            return duplicate;
        }
        public bool DuplicateEmail(string email, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = db.Tbl_Users.AsNoTracking().Where(x => x.Email == email).Any();
            }
            else
            {
                duplicate = db.Tbl_Users.AsNoTracking().Where(x => x.Email == email && x.ID != id).Any();
            }
            return duplicate;
        }
        public bool DuplicateNezam(string nezamPezeshki, int doctorID = 0)
        {
            bool duplicate = false;
            if (doctorID == 0)
            {
                duplicate = db.Tbl_Doctors.AsNoTracking().Where(x => x.CodeNezamPezeshki == nezamPezeshki).Any();
            }
            else
            {
                duplicate = db.Tbl_Doctors.AsNoTracking().Where(x => x.CodeNezamPezeshki == nezamPezeshki && x.DoctorID != doctorID).Any();
            }
            return duplicate;
        }
    }
}
