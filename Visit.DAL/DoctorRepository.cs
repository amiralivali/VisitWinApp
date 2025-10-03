using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public async Task<bool> InsertAsync(User user,Doctor doctor)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                doctor.DoctorID = user.ID;
                db.Doctors.Add(doctor);
                await db.SaveChangesAsync();
                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                ex.AddLog();
                tran.Rollback();
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var tran= db.Database.BeginTransaction();
            try
            {
                var user = db.Users.Where(d => d.ID == id).Single();
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                ex.AddLog();
                tran.Rollback();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(DoctorInfo info)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                var user = db.Users.Where(d => d.ID == info.DoctorID).Single();
                var doctor = db.Doctors.Where(d => d.DoctorID == info.DoctorID).Single();
                user.FirstName = info.FirstName;
                user.LastName = info.LastName;
                user.MobileNumber = info.MobileNumber;
                user.Email = info.Email;
                user.Picture = info.Picture;
                doctor.CodeNezamPezeshki = info.CodeNezamPezeshki;
                await db.SaveChangesAsync();
                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                ex.AddLog();
                tran.Rollback();
                return false;
            }
        }
        public async Task<List<DoctorDto>> SelectAsync(string search)
        {
            try
            {
                var doctors = await db.Doctors.AsNoTracking().Select(d => new DoctorDto()
                {
                    DoctorID = d.DoctorID,
                    FirstName = d.User.FirstName,
                    LastName = d.User.LastName,
                    CodeNezamPezeshki = d.CodeNezamPezeshki
                }).ToListAsync();
                return doctors.Where(d => search == "" ||
                d.FirstName.Contains(search) ||
                d.LastName.Contains(search) ||
                d.CodeNezamPezeshki.Contains(search)).ToList();
            }
            catch(Exception ex)
            {
                ex.AddLog();
                return null;
            }
        }
        public async Task<bool> ExistAsync(string Nezam, string Mobile)
        {
            bool exist = await db.Doctors.Where(b => b.CodeNezamPezeshki == Nezam && b.User.MobileNumber == Mobile).AnyAsync();
            return exist;
        }
        public async Task<bool> DuplicateMobileAsync(string mobile, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = await db.Users.Where(x => x.MobileNumber == mobile).AnyAsync();
            }
            else
            {
                duplicate = await db.Users.Where(x => x.MobileNumber == mobile && x.ID != id).AnyAsync();
            }
            return duplicate;
        }
        public async Task<bool> DuplicateEmailAsync(string email, int id = 0)
        {
            bool duplicate = false;
            if (id == 0)
            {
                duplicate = await db.Users.Where(x => x.Email == email).AnyAsync();
            }
            else
            {
                duplicate = await db.Users.Where(x => x.Email == email && x.ID != id).AnyAsync();
            }
            return duplicate;
        }
        public async Task<bool> DuplicateNezamAsync(string nezamPezeshki, int doctorID = 0)
        {
            bool duplicate = false;
            if (doctorID == 0)
            {
                duplicate = await db.Doctors.Where(x => x.CodeNezamPezeshki == nezamPezeshki).AnyAsync();
            }
            else
            {
                duplicate = await db.Doctors.Where(x => x.CodeNezamPezeshki == nezamPezeshki && x.DoctorID != doctorID).AnyAsync();
            }
            return duplicate;
        }
    }
}
