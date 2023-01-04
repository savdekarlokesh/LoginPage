using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoginApp.Model;

namespace LoginApp.BusinessLayer
{
    public static class LoginBL
    {
        /// <summary>
        /// created this function to store values of username and password
        /// </summary>
        public static List<User> Userloginvalues()
        {
            List<User> objModel = new List<User>();
            objModel.Add(new User { UserName = "user1", Password = "password1" });
            objModel.Add(new User { UserName = "user2", Password = "password2" });
            objModel.Add(new User { UserName = "user3", Password = "password3" });
            objModel.Add(new User { UserName = "user4", Password = "password4" });
            objModel.Add(new User { UserName = "user5", Password = "password5" });
            return objModel;
        }
        /// <summary>
        /// created this function to update value in appsetting json.
        /// </summary>
        public static void AddOrUpdateAppSetting<T>(string key, T value)
        {
            try
            {
                //giving path as per my repo , you can change as per your project path
                var filePath = Path.Combine("c:\\problem statement\\loginpage\\LoginApp\\", "appSettings.json");
                string json = File.ReadAllText(filePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var sectionPath = key.Split(":")[0];

                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyPath = key.Split(":")[1];
                    jsonObj[sectionPath][keyPath] = value;
                }
                else
                {
                    jsonObj[sectionPath] = value; // if no sectionpath just set the value
                }

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);
            }
            catch (Exception)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
