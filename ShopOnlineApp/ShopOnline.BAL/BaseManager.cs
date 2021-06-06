using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace ShopOnline.BAL
{
    public class BaseManager
    {
        public string GetUrl { get; set; }
        
        public async Task<dynamic> HttpGet()
        {
            if (string.IsNullOrEmpty(GetUrl))
                return null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var resp = await client.GetAsync(GetUrl);
                    if (resp.IsSuccessStatusCode)
                        return resp.Content.ReadAsStringAsync();
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
