using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MVC5RealWorld.Models.DB;
using MVC5RealWorld.Models.ViewModel;

namespace MVC5RealWorld.Models.EntityManager
{
  public class UserManager
  {
    public void AddUserAccount(UserSignUpView user)
    {
      using (DemoDBEntities db = new DemoDBEntities())
      {
        SYSUser SU = new SYSUser()
        {
          LoginName = user.LoginName,
          PasswordEncryptedText = user.Password,
          RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
          RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
          RowCreatedDateTime = DateTime.Now,
          RowMOdifiedDateTime = DateTime.Now
        };

        db.SYSUsers.Add(SU);
        db.SaveChanges();

        SYSUserProfile SUP = new SYSUserProfile()
        {
          SYSUserID = SU.SYSUserID,
          FirstName = user.FirstName,
          LastName = user.LastName,
          Gender = user.Gender,
          RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
          RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
          RowCreatedDateTime = DateTime.Now,
          RowModifiedDateTime = DateTime.Now
        };

        db.SYSUserProfiles.Add(SUP);
        db.SaveChanges();

        if (user.LOOKUPRoleID > 0)
        {
          SYSUserRole SUR = new SYSUserRole()
          {
            LOOKUPRoleID = user.LOOKUPRoleID,
            SYSUserID = user.LOOKUPRoleID,
            IsActive = true,
            RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
            RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1,
            RowCreatedDateTime = DateTime.Now,
            RowModifiedDateTime = DateTime.Now
          };

          db.SYSUserRoles.Add(SUR);
          db.SaveChanges();
        }
      }
    }

    public bool IsLoginNameExist(string loginName)
    {
      using (DemoDBEntities db = new DemoDBEntities())
      {
        return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
        //return db.SYSUsers.Any(o => o.LoginName.Equals(loginName));
      }
    }

  }
}