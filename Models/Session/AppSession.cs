using Newtonsoft.Json;
using System.Web;

namespace GYM.Models.Session
{
    public class AppSession
    {
        public static SessionRepositoryModel Session
        {
            get
            {
                if (HttpContext.Current.Session["App"] == null)
                
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<SessionRepositoryModel>(HttpContext.Current.Session["App"].ToString());
                }
            }
            set
            {
                HttpContext.Current.Session["App"] = JsonConvert.SerializeObject(value).ToString();
            }
        }
    }
}