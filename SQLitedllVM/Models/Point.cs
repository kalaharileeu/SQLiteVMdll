using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace SQLitedllVM.Models
{
    //[Table("UserPoints")]
    public class Point
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PointId { get; set; }
        public string Invoicenumber { get; set; }
        [Required]
        public string Pointname { get; set; }
        public bool Signedoff { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        //public DateTime Date { get; set; }
        //The whole foreign key and EFCore/SQlite is a bit messy
        //Doing it manually
        public int UserIDFK { get; set; }
        ////annotation to indicate which properties serve as the 
        ////backing fields for the two navigation properties
        private string _validatedJobUrl;//Backing Fields(EF6Core)
        public string Url
        {
            get { return _validatedJobUrl; }
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _validatedJobUrl = url;
        }

    }
}
