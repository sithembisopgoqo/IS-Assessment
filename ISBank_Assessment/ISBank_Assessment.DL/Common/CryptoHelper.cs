using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.DL
{
    /// <summary>
    /// Summary description for CryptoHelper
    /// </summary>
    public class CryptoHelper<T>
        where T : SymmetricAlgorithm, new()
    {

        //private readonly string IV = "SuFjcEmp/TE=";
        private readonly string IV = string.Empty;
        //private readonly string Key = "KIPSToILGp6fl+3gXJvMsN4IajizYBBT";
        private readonly string Key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoHelper"/> class.
        /// </summary>
        public CryptoHelper()
        {
            dynamic settings = new AppSettingsWrapper();

            IV = settings.IV;
            Key = settings.Key;
        }

        #region Encrypt

        /// <summary>
        /// Gets the encrypted value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>        
        /// <returns></returns>
        public string GetEncryptedValue(string inputValue)
        {
            return GetEncryptedValue(inputValue, IV);
        }

        /// <summary>
        /// Gets the encrypted value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <param name="IV">the IV for this input</param>
        /// <returns></returns>
        public string GetEncryptedValue(string inputValue, string IV)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return null;
            }

            T provider = this.GetCryptoProvider(IV);
            var test = provider.LegalBlockSizes.Single().MinSize;
            // Create a MemoryStream.
            MemoryStream mStream = new MemoryStream();

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream cStream = new CryptoStream(mStream,
                provider.CreateEncryptor(), CryptoStreamMode.Write);

            // Convert the passed string to a byte array.: Bug fixed, see update below!
            // byte[] toEncrypt = new ASCIIEncoding().GetBytes(inputValue);
            byte[] toEncrypt = new UTF8Encoding().GetBytes(inputValue);

            // Write the byte array to the crypto stream and flush wt.
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();

            // Get an array of bytes from the 
            // MemoryStream that holds the 
            // encrypted data.
            byte[] ret = mStream.ToArray();

            // Close the streams.
            cStream.Close();
            mStream.Close();

            // Return the encrypted buffer.
            return Convert.ToBase64String(ret);
        }

        #endregion Encrypt


        /// <summary>
        /// Gets the crypto provider.
        /// </summary>
        /// <returns></returns>
        private T GetCryptoProvider(string IV)
        {
            T provider = new T();
            UTF8Encoding utf8 = new UTF8Encoding();
            provider.Key = utf8.GetBytes(Key);
            provider.IV = utf8.GetBytes(IV);
            return provider;
        }

        /// <summary>
        /// Creates an initialization vector from the symmetric provider
        /// </summary>
        /// <returns></returns>
        internal string GetIV()
        {
            T provider = new T();
            provider.GenerateIV();
            return new UTF8Encoding().GetString(provider.IV);
        }

        #region Decrypt

        /// <summary>
        /// Gets the decrypted value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>        
        /// <returns></returns>
        public string GetDecryptedValue(string inputValue)
        {
            return GetDecryptedValue(inputValue, IV);
        }

        /// <summary>
        /// Gets the decrypted value.
        /// </summary>
        /// <param name="inputValue">The input value.</param>
        /// <param name="IV">the IV for this input</param>
        /// <returns></returns>
        public string GetDecryptedValue(string inputValue, string IV)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return null;
            }
            T provider = this.GetCryptoProvider(IV);
            inputValue = inputValue.Replace(" ", "+");

            byte[] inputEquivalent = Convert.FromBase64String(inputValue);

            // Create a new MemoryStream.
            MemoryStream msDecrypt = new MemoryStream();

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                provider.CreateDecryptor(),
                CryptoStreamMode.Write);
            csDecrypt.Write(inputEquivalent, 0, inputEquivalent.Length);
            csDecrypt.FlushFinalBlock();

            csDecrypt.Close();

            //Convert the buffer into a string and return wt.
            return new UTF8Encoding().GetString(msDecrypt.ToArray());
        }



        #endregion Decrypt

    }

}
