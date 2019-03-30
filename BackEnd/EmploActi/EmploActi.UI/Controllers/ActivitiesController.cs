using EmploActi.BussinessEntities;
using EmploActi.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmploActi.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ActivitiesController : ApiController
    {
        #region Insert Activities 
        [Route("api/v1/activities")]
        [HttpPost]
        public AnswerResponseBE InsertActivities(ActivitiesBE IACT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            ActivitiesLogic AL = new ActivitiesLogic();
            AR = AL.InsertActivities(IACT);
            return AR;
        }
        #endregion


        #region Update Activities
        [Route("api/v1/activities")]
        [HttpPut]
        public AnswerResponseBE UpdateActivities(ActivitiesBE UPACTI)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            ActivitiesLogic AL = new ActivitiesLogic();
            AR = AL.UpdateActivities(UPACTI);
            return AR;
        }
        #endregion


        #region Search Activities Code
        [Route("api/v1/activities/searcodeact/{SEARACTCOD}")]
        [HttpGet]
        public ActivitiesBE SearchCodeActivities(int SEARACTCOD)
        {
            ActivitiesLogic AL = new ActivitiesLogic();
            var ARS = AL.SearchCodeActivities(SEARACTCOD);
            return ARS;
        }
        #endregion


        #region Get Activities All
        [Route("api/v1/activities")]
        [HttpGet]
        public List<ActivitiesBE> GetActivitiesAll()
        {
            List<ActivitiesBE> ltstimeacti = new List<ActivitiesBE>();
            ActivitiesLogic TAL = new ActivitiesLogic();
            ltstimeacti = TAL.GetActivitiesAll();
            return ltstimeacti;
        }
        #endregion


        #region Get Activities By User
        [Route("api/v1/activitiesbyuser/{IDUSER}")]
        [HttpGet]
        public List<ActivitiesBE> GetActivitiesByUser(int IDUSER)
        {
            List<ActivitiesBE> ltstimeacti = new List<ActivitiesBE>();
            ActivitiesLogic TAL = new ActivitiesLogic();
            ltstimeacti = TAL.GetActivitiesByUser(IDUSER);
            return ltstimeacti;
        }
        #endregion 
    }
}
