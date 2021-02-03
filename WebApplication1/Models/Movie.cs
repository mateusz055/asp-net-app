using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Windows.Forms;

namespace WebApplication1.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }

        public static async void GetMovieValue() 
        {
            HttpClient client= new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                

                MessageBox.Show(responseBody);
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("\nException Caught!");
                MessageBox.Show("Message :{0} ", e.Message);
            }

        }
    }
}