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

    public class UserController : ApiController
    {
        #region Insert InsertUser 
        [Route("api/v1/user")]
        [HttpPost]
        public AnswerResponseBE InsertUser(UserBE IUSER)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            UserLogic UL = new UserLogic();
            AR = UL.InsertUser(IUSER);
            return AR;
        }
        #endregion


        #region Update User
        [Route("api/v1/user")]
        [HttpPut]
        public AnswerResponseBE UpdateUser(UserBE UPUSER)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            UserLogic UL = new UserLogic();
            AR = UL.UpdateUser(UPUSER);
            return AR;
        }
        #endregion


        #region Search for Id User
        [Route("api/v1/user/seariduser/{SEARIDUSE}")]
        [HttpGet]
        public UserBE SearchIdUser(int SEARIDUSE)
        {
            UserLogic UL = new UserLogic();
            var ARS = UL.SearchIdUser(SEARIDUSE);
            return ARS;
        }
        #endregion


        #region Get User All
        [Route("api/v1/user")]
        [HttpGet]
        public List<UserBE> GetUserAll()
        {
            List<UserBE> ltsuser = new List<UserBE>();
            UserLogic UL = new UserLogic();
            ltsuser = UL.GetUserAll();
            return ltsuser;
        }
        #endregion


        #region Validation User and Password
        [Route("api/v1/user/login")]
        [HttpPost]
        public AnswerResponseBE ValidatioUserPassword(string USERNAME, string PASSWORD)
        {
            AnswerResponseBE AR = new AnswerResponseBE();
            UserLogic UL = new UserLogic();
            AR = UL.ValidatioUserPassword(USERNAME, PASSWORD);
            return AR;
        }
        #endregion
    }
}
