using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlYourWay;

namespace WpfExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cywCloudInterface_DataReceived(object sender, byte[] data, string dataType, int fromSessionID)
        {
            string text = CywCloudInterface.ConvertByteArrayToString(data)
                + " Data type: " + dataType + " SID: " + fromSessionID.ToString() + "\n";
            textboxRecData.Text += text;
        }

        private void buttonClearRecData_Click(object sender, RoutedEventArgs e)
        {
            textboxRecData.Text = "";
        }

        private void buttonSendData_Click(object sender, RoutedEventArgs e)
        {
            CywDataToSend dataToSend = new CywDataToSend();
            dataToSend.dataForSending = CywCloudInterface.ConvertStringToByteArray(textboxSendData.Text);
            cywCloudInterface.SendData(dataToSend);
        }
    }
}
