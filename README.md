## Dependencies for your project

- [KhipuChaskiApiClient] (https://www.nuget.org/packages/KhipuChaskiApiClient)

```
Install-Package KhipuChaskiApiClient
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
        public static MsgProperty buildMsgProperty(String key, String value)
        {
            MsgProperty property = new MsgProperty();
            property.Key = key;
            property.Value = value;
            return property;
        }

        public static Message BuildMessage(List<String> recipientsId, String subject, String body, List<MsgProperty> properties)
        {
            Message msg = new Message();
            msg.Subject = subject;
            msg.RecipientIdSet = recipientsId;
            msg.Body = body;
            msg.MsgProperties = properties;
            return msg;
        }

        static void Main(string[] args)
        {

            Configuration.Secret = "1234abc";
            Configuration.ReceiverId = 1234;
            PushNotificationsApi notificationApi = new PushNotificationsApi();
            try {
                List<String> recipientsId = new List<String>(new String[] { "recipient"});
                List<MsgProperty> properties = new List<MsgProperty>(new MsgProperty[] { buildMsgProperty("name","buddy") });
                Message msg = BuildMessage(recipientsId, "test subject", "test body", properties);
                SuccessResponse response = notificationApi.SendMessage(msg);
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


