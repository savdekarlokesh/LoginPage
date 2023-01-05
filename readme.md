
## Title

WPF Login App To Authonticate User.

## How To Run
 
 - One solution added two project one WPF Application(LoginPage) and .Net Core web API(LoginApp).
 - Open In Visual Studio - > LoginApp -> Set as startup Project - > ctrl + F5
 - Click on LoginPage -> Set as startup Project -> F5
 - Ready for Use.
 
## Note
 - as per project location need to set appsetting.json file path into below Code location.
  LoginApp->BusinessLayer -> LoginBL.cs - > line no 33.
## Info
-  Valid username and Password is user1 and password1.
-  Inside Event Viewer Log will create name of "SomeApi" after two invalid attempt and log message will be  “Unauthorized request”
-  Used Microsoft.Toolkit.Uwp.Notifications package for Toast message.
-  Invalid attempt Count Store in Appsetting.json and for this created seprate Function to store counter value into appsetting.json. 
 
 
## Technologies Used

 - WPF
 - .Net Core web API

## Used Packages

 - Microsoft.Extensions.Logging.EventLog
 - Newtonsoft.Json
 - Microsoft.Toolkit.Uwp.Notifications
 - System.Net.Http
 - Microsoft.AspNet.WebApi.Client
 
 ## Postman Curl To Check API

```postman
curl --location --request POST 'https://localhost:44309/api/login' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserName": "username1",
 ```
 
 
    
    



 
