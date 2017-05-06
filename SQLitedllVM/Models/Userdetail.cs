using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace SQLitedllVM.Models
{
    public class Userdetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Usernumber { get; set; }
        [StringLength(12, MinimumLength = 2)]
        public string Username { get; set; }
        [StringLength(12)]
        public string BusinessName { get; set; }
        [StringLength(16)]
        public string ContactNumber { get; set; }
        public virtual ICollection<Point> Data { get; set; } = new HashSet<Point>();
        //Setting up backing fields here
        private string _validatedClientUrl;//Backing Fields(EF6Core)
        public string Url
        {
            get { return _validatedClientUrl; }
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _validatedClientUrl = url;
        }
    }


}
