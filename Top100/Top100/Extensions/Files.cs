using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Extensions
{
    public static class Files
    {

        private static readonly Encoding Encoding = Encoding.UTF8;


        #region I/O String
        
        public static async Task<string> ReadString(string fileName)
        {

            byte[] bytes = await ReadBytes(fileName);


            return Encoding.GetString(bytes);
        }


        public static async Task WriteString(string fileName, string text)
        {

            byte[] bytes = Encoding.GetBytes(text);


            await WriteBytes(fileName, bytes);
        }

        #endregion


        #region I/O Bytes

        private static async Task<byte[]> ReadBytes(string fileName)
        {

            byte[] bytes;


            using (FileStream stream = new(fileName, FileMode.Open,

                FileAccess.Read, FileShare.Read))
            {

                bytes = new byte[stream.Length];


                await stream.ReadAsync(bytes);
            }


            return bytes;
        }


        private static async Task WriteBytes(string fileName, byte[] bytes)
        {

            using (FileStream stream = new FileStream(fileName, FileMode.Create,
                
                FileAccess.Write, FileShare.None))
            {

                await stream.WriteAsync(bytes);
            }
        }


        #endregion
    }
}
