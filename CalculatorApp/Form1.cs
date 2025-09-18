using System;
using System.Globalization;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private readonly ICalculator _calc;

        public Form1()
        {
            InitializeComponent();          // keep this
            _calc = new Math();             // your ICalculator implementation

            // Wire button clicks (works even if you didn’t double-click buttons in the Designer)
            btnAdd.Click += btnAdd_Click;
            btnSubtract.Click += btnSubtract_Click;
            btnMultiply.Click += btnMultiply_Click;
            btnDivide.Click += btnDivide_Click;

            // Optional niceties:
            this.AcceptButton = btnAdd;     // Enter triggers Add
        }

        private bool TryReadInputs(out decimal a, out decimal b)
        {
            var style = NumberStyles.Number;
            var culture = CultureInfo.CurrentCulture;

            bool okA = decimal.TryParse(txtA.Text, style, culture, out a);
            bool okB = decimal.TryParse(txtB.Text, style, culture, out b);

            if (!okA || !okB)
            {
                MessageBox.Show("Please enter valid numbers in both inputs.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ShowResult(decimal value)
        {
            lblResult.Text = $"Result: {value}";
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!TryReadInputs(out var a, out var b)) return;
            ShowResult(_calc.Add(a, b));
        }

        private void btnSubtract_Click(object? sender, EventArgs e)
        {
            if (!TryReadInputs(out var a, out var b)) return;
            ShowResult(_calc.Subtract(a, b));
        }

        private void btnMultiply_Click(object? sender, EventArgs e)
        {
            if (!TryReadInputs(out var a, out var b)) return;
            ShowResult(_calc.Multiply(a, b));
        }

        private void btnDivide_Click(object? sender, EventArgs e)
        {
            if (!TryReadInputs(out var a, out var b)) return;
            try
            {
                ShowResult(_calc.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
