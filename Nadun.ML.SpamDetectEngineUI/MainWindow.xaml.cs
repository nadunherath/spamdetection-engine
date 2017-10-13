using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nadun.ML.SpamDetectEngine;
using Nadun.ML.SpamDetectEngine.Entities;

namespace Nadun.ML.SpamDetectEngineUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int TotalMessages { get; set; }

        public int CorrectlyPredicted { get; set; }

        public decimal CorrectPercentage { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SMSReader reader = new SMSReader();
            NaiveBayes naiveBayes = new NaiveBayes();
            var smsList = reader.Read(@"D:\Nadun.ML.SpamDetector\Nadun.ML.SpamDetectEngine\Data\evaluating.csv");
            TotalMessages = smsList.Count - 1;

            foreach (var sms in smsList)
            {
                if (naiveBayes.CheckSMS(sms.Message, 0))
                {
                    sms.PredictedType = "spam";
                }
                else
                {
                    sms.PredictedType = "ham";
                }

                if (sms.PredictedType == sms.ActualType)
                {
                    CorrectlyPredicted += 1;
                }
            }
            dataGrid.DataContext = this;
            dataGrid.ItemsSource = smsList;
            progressBar.IsIndeterminate = false;
            CorrectPercentage = Math.Round((decimal)(((decimal)CorrectlyPredicted / (decimal)TotalMessages)) * 100, 2, MidpointRounding.AwayFromZero);
            txtPercCorrect.Text = CorrectPercentage.ToString();
            txtTotalNoMsg.Text = TotalMessages.ToString();
        }

        private void btnAllCapital_Click(object sender, RoutedEventArgs e)
        {
            SMSReader reader = new SMSReader();
            NaiveBayes naiveBayes = new NaiveBayes();
            var smsList = reader.Read(@"D:\Nadun.ML.SpamDetector\Nadun.ML.SpamDetectEngine\Data\evaluating.csv");
            TotalMessages = smsList.Count - 1;

            foreach (var sms in smsList)
            {
                if (naiveBayes.CheckSMS(sms.Message, 1))
                {
                    sms.PredictedType = "spam";
                }
                else
                {
                    sms.PredictedType = "ham";
                }

                if (sms.PredictedType == sms.ActualType)
                {
                    CorrectlyPredicted += 1;
                }
            }
            dataGrid.DataContext = this;
            dataGrid.ItemsSource = smsList;
            progressBar.IsIndeterminate = false;
            CorrectPercentage = Math.Round((decimal)(((decimal)CorrectlyPredicted / (decimal)TotalMessages)) * 100, 2, MidpointRounding.AwayFromZero);
            txtPercCorrect.Text = CorrectPercentage.ToString();
            txtTotalNoMsg.Text = TotalMessages.ToString();
        }

        private void Top20Words_Click(object sender, RoutedEventArgs e)
        {
            SMSReader reader = new SMSReader();
            NaiveBayes naiveBayes = new NaiveBayes();
            var smsList = reader.Read(@"D:\Nadun.ML.SpamDetector\Nadun.ML.SpamDetector\Data\evaluating.csv");
            TotalMessages = smsList.Count - 1;

            foreach (var sms in smsList)
            {
                if (naiveBayes.CheckSMS(sms.Message, 2))
                {
                    sms.PredictedType = "spam";
                }
                else
                {
                    sms.PredictedType = "ham";
                }

                if (sms.PredictedType == sms.ActualType)
                {
                    CorrectlyPredicted += 1;
                }
            }
            dataGrid.DataContext = this;
            dataGrid.ItemsSource = smsList;
            progressBar.IsIndeterminate = false;
            CorrectPercentage = Math.Round((decimal)(((decimal)CorrectlyPredicted / (decimal)TotalMessages)) * 100, 2, MidpointRounding.AwayFromZero);
            txtPercCorrect.Text = CorrectPercentage.ToString();
            txtTotalNoMsg.Text = TotalMessages.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.DataContext = this;
            dataGrid.ItemsSource = new List<SMS>();
            dataGrid.Items.Refresh();
            txtPercCorrect.Text = "";
            txtTotalNoMsg.Text = "";
            CorrectlyPredicted = 0;
            CorrectPercentage = 0;
            TotalMessages = 0;
        }
    }
}
