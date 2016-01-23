using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using System.Web.Script.Serialization;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace SocialWall
{
    public partial class Wall : Form
    {
        string clientToken = string.Empty;
        public Wall(string token)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(100, 0, 0);
            this.TransparencyKey = Color.FromArgb(100, 0, 0);
            clientToken = token;
            profilePic.BringToFront();
            lblName.BringToFront();                       
        }

        private void Wall_Load(object sender, EventArgs e)
        {
            if (clientToken != null)
                GetUserDetails();

        }

        private void GetUserDetails()
        {
            FacebookClient fb = null;
            object data = null;
            DVO.UserDvo user = null;
            try
            {
                fb = new FacebookClient(clientToken);
                data = fb.Get("/me?fields=devices,first_name,gender,installed,last_name,link,locale,location");
                user = new DVO.UserDvo();
                user = new JavaScriptSerializer().Deserialize<DVO.UserDvo>(data.ToString());
                lblName.Text = "Welcome " + user.first_name;
                lblLocation.Text = user.location.name;
                profilePic.Image = DownloadImage("https://graph.facebook.com/v2.5/" + user.id + "/picture?height=100&width=100&type=album&access_token=" + clientToken);                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fb = null;
                data = null;
                user = null;
            }

        }

       

        private static Image DownloadImage(string url)
        {
            WebClient wc = null;
            Image img = null;
            MemoryStream ms = null;
            try
            {
                wc= new WebClient();
                byte[] bytes = wc.DownloadData(url);
                ms = new MemoryStream(bytes);
                img = System.Drawing.Image.FromStream(ms);
                return img;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                wc.Dispose();
                ms.Dispose();
            }
           
        }
      

    }
}
