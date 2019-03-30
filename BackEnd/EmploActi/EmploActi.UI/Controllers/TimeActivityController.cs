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

    public class TimeActivityController : ApiController
    {
        #region Insert TimeActivity 
        [Route("api/v1/timeactivity")]
        [HttpPost]
        public AnswerResponseBE InsertTimeActivity(TimeActivityBE ITIMAC)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            TimeActivityLogic TAL = new TimeActivityLogic();
            AR = TAL.InsertTimeActivity(ITIMAC);
            return AR;
        }
        #endregion


        #region Update TimeActivity
        [Route("api/v1/timeactivity")]
        [HttpPut]
        public AnswerResponseBE Updatetimeactivity(TimeActivityBE UPTIMEACT)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            TimeActivityLogic TAL = new TimeActivityLogic();
            AR = TAL.UpdateTimeActivity(UPTIMEACT);
            return AR;
        }
        #endregion



        #region Delete TimeActivity
        [Route("api/v1/timeactivity/{TIMEACTIVITECODE}")]
        [HttpDelete]
        public AnswerResponseBE DeleteTimeActivity(int TIMEACTIVITECODE)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            TimeActivityLogic TAL = new TimeActivityLogic();
            AR = TAL.DeleteTimeActivity(TIMEACTIVITECODE);
            return AR;
        }
        #endregion


        #region Search TimeActivity Code
        [Route("api/v1/timeactivity/searcodetimact/{SEARTIMACTCOD}")]
        [HttpGet]
        public TimeActivityBE SearchCodeTimeActivity(int SEARTIMACTCOD)
        {
            TimeActivityLogic TAL = new TimeActivityLogic();
            var ARS = TAL.SearchCodeTimeActivity(SEARTIMACTCOD);
            return ARS;
        }
        #endregion


        #region Get TimeActivity All
        [Route("api/v1/timeactivity")]
        [HttpGet]
        public List<TimeActivityBE> GetTimeActivityAll()
        {
            List<TimeActivityBE> ltstimeacti = new List<TimeActivityBE>();
            TimeActivityLogic TAL = new TimeActivityLogic();
            ltstimeacti = TAL.GetTimeActivityAll();
            return ltstimeacti;
        }
        #endregion


        #region Search Id User
        [Route("api/v1/timeactivity/seariduser/{SEARTIMACTIDUS}")]
        [HttpGet]
        public List<TimeActivityBE> SearchTimActiIdUse(int SEARTIMACTIDUS)
        {
            List<TimeActivityBE> ltstimeactiidus = new List<TimeActivityBE>();
            TimeActivityLogic TAL = new TimeActivityLogic();
            ltstimeactiidus = TAL.SearchTimActiIdUse(SEARTIMACTIDUS);
            return ltstimeactiidus;
        }
        #endregion


        #region Search ActivityCode
        [Route("api/v1/timeactivity/searacticod/{SEARTACTICOD}")]
        [HttpGet]
        public List<TimeActivityBE> SearchActivityCode(int SEARTACTICOD)
        {
            List<TimeActivityBE> ltstimeactiidus = new List<TimeActivityBE>();
            TimeActivityLogic TAL = new TimeActivityLogic();
            ltstimeactiidus = TAL.SearchActivityCode(SEARTACTICOD);
            return ltstimeactiidus;
        }
        #endregion
    }
}
