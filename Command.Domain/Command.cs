using System;
using System.Collections.Generic;

namespace Command.Domain
{
    internal abstract class Commander
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    internal class CalculatorCommand : Commander
    {
        private char _operator;
        private int _operand;

        private readonly Calculator calculador;

        public CalculatorCommand(Calculator calculador, char @operator, int operand)
        {
            _operator = @operator;
            _operand = operand;
            this.calculador = calculador;
        }

        public char Operator
        {
            set { _operator = value; }
        }

        public int Operand
        {
            set { _operand = value; }
        }

        public override void Execute()
        {
            calculador.Operation(_operator, _operand);
        }


        public override void UnExecute()
        {
            calculador.Operation(Undo(_operator), _operand);
        }

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("@operator");
            }
        }
    }

    internal class Calculator
    {
        private int curr;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }

            Console.WriteLine($"Valor atual = {curr,3} (dado {@operator} {operand}");
        }
    }

    public class User
    {
        private readonly Calculator calculator = new Calculator();
        private readonly IList<Commander> commands = new List<Commander>();
        private int current;

        public void Compute(char @operator, int operand)
        {
            var command = new CalculatorCommand(calculator, @operator, operand);

            command.Execute();

            commands.Add(command);
            current++;
        }

        public void Retry(int levels)
        {
            Console.WriteLine($"---Retornado {levels} niveis");
            for(var i = 0; i < levels; i++)
            {
                if (current >= commands.Count - 1) continue;
                var command = commands[current++];
                command.Execute();
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine($"---Desfazendo {levels} niveis");
            for (var i = 0; i < levels; i++)
            {
                if (current <= 0) continue;
                var command = commands[ --current];
                command.UnExecute();
            }
        }
    }

    public class Command
    {
        public static void Execucao()
        {
            var user = new User();
            user.Compute('+', 100);
            user.Compute('+', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            user.Undo(4);
            user.Retry(3);
        }
    }
}
