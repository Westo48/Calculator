using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Equation
    {
        public Equation()
        {
            nums = new List<decimal>();
            ops = new List<char>();
        }

        // * nums and ops list methods
        public string NumClick(string clickedNum)
        {

            isSolvedNum = false;
            if (currentNum == "0")
            {
                currentNum = clickedNum;
                return currentNum;
            }
            else
            {
                currentNum += clickedNum;
                return currentNum;
            }
        }
        public string DecClick()
        {
            CheckSolvedNum();
            // checks if the currentNum is blank, 0, only negative, or is already a decimal
            if (currentNum == "" || currentNum == "0")
            {
                currentNum = "0.";
            }
            else if (currentNum == "-")
            {
                currentNum = "-0.";
            }
            else if (!currentNum.Contains("."))
            {
                currentNum += ".";
            }
            return currentNum;
        }

        public void OpClick(char clickedOp)
        {
            // logic that works if Solve has just run and user clicks an operator to operate on the answer directly after
            //cannot use CheckSolvedNum here due to different logic
            if (isSolvedNum)
            {
                nums.Add(answerNum);
                ops.Add(clickedOp);
                isSolvedNum = false;
            }
            else
            {
                // checks if currentNum has a value or not, then checks to see if ops has a value or not
                if (currentNum == "")
                {
                    if (ops.Count == 0)
                    {
                        ops.Add(clickedOp);
                        currentNum = "0";
                        AddNewNum();
                    }
                    else
                    {
                        ops.RemoveAt(ops.Count - 1);
                        ops.Add(clickedOp);
                    }
                }
                else if (currentNum == "-")
                {
                    currentNum = "0";
                    ops.Add(clickedOp);
                    AddNewNum();
                }
                else
                {
                    lastNum = Convert.ToDecimal(currentNum);
                    ops.Add(clickedOp);
                    AddNewNum();
                }
                lastOp = clickedOp;
            }
        }
        public string BackClick()
        {
            CheckSolvedNum();
            if (currentNum == "")
            {
                return "0";
            }
            // this includes if currentNum="-"
            else if (currentNum.Length == 1)
            {
                currentNum = currentNum.Remove(currentNum.Length - 1, 1);
                return "0";
            }
            else
            {
                currentNum = currentNum.Remove(currentNum.Length - 1, 1);
                return currentNum;
            }

        }
        public string ClearClick()
        {
            isSolvedNum = false;
            undefined = false;
            currentNum = "";
            return "0";
        }
        public string ClearAllClick()
        {
            isSolvedNum = false;
            undefined = false;
            currentNum = "";
            ops.Clear();
            nums.Clear();
            return "0";
        }
        public string PosNegClick()
        {
            CheckSolvedNum();
            if (currentNum == "")
            {
                currentNum = "-";
            }
            // checking for negativity and inverting said negativity
            else if (currentNum.StartsWith("-"))
            {
                currentNum = currentNum.Remove(0, 1);
            }
            else
            {
                currentNum = $"-{currentNum}";
            }
            return currentNum;
        }

        // * list modification and check methods
        public void AddNewNum()
        {
            nums.Add(Convert.ToDecimal(currentNum));
            currentNum = "";
        }
        //checks if isSolvedNum value is true
        public void CheckSolvedNum()
        {
            if (isSolvedNum)
            {
                isSolvedNum = false;
                currentNum = Convert.ToString(answerNum);
            }
        }

        // * math operations
        public string Solve()
        {
            if (isSolvedNum)
            {
                nums.Add(answerNum);
                nums.Add(lastNum);
                ops.Add(lastOp);
                SolveExponent();
                SolveMultiply();
                SolveDivide();
                if (undefined)
                {
                    undefined = false;
                    isSolvedNum = false;
                    nums.Clear();
                    ops.Clear();
                    return "Error";
                }
                SolveAddSub();
                answerNum = nums[0];
                nums.Clear();
                ops.Clear();
                return Convert.ToString(answerNum);
            }
            // checks and handles if a number has been clicked, but an operator has not been clicked
            if (ops.Count == 0)
            {
                return currentNum;
            }
            // checks and handles if = operator is clicked after an operator and a number has not been clicked
            if (currentNum == "")
            {
                ops.RemoveAt(ops.Count - 1);
            }
            else
            {
                lastNum = Convert.ToDecimal(currentNum);
                AddNewNum();
            }
            SolveExponent();
            SolveMultiply();
            SolveDivide();
            // checks and handles if user tries to divide by 0
            if (undefined)
            {
                // resets values and undefined value and returns the error message
                undefined = false;
                nums.Clear();
                ops.Clear();
                return "Error";
            }
            SolveAddSub();
            isSolvedNum = true;
            answerNum = nums[0];
            currentNum = "";
            nums.Clear();
            ops.Clear();
            return Convert.ToString(answerNum);
        }
        public void SolveExponent()
        {
            while (ops.Contains('^'))
            {
                tempIndex = ops.IndexOf('^');

                tempNum = (decimal)Math.Pow((double)nums[tempIndex], (double)nums[tempIndex + 1]);

                nums.RemoveAt(tempIndex);
                nums.RemoveAt(tempIndex);
                nums.Insert(tempIndex, tempNum);

                ops.RemoveAt(tempIndex);
            }
        }
        public void SolveMultiply()
        {
            while (ops.Contains('*'))
            {
                tempIndex = ops.IndexOf('*');
                tempNum = nums[tempIndex] * nums[tempIndex + 1];

                nums.RemoveAt(tempIndex);
                nums.RemoveAt(tempIndex);
                nums.Insert(tempIndex, tempNum);

                ops.RemoveAt(tempIndex);
            }
        }
        public void SolveDivide()
        {
            while (ops.Contains('/'))
            {
                tempIndex = ops.IndexOf('/');
                // error exception for undefined answer due to dividing by 0
                if (nums[tempIndex + 1] == 0)
                {
                    undefined = true;
                    break;
                }
                tempNum = nums[tempIndex] / nums[tempIndex + 1];

                nums.RemoveAt(tempIndex);
                nums.RemoveAt(tempIndex);
                nums.Insert(tempIndex, tempNum);

                ops.RemoveAt(tempIndex);
            }
        }
        public void SolveAddSub()
        {
            while (ops.Contains('+') || ops.Contains('-'))
            {
                if (ops[0] == '+')
                {
                    tempNum = nums[0] + nums[1];
                }
                else if (ops[0] == '-')
                {
                    tempNum = nums[0] - nums[1];
                }
                else
                {
                    System.Console.WriteLine("Invalid Operator");
                }

                nums.RemoveAt(0);
                nums.RemoveAt(0);
                nums.Insert(0, tempNum);

                ops.RemoveAt(0);
            }
        }


        // * variables used in Equation class
        List<decimal> nums;
        List<char> ops;
        string currentNum = "";
        decimal tempNum;
        int tempIndex;
        decimal answerNum;
        char lastOp;
        decimal lastNum;
        bool isSolvedNum = false;
        bool undefined = false;
    }
}
