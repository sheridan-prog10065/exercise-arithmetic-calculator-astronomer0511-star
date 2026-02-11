using System.Diagnostics;

namespace MathCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        // Obtain the input from the user: left op, right op, and operator
        string leftOperandInput = _txtLeftOp.Text;
        double leftOperand = double.Parse(leftOperandInput); // REMINDER:  Doubles take up more memories than floats, but are more accurate.  Also parse can turn strings into values

        double rightOperand = double.Parse(_txtRightOp.Text);

        string opInput = (string)_pckOperand.SelectedItem; // The (string) converts _pckOperand.SelectedItem value into a string
        char op = opInput[0];

        // Check the chosen operator and prefrom the corresponding operation
        double result = PreformArithmeticOperation(op, leftOperand, rightOperand);

        // Display the arithmetic expression in the output control
        string expression = $"{leftOperand} {op} {rightOperand} = {result}";
        _txtMathExp.Text = expression;
    }

    private double PreformArithmeticOperation(char op, double leftOperand, double rightOperand)
    {
        //Check the type of operand (op) and preform the corresponding operation
        double result;
        switch (op)
        {
            case '+':
                result = PreformAddition(leftOperand, rightOperand);
                break;
            case '-':
                result = PreformSubtraction(leftOperand, rightOperand);
                break;
            case '*':
                result = PreformMultiplication(leftOperand, rightOperand);
                break;
            case '/':
                result = PreformDivision(leftOperand, rightOperand);
                break;
            case '%':
                result = PreformRemainder(leftOperand, rightOperand);
                break;

            default:
                Debug.Assert(false, "Unknown Arithmetic Operation, Default result returned");
                result = 0;
                break;
        }

        return result;
    }

    private double PreformRemainder(double leftOperand, double rightOperand)
    {
        double result = leftOperand % rightOperand;
        return result;
    }

    private double PreformDivision(double leftOperand, double rightOperand)
    {
        // check whether the division operation is int or real
        string divOp = (string)_pckOperand.SelectedItem;
        if (divOp.Contains("int", StringComparison.OrdinalIgnoreCase))
        {
            int leftIntOp = (int)leftOperand;
            int rightIntOp = (int)rightOperand;
            int result = leftIntOp / rightIntOp;
            return result;
        }
        else
        {
            double result = leftOperand / rightOperand;
            return result;
        }
    }

    private double PreformMultiplication(double leftOperand, double rightOperand)
    {
        double result = leftOperand * rightOperand;
        return result;
    }

    private double PreformSubtraction(double leftOperand, double rightOperand)
    {
        double result = leftOperand - rightOperand;
        return result;
    }

    private double PreformAddition(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand + rightOperand;
        return result;
    }
}