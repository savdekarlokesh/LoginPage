using LoginApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using LoginApp.BusinessLayer;
using System.Diagnostics;

namespace LoginApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private int Counter { get; set; }
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// login controller
        /// </summary>
        [HttpPost]
        [Route("login")]
        public string Login(User user)
        {
            string message = string.Empty;
            //using below statement check username or password.
            var validate = LoginBL.Userloginvalues().Where(m => m.UserName == user.UserName && m.Password == user.Password).FirstOrDefault();
            if (validate != null)
            {
                message = "Login successful";
                //below function add or update counter value into appsetting json same used for capture Invalid count
                LoginBL.AddOrUpdateAppSetting("InvalidAttempt:Counter", "0");
            }
            else
            {
                Counter = Convert.ToInt32(_configuration.GetValue<string>("InvalidAttempt:Counter"));
                if (Counter > 2)
                {
                    //If more than two Invalid attemptd then updated log into windows event logger.
                    using (var eventlog = new EventLog("LoginAPI"))
                    {
                        if (!EventLog.SourceExists("LoginAPI"))
                        {
                            EventLog.CreateEventSource("LoginAPI", "SomeApi");
                        }
                        eventlog.Source = "LoginAPI";
                        eventlog.Log = "SomeApi";
                        eventlog.WriteEntry("Unauthorized request");
                    }
                }
                else
                {
                    Counter++ ;
                    LoginBL.AddOrUpdateAppSetting("InvalidAttempt:Counter", Counter.ToString());
                }
                message = "Invalid credentials";
            }
            return message;
        }

      


    }
}

