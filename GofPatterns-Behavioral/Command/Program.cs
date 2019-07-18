using System;
using System.Collections.Generic;

namespace Command
{
    // The Command
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    // The ConcreteCommand
    class CalculatorCommand : Command
    {
        private char @operator;
        private int operand;
        private Calculator calculator;

        // Constructor
        public CalculatorCommand(Calculator calculator,
          char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        // Gets operator
        public char Operator
        {
            set { @operator = value; }
        }

        // Get operand
        public int Operand
        {
            set { operand = value; }
        }

        // Execute new command
        public override void Execute()
        {
            calculator.Operation(@operator, operand);
        }

        // Unexecute last command
        public override void UnExecute()
        {
            calculator.Operation(Undo(@operator), operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new
                 ArgumentException("@operator");
            }
        }
    }

    // The Receiver
    class Calculator
    {
        private int curr = 0;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }
            Console.WriteLine(
              "Current value = {0,3} (following {1} {2})",
              curr, @operator, operand);
        }
    }

    // The Invoker
    class User
    {
        // Initializers
        private readonly Calculator calculator = new Calculator();
        private readonly List<Command> commands = new List<Command>();
        private int current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("Redo {0} levels ", levels);
            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count - 1)
                {
                    Command command = commands[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("Undo {0} levels ", levels);
            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    Command command = commands[--current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(
              calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            commands.Add(command);
            current++;
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Create user and let her compute
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);
        }
    }
}
