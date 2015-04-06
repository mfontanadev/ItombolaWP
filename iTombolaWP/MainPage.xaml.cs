using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;

namespace iTombola
{
    public partial class MainPage : PhoneApplicationPage
    {
        Random randomGen = new Random(DateTime.Now.Second);

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnApostar_Click(object sender, RoutedEventArgs e)
        {
            // Reset if no bet.
            if (edApuesta.Text == "")
            {
                lblGanadorNumero.Text = "--";
                lblGanadorResultado.Text = "";
                return;
            }

            //WebClient web = new WebClient();
            //web.OpenReadCompleted += new OpenReadCompletedEventHandler(RequestComplete);
            //web.OpenReadAsync(new Uri("http://itombola.azurewebsites.net/WebMobile/rest/authenticate/bet"));
                        
            int resultNumber = randomGen.Next(100);
            ShowResult(resultNumber);
        }

        void RequestComplete(object sender, OpenReadCompletedEventArgs e)
        {
            string response = "";

            using (var reader = new StreamReader(e.Result))
            {
                response = reader.ReadToEnd();
                ShowResult(int.Parse(response.ToString()));
            }
        }

        void ShowResult(int value)
        {
            int resultNumber = randomGen.Next(100);

            // Show winner number
            lblGanadorNumero.Text = resultNumber.ToString();

            // Show winner message
            if (int.Parse(edApuesta.Text) == resultNumber)
                lblGanadorResultado.Text = "Ganaste";
            else
                lblGanadorResultado.Text = "Perdiste";
        }

    }
}