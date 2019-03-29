using EmploActi.BussinessEntities;
using EmploActi.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploActi.BussinessLogic
{
    public class UserLogic
    {
        #region Insert User
        public AnswerResponseBE InsertUser(UserBE IUSER)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                int CountUser = 0;
                CountUser = BDEA.User.Where(x => x.IdUser == IUSER.IdUser).ToList().Count();
                if (CountUser == 0)
                {
                    User US = new User();
                    US.IdUser = IUSER.IdUser;
                    US.NameUser = IUSER.NameUser;
                    US.Password = IUSER.Password;

                    BDEA.User.Add(US);
                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha insertado el usuario correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El registro ya existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                BDEA.Dispose();
            }
            return AR;
        }
        #endregion


        #region Update User
        public AnswerResponseBE UpdateUser(UserBE UPUSER)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                User user = new User();
                user = BDEA.User.Where(x => x.IdUser == UPUSER.IdUser).FirstOrDefault();
                if (user != null)
                {
                    user.NameUser = UPUSER.NameUser;
                    user.Password = UPUSER.Password;

                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha actualizado el usuario correctamente";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "El registro no existe, por favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                BDEA.Dispose();
            }
            return AR;
        }
        #endregion


        #region Search for Id User
        public UserBE SearchIdUser(int SEARIDUSE)
        {
            EmploActiEntities BDEA = new EmploActiEntities();
            UserBE idus = new UserBE();
            try
            {
                idus = (from User in BDEA.User
                        where User.IdUser == SEARIDUSE
                        select new UserBE
                        {
                            IdUser = User.IdUser,
                            NameUser = User.NameUser,
                            Password = User.Password
                        }).FirstOrDefault();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return idus;
        }

        #endregion


        #region Get All User
        public List<UserBE> GetUserAll()
        {
            List<UserBE> ltsuser = new List<UserBE>();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                ltsuser = (from User in BDEA.User
                           select new UserBE
                           {
                               IdUser = User.IdUser,
                               NameUser = User.NameUser,
                               Password = User.Password
                           }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return ltsuser;
        }
        #endregion


        #region Validation User and Password
        public AnswerResponseBE ValidatioUserPassword(string USERNAME, string PASSWORD)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                User user = new User();
                user = BDEA.User.Where(x => x.NameUser == USERNAME && x.Password == PASSWORD).FirstOrDefault();
                if (user != null)
                {

                    AR.CodeError = 0;
                    AR.DescriptionError = "Usuario correcto";
                }
                else
                {
                    AR.CodeError = 2;
                    AR.DescriptionError = "Usuario y contraseña incorrecta, favor verifique la información";
                }
            }
            catch (Exception EX)
            {
                AR.CodeError = 1;
                AR.DescriptionError = "Hubo un error";
            }
            finally
            {
                BDEA.Dispose();
            }
            return AR;
        }
        #endregion
    }
}
