using System.Diagnostics;

namespace Dzielenie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dividend = double.Parse(textBox1.Text);
                double divisor = double.Parse(textBox2.Text);

                if (divisor == 0)
                {
                    throw new DivideByZeroException("Nie mo�na podzieli� przez zero");
                }

                double result = dividend / divisor;
                textBox3.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Niepoprawne znaki, prosz� wprowadzi� cyfry.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
                MessageBox.Show(ex.Message, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // wpis do dziennika
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                MessageBox.Show("Wyst�pi� nieoczekiwany b��d. Sprawd� dziennik zdarze� systemu Windows.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}