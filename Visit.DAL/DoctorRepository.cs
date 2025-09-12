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
        public async Task<bool> InsertAsync(DoctorInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                await Task.Run(() =>
                {
                    User tbl_User = new User()
                    {
                        FirstName = info.FirstName,
                        LastName = info.LastName,
                        MobileNumber = info.LastName,
                        Email = info.Email
                        //Picture
                    };
                    db.Users.Add(tbl_User);
                    db.SaveChanges();
                    info.DoctorID = tbl_User.ID;
                    Doctor tbl_Doctor = new Doctor()
                    {
                        DoctorID = info.DoctorID,
                        CodeNezamPezeshki = info.CodeNezamPezeshki,
                    };
                    db.Doctors.Add(tbl_Doctor);
                    db.SaveChangesAsync();
                });
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var tran= db.Database.BeginTransaction();
            try
            {
                await Task.Run(() =>
                {
                    var user = db.Users.Where(d => d.ID == id).Single();
                    var doctor = db.Doctors.Where(d => d.DoctorID == id).Single();
                    db.Users.Remove(user);
                    db.Doctors.Remove(doctor);
                    db.SaveChangesAsync();
                });
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(DoctorInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                await Task.Run(() =>
                {
                    var user = db.Users.Where(d => d.ID == info.DoctorID).Single();
                    var doctor = db.Doctors.Where(d => d.DoctorID == info.DoctorID).Single();
                    user.FirstName = info.FirstName;
                    user.LastName = info.LastName;
                    user.MobileNumber = info.MobileNumber;
                    user.Email = info.Email;
                    //doctor.Picture
                    doctor.CodeNezamPezeshki = info.CodeNezamPezeshki;
                    db.SaveChangesAsync();
                });
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
                var doctor = db.Doctors.AsNoTracking().Select(d => new DoctorDto()
                {
                    DoctorID = d.DoctorID,
                    FirstName = d.User.FirstName,
                    LastName = d.User.LastName,
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
                duplicate = db.Users.AsNoTracking().Where(x => x.MobileNumber == mobile).Any();
            }
            else
            {
                duplicate = db.Users.AsNoTracking().Where(x => x.MobileNumber == mobile && x.ID != id).Any();
            }
            return duplicate;
        }
        public bool DuplicateEmail(string email, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = db.Users.AsNoTracking().Where(x => x.Email == email).Any();
            }
            else
            {
                duplicate = db.Users.AsNoTracking().Where(x => x.Email == email && x.ID != id).Any();
            }
            return duplicate;
        }
        public bool DuplicateNezam(string nezamPezeshki, int doctorID = 0)
        {
            bool duplicate = false;
            if (doctorID == 0)
            {
                duplicate = db.Doctors.AsNoTracking().Where(x => x.CodeNezamPezeshki == nezamPezeshki).Any();
            }
            else
            {
                duplicate = db.Doctors.AsNoTracking().Where(x => x.CodeNezamPezeshki == nezamPezeshki && x.DoctorID != doctorID).Any();
            }
            return duplicate;
        }
    }
}
