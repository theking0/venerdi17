using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venerdi17
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            calcDate();
        }

        private void calcDate()
        {
            listBox1.Items.Clear();

            foreach (DateTime day in EachDay(dtStart.Value, dtEnd.Value))
            {
                if (day.Day == 17 && day.DayOfWeek == DayOfWeek.Friday)
                {
                    string str = "Venerdi'  " + day.Date.ToString();
                    str = str.Remove(str.Length - 8);
                    listBox1.Items.Add(str);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Today;
            dtEnd.Value = dtStart.Value.AddYears(1);

            calcDate();
        }
    }
}
