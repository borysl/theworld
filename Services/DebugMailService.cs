using System.Diagnostics;

namespace TheWorld.Services
{
    public class DebugMailService : IMailService
    {
        public void SendMail(string to, string @from, string title, string body)
        {
            Debug.WriteLine($"Sending Mail: To: {to} From {@from}. Titled: {title} Body: {body}");
        }
    }
}
