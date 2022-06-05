using Microsoft.AspNetCore.Http;//for session
using Newtonsoft.Json;//for session jeson [Convert]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matjary.Controllers.handle_session_objects
{
    public static class SessionExtensions
    {
        //for session To store and relitve objects
      
            public static T GetComplexData<T>(this ISession session, string key)
            {
                var data = session.GetString(key);
                if (data == null)
                {
                    return default(T);
                }
                return JsonConvert.DeserializeObject<T>(data);
            }

            public static void SetComplexData(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
        }
    }
