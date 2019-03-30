using EmploActi.BussinessEntities;
using EmploActi.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploActi.BussinessLogic
{
    public class ActivitiesLogic
    {
        #region Insert Activities
        public AnswerResponseBE InsertActivities(ActivitiesBE IACT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                int CountActi = 0;
                CountActi = BDEA.Activities.Where(x => x.ActivitiesCode == IACT.ActivitiesCode).ToList().Count();
                if (CountActi == 0)
                {
                    Activities ACTIV = new Activities();
                    ACTIV.NameActivities = IACT.NameActivities;
                    ACTIV.IdUser = IACT.IdUser;

                    BDEA.Activities.Add(ACTIV);
                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha insertado la actividad correctamente";
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


        #region Update Activities
        public AnswerResponseBE UpdateActivities(ActivitiesBE UPACTI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                Activities activities = new Activities();
                activities = BDEA.Activities.Where(x => x.ActivitiesCode == UPACTI.ActivitiesCode).FirstOrDefault();
                if (activities != null)
                {
                    activities.NameActivities = UPACTI.NameActivities;

                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha actualizado la actividad correctamente";
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


        #region Search for Code Activities
        public ActivitiesBE SearchCodeActivities(int SEARACTCOD)
        {
            EmploActiEntities BDEA = new EmploActiEntities();
            ActivitiesBE idacti = new ActivitiesBE();
            try
            {
                idacti = (from Activities in BDEA.Activities
                          where Activities.ActivitiesCode == SEARACTCOD
                          select new ActivitiesBE
                          {
                              ActivitiesCode = Activities.ActivitiesCode,
                              NameActivities = Activities.NameActivities
                          }).FirstOrDefault();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return idacti;
        }

        #endregion


        #region Get All Activities
        public List<ActivitiesBE> GetActivitiesAll()
        {
            List<ActivitiesBE> ltsactivi = new List<ActivitiesBE>();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                ltsactivi = (from Activities in BDEA.Activities
                             select new ActivitiesBE
                             {
                                 ActivitiesCode = Activities.ActivitiesCode,
                                 NameActivities = Activities.NameActivities
                             }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return ltsactivi;
        }
        #endregion


        #region Get Activities By User
        public List<ActivitiesBE> GetActivitiesByUser(int IDUSER)
        {
            List<ActivitiesBE> ltsactivi = new List<ActivitiesBE>();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                ltsactivi = (from Activities in BDEA.Activities
                             where Activities.IdUser == IDUSER
                             select new ActivitiesBE
                             {
                                 ActivitiesCode = Activities.ActivitiesCode,
                                 NameActivities = Activities.NameActivities
                             }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return ltsactivi;
        }
        #endregion
    }
}
