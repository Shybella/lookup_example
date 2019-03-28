using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeSearch;

namespace testlookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Keywords to make sure we keep in scope and not have a trump russia video show up
            // there is probably better ways to do this but this is easy and works incredibility well         
            string keywords = "Modded Minecraft 1.12 Tutorial English ";

            //processed query string
            string querystring = keywords + textBox1.Text;
            
            // Number of result pages
            int querypages = 1;

            // Offset value for querypages
            int querypagesOffset = 1;

            //using Youtubesearch library
            var items = new VideoSearch();

            int i = 0;

            // Was an experiment to catch people wanting to figure out how to chunkload
            // example of sometype of keyword trigger (not needed)
            if (querystring.Contains("chunk load") || querystring.Contains("chunkload")) {
                textBox2.Text = "Run '/kit scl' for chunk loaders. You have access to two chunkloaders. Use F3+g to show chunk borders.";
                return;
            }
            
                //loop through to pull the 3 top videos
                foreach (var item in items.SearchQuery(querystring, querypages))
            {   
                //when the search results return a low confidence, youtube replies with the 3 same low confidence video results.
                //for some reason these low confidence results likes to tell us how to make a server and this is due to the predefined key words taking prioity.
                //if keywords change, the default results will change
                
                if (item.Title.Contains("How to Make a Modded Minecraft Server"))
                {
                    textBox2.Text = "Invalid results! Make sure to use mod name or item name, needs to be descriptive!";
                    break;
                }

                i++;
                textBox2.AppendText("Title: " + item.Title + Environment.NewLine +
                                    "URL: " + item.Url + Environment.NewLine);
          
                
                if(i==3) break;
            }
        }
    }
}
