
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Barney.WebUI.Infrastructure
{
    public class CertificateStore
    {
        public static X509Certificate2 GetCertificate(string certificatePath, SecureString certificatePassword)
        {


            return new X509Certificate2(certificatePath, certificatePassword);



        }
    }
}
