using System.Collections.Generic;
using GYM.Models.Session;
namespace GYM.Interface
{
    internal interface ILogin
    {

        List<SessionModel> GetData(string username);

    }
}
