using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;//Cache a button and set it as the button pressed.
            string pressed = button.Text;//Grab the text on the button pressed.

            if (this.CalculatorDisplay.Text == "0" || currentState < 0)
            {
                this.CalculatorDisplay.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.CalculatorDisplay.Text += pressed;

            double number;

            if (double.TryParse(this.CalculatorDisplay.Text, out number))
            {
                this.CalculatorDisplay.Text = number.ToString("N0"); //Format the number to not include decimal places.

                if (currentState == 1)
                {
                    //If this number is to the left of the operator sign, make it the first number
                    firstNumber = number;
                }else
                {
                    //If this number is on the right of the operater sign, make it the second number
                    secondNumber = number;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.CalculatorDisplay.Text = "0";
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.CalculatorDisplay.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }
    }
}
