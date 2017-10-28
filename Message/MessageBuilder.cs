using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Message
{
    public class MessageBuilder
    {
        private static readonly string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static void SendEmail(string EmailAddress,string CustomerFirstName, string CustomerLastName)
        {
            var EncryptedEmail = EncryptEmail(EmailAddress);
            MailMessage mailMessage = new MailMessage("d015240@student.nibm.lk", EmailAddress)
            {
                Subject = "PAYmate Confirmation mail",
                //Body = "Hai "+CustomerLastName+" Click on the link below to confirm your email address.\n\n" + "http://localhost:54283/Security/Confirmation?id=" + EncryptedEmail
                Body = "Hai "+ CustomerFirstName+" "+CustomerLastName+" \n\n Click on the link below to confirm your email address.\n\n" + "http://paymatelk.azurewebsites.net/Security/Confirmation?id=" + EncryptedEmail
            };
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }

        private static string EncryptEmail(string Email)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(Email);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    Email = Convert.ToBase64String(ms.ToArray());
                }
            }
            return Email;
        }

        public static string Decrypt(string id)
        {
            id = id.Replace(" ", "+");
            int mod4 = id.Length % 4;
            if (mod4 > 0)
            {
                id += new string('=', 4 - mod4);
            }
            byte[] cipherBytes = Convert.FromBase64String(id);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    id = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return id;
        }
    }
}
