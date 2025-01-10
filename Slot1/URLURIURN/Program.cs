using System.Net;

namespace URLURIURN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uri info = new Uri("https://flm.fpt.edu.vn/gui/role/student/SyllabusDetails?sylID=12215");
            //Uri page = new Uri("https://fu-edunext.fpt.edu.vn/course?id=2899");
            //Console.WriteLine($"Host: {info.Host}");
            //Console.WriteLine($"Post: {info.Port}");
            //Console.WriteLine($"PathAndQuery: {info.PathAndQuery}");
            //Console.WriteLine($"Query: {info.Query}");

            //Console.WriteLine($"Fragment: {info.Fragment}");
            //Console.WriteLine($"Default: {info.Port}");
            //Console.WriteLine($"IsBaseOf: {info.IsBaseOf(page)}");

            //Uri relative = info.MakeRelativeUri(page);
            //Console.WriteLine($"IsAbsoluteRui: {relative.IsAbsoluteUri}");
            //Console.WriteLine($"RelativeUri: {relative.ToString()}");
            //Console.ReadLine();
            WebReqResp();
        }

        static void WebReqResp ()
        {
            // TODO: RESEARCH
            WebRequest req = WebRequest.Create("https://www.facebook.com/");
            req.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Console.WriteLine($"Status: {resp.StatusDescription}");
            Console.WriteLine(new String('*', 50));
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            string respFromServer = reader.ReadToEnd();
            Console.WriteLine(respFromServer);
            Console.WriteLine(new String('*', 50));
            reader.Close();
            resp.GetResponseStream().Close();
            resp.Close();
        }
    }
}
