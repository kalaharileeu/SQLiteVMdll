using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace SQLitedllVM.Models
{
    public class Point
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JodId { get; set; }
        public string Invoicenumber { get; set; }
        [Required]
        public string Jobname { get; set; }
        public bool Signedoff { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        ////annotation to indicate which properties serve as the 
        ////backing fields for the two navigation properties
        [ForeignKey("Usernumber")]
        public virtual Userdetail Userdetail { get; set; }
        //Setting up backing fields here
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
