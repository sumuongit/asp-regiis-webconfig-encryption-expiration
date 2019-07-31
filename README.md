## Table of Contents
* [General Info](#general-info)
* [Implementation](#implementation)
* [Technologies](#technologies)
* [Setup](#setup)
* [Contributing](#contributing)
* [License](#license)

## General Info
A simple application on how to set expiration date (trial version) in a web application using ASP.NET

## Implementation
The steps as following are the implementation for setting expiration date (trial version) in a web application using ASP.NET.

**Step 1: Set the Entry Point of the Application Conditional which is Based on the Expired Date**<br/>
```
using System;
using System.Globalization;

namespace WebApplication_WithExpiration
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string expiredDate = System.Configuration.ConfigurationManager.AppSettings["ExpiredDate"].ToString();
            DateTime date = DateTime.ParseExact(expiredDate, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);

            if (date <= DateTime.Now)
            {                
                Response.Redirect("Expiration.aspx");
            }
        }    
    }
 }
```

**Step 2: Configure the Web.config Appsettings**<br/>
```
<appSettings>
    <add key="ExpiredDate" value="2019-12-31 23:59:59 PM" />
</appSettings>  
```

**Step 3: Encrypt the Web.config Appsettings**<br/>
Please run the following command as administrator in Visual Studio command prompt:
```
aspnet_regiis.exe -pef "appSettings" "web.config file Path" -prov "DataProtectionConfigurationProvider"
```

**Step 4: Decrypt the Web.config Appsettings for Resetting the Expired Date, If Necessary**<br/>
Please run the following command as administrator in Visual Studio command prompt:
```
aspnet_regiis.exe -pdf "appSettings" "web.config file Path"
```

## Technologies
This application is created with:
* Visual Studio 2017
* C# 
* ASP.NET
	
## Setup
To clone and run this repository you will need [Git](https://git-scm.com/) installed on your computer. From your command line:

```
# Clone this repository
$ git clone https://github.com/sumuongit/asp-regiis-webconfig-encryption-expiration.git
# Go into the repository
$ cd asp-regiis-webconfig-encryption-expiration
```

## Contributing
* Fork the repository
* Create a topic branch
* Implement your feature or bug fix
* Add, commit, and push your changes
* Submit a pull request

## License
[MIT License](https://github.com/sumuongit/asp-regiis-webconfig-encryption-expiration/blob/master/LICENSE)
