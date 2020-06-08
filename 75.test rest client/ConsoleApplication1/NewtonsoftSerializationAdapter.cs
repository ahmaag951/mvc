using Newtonsoft.Json;
using RestClientDotNet;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RestClientDotNet
{
    public class NewtonsoftSerializationAdapter : ISerializationAdapter
    {
        public NewtonsoftSerializationAdapter ()
	{
            Encoding = Encoding.UTF8;
	}
        #region Public Properties
        public Encoding Encoding { get; set; }
        #endregion

        #region Implementation
        public async Task<T> DeserializeAsync<T>(byte[] data)
        {
            var markup = Encoding.GetString(data);

            object markupAsObject = markup;

            if (typeof(T) == typeof(string))
            {
                return (T)markupAsObject;
            }

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(markup));
        }

        public async Task<object> DeserializeAsync(byte[] data, Type errorType)
        {
            return await Task.Run(() => JsonConvert.DeserializeObject(Encoding.GetString(data)));
        }

        public async Task<byte[]> SerializeAsync<T>(T value)
        {
            var json = await Task.Run(() => JsonConvert.SerializeObject(value));
            var binary = await Task.Run(() => Encoding.GetBytes(json));
            return binary;
        }
        #endregion
    }
}
