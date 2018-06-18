## Dependencies
- [RestSharp] (https://www.nuget.org/packages/RestSharp)
- [Json.NET] (https://www.nuget.org/packages/Newtonsoft.Json/)

```
Install-Package RestSharp
Install-Package Newtonsoft.Json
``` 


## Usage

### Basic usage
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhipuChaski;
using KhipuChaski.Client;
using KhipuChaski.Api;
using KhipuChaski.Model;

namespace ChaskiApiClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration.Secret = "1234abc";
            Configuration.ReceiverId = 1234;
            PushNotificationsApi notificationApi = new PushNotificationsApi();
            try {
                SuccessResponse response = notificationApi.MsgPost("recipient", "test", "test");
                System.Console.WriteLine(response);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
            System.Console.Read();
        }
    }
}
```


