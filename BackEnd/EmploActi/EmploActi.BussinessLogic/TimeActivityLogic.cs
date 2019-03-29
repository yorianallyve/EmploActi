using EmploActi.BussinessEntities;
using EmploActi.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploActi.BussinessLogic
{
    public class TimeActivityLogic
    {
        #region Insert TimeActivity
        public AnswerResponseBE InsertTimeActivity(TimeActivityBE ITIMAC)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                int CountTimeActi = 0;
                CountTimeActi = BDEA.TimeActivity.Where(x => x.CodeTimeActivity == ITIMAC.CodeTimeActivity).ToList().Count();
                if (CountTimeActi == 0)
                {
                    TimeActivity TIMACT = new TimeActivity();
                    TIMACT.CodeTimeActivity = ITIMAC.CodeTimeActivity;
                    TIMACT.ActivitiesCode = ITIMAC.ActivitiesCode;
                    TIMACT.DateActivity = ITIMAC.DateActivity;
                    TIMACT.Hours = ITIMAC.Hours;
                    TIMACT.IdUser = ITIMAC.IdUser;

                    BDEA.TimeActivity.Add(TIMACT);
                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha insertado el tiempo / actividad correctamente";
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


        #region Update TimeActivity
        public AnswerResponseBE UpdateTimeActivity(TimeActivityBE UPTIMEACT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                TimeActivity timeactivity = new TimeActivity();
                timeactivity = BDEA.TimeActivity.Where(x => x.CodeTimeActivity == UPTIMEACT.CodeTimeActivity).FirstOrDefault();
                if (timeactivity != null)
                {
                    timeactivity.ActivitiesCode = UPTIMEACT.ActivitiesCode;
                    timeactivity.DateActivity = UPTIMEACT.DateActivity;
                    timeactivity.Hours = UPTIMEACT.Hours;

                    BDEA.SaveChanges();

                    AR.CodeError = 0;
                    AR.DescriptionError = "Se ha actualizado el tiempo / actividad correctamente";
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


        #region Search for Code TimeActivity
        public TimeActivityBE SearchCodeTimeActivity(int SEARTIMACTCOD)
        {
            EmploActiEntities BDEA = new EmploActiEntities();
            TimeActivityBE idTimeacti = new TimeActivityBE();
            try
            {
                idTimeacti = (from TimeActivity in BDEA.TimeActivity
                              where TimeActivity.CodeTimeActivity == SEARTIMACTCOD
                              select new TimeActivityBE
                              {
                                  CodeTimeActivity = TimeActivity.CodeTimeActivity,
                                  ActivitiesCode = TimeActivity.ActivitiesCode,
                                  NameActivities = TimeActivity.Activities.NameActivities,
                                  DateActivity = TimeActivity.DateActivity,
                                  Hours = TimeActivity.Hours,
                                  IdUser = TimeActivity.IdUser,
                              }).FirstOrDefault();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return idTimeacti;
        }

        #endregion


        #region Get All TimeActivity
        public List<TimeActivityBE> GetTimeActivityAll()
        {
            List<TimeActivityBE> ltstimeacti = new List<TimeActivityBE>();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                ltstimeacti = (from TimeActivity in BDEA.TimeActivity
                               select new TimeActivityBE
                               {
                                   CodeTimeActivity = TimeActivity.CodeTimeActivity,
                                   ActivitiesCode = TimeActivity.ActivitiesCode,
                                   NameActivities = TimeActivity.Activities.NameActivities,
                                   DateActivity = TimeActivity.DateActivity,
                                   Hours = TimeActivity.Hours,
                                   IdUser = TimeActivity.IdUser
                               }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return ltstimeacti;
        }
        #endregion


        #region Search for Id User
        public List<TimeActivityBE> SearchTimActiIdUse(int SEARTIMACTIDUS)
        {
            List<TimeActivityBE> ltstimeactiidus = new List<TimeActivityBE>();
            EmploActiEntities BDEA = new EmploActiEntities();
            try
            {
                ltstimeactiidus = (from TimeActivity in BDEA.TimeActivity
                                   where TimeActivity.IdUser == SEARTIMACTIDUS
                                   select new TimeActivityBE
                                   {
                                       CodeTimeActivity = TimeActivity.CodeTimeActivity,
                                       ActivitiesCode = TimeActivity.ActivitiesCode,
                                       NameActivities = TimeActivity.Activities.NameActivities,
                                       DateActivity = TimeActivity.DateActivity,
                                       Hours = TimeActivity.Hours,
                                       IdUser = TimeActivity.IdUser
                                   }).ToList();
            }
            catch (Exception EX)
            {

            }
            finally
            {
                BDEA.Dispose();
            }
            return ltstimeactiidus;
        }
        #endregion
    }
}
