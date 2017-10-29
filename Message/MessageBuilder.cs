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
        private static MailMessage mailMessage;
        private static SmtpClient smtpClient;

        public MessageBuilder()
        {
            smtpClient = new SmtpClient();
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string From { get; set; }

        public string To { get; set; }
        public List<string> ToMany { get; set; }

        public bool IsNewCustomer { get; set; }



        public static void SendEmail(MessageBuilder messageBuilder)
        {
            messageBuilder.Body += messageBuilder.IsNewCustomer == true ? EncryptEmail(messageBuilder.To) : string.Empty;
            mailMessage = new MailMessage("d015240@student.nibm.lk", messageBuilder.To)
            {
                Subject = messageBuilder.Subject,
                Body = messageBuilder.Body
            };
            smtpClient.Send(mailMessage);
        }

        public static void SendEmails(MessageBuilder messageBuilder)
        {
            
        }

        private static string EncryptEmail(string EmailTo)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(EmailTo);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                        cryptoStream.Close();
                    }
                    EmailTo = Convert.ToBase64String(ms.ToArray());
                }
            }
            return EmailTo;
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
                    using (CryptoStream cryptoStream = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                        cryptoStream.Close();
                    }
                    id = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return id;
        }
    }
}
