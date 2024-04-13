/*

    You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.

    Evaluate the expression. Return an integer that represents the value of the expression.

    Note that:

    The valid operators are '+', '-', '*', and '/'.
    Each operand may be an integer or another expression.
    The division between two integers always truncates toward zero.
    There will not be any division by zero.
    The input represents a valid arithmetic expression in a reverse polish notation.
    The answer and all the intermediate calculations can be represented in a 32-bit integer.



    Input: tokens = ["2","1","+","3","*"]
    Output: 9
    Explanation: ((2 + 1) * 3) = 9

    Input: tokens = ["4","13","5","/","+"]
    Output: 6
    Explanation: (4 + (13 / 5)) = 6

    Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
    Output: 22
    Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
    = ((10 * (6 / (12 * -11))) + 17) + 5
    = ((10 * (6 / -132)) + 17) + 5
    = ((10 * 0) + 17) + 5
    = (0 + 17) + 5
    = 17 + 5
    = 22

    Constraints:

    1 <= tokens.length <= 10^4
    tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].

    */

    // 1. If a value appears next in the expression, push this value on to the stack.
    // 2. If an operator appears next, pop two items from the top of the stack and push the result of the operation on to the stack.

#include <vector>
#include <stack>
#include <string>

class _0150_EvaluateReversePolishNotation {
public:
    int evalRPN(std::vector<std::string>& tokens) {
        std::stack<int> stack;

        for (int i = 0; i < tokens.size(); i++) {
            std::string token = tokens[i];

            if (token.size() > 1 || isdigit(token[0])) {
                stack.push(stoi(token));
                continue;
            }

            int num2 = stack.top();
            stack.pop();
            int num1 = stack.top();
            stack.pop();

            int result = 0;
            if (token == "+") {
                result = num1 + num2;
            }
            else if (token == "-") {
                result = num1 - num2;
            }
            else if (token == "*") {
                result = num1 * num2;
            }
            else {
                result = num1 / num2;
            }
            stack.push(result);
        }

        return stack.top();
    }
};