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

namespace DOACCalculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double height = double.Parse(bodyHeightField.Text);
            double weight = double.Parse(bodyWeightField.Text);
            double age = double.Parse(ageField.Text);
            double crea = double.Parse(sCrField.Text);
            double egfr = 194 * Math.Pow(age, -0.287) * Math.Pow(crea, -1.094);
            double bsa = 0.007184 * Math.Pow(weight, 0.425) * Math.Pow(height, 0.725);
            if(femaleRadioButton.IsChecked==true)
                egfr *= 0.739;
            double gfr = egfr * bsa;
            CcrField.Content = $"{gfr:0.0}";
            BSAField.Content = $"{bsa:0.0}";
            eGFRField.Content = $"{egfr:0.0}";

            string stage = "";
            if (egfr >= 90)
                stage = "正常";
            else if (egfr >= 60)
                stage = "軽度腎障害";
            else if (egfr >= 30)
                stage = "中等度腎障害";
            else if (egfr >= 15)
                stage = "高度腎障害";
            else
                stage = "末期腎不全";
            renalStageField.Content = stage;

            // プラザキサ
            if (gfr >= 50 && age < 70)
                stage = "75mg 4C / 2xMA";
            else if (gfr >= 30 || age >= 70)
                stage = "110mg 2C / 2xMA";
            else
                stage = "非推奨";

            prazaxaField.Content = stage;

            // イグザレルト
            if (gfr >= 50) stage = "15mg 1T / 1xM";
            else if (gfr >= 30) stage = "10mg 1T / 1xM";
            else if (gfr >= 15) stage = "10mg 1T / 1xM 慎重投与";
            else stage = "非推奨";

            xareltoField.Content = stage;

            // エリキュース
            int check = 0;
            if (age >= 80) check++;
            if (weight <= 60) check++;
            if (crea >= 1.5) check++;

            if (gfr < 15)
                stage = "非推奨";
            else if (check >= 2)
                stage = "2.5mg 2T / 2xMA";
            else
                stage = "5mg 2T / 2xMA";
            eliquisField.Content = stage;

            // リクシアナ
            if (weight >= 60 && gfr >= 50)
                stage = "60mg 1T / 1xM";
            else if (gfr >= 30)
                stage = "30mg 1T / 1xM";
            else if (gfr >= 15)
                stage = "30mg 1T / 1xM 慎重投与";
            else
                stage = "非推奨";
            lixianaField.Content = stage;

        }
    }
}
