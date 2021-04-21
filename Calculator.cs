using UnityEngine;
using System;
using System.Linq;
using Calculator.System;

namespace Calculator
{
    public class Calculator : MonoBehaviour
    {
        public string txtBox;

        private double x,y;
        private string crrOp;

        private void NumberKey(int number)
        {
            txtBox = txtBox + number.ToString();
        }
        private void InputKey(string s)
        {
            if (txtBox.ToString().Any(x => char.IsLetter(x))) //RETURN IF HAVE ANY LETTER
            {
                ClearScreen(); //CLEAR THE SCREEN OTHERWISE
                return;
            }
            switch (s)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    crrOp = s;
                    CalculateFirstPair();
                    break;
                case "=":
                    txtBox = ShowResult().ToString();
                    break;
                case "c":
                    ClearScreen();
                    break;
            }
        }

        private void CalculateFirstPair()
        {
            x = Convert.ToDouble(txtBox);
            txtBox = "";
        }
        private double ShowResult()
        {
            y = Convert.ToDouble(txtBox);

            double result = 0.0f;

            switch (crrOp)
            {
                case "+":
                    result = Operations.Add(x, y);
                    break;
                case "-":
                    result = Operations.Subtract(x, y);
                    break;
                case "*":
                    result = Operations.Multiply(x, y);
                    break;
                case "/":
                    result = Operations.Divide(x, y);
                    break;
            }
            return result;
        }


        private void ClearScreen()
        {
            txtBox = "";
            crrOp = "";
            y = 0;
            x = 0;
        }
    }
}
