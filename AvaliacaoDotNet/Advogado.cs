using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoDotNet
{
    public class Advogado : Pessoa
    {
        public int Cna { get; set; }
        public string? Especialidade { get; set; }


        public Advogado()
        {
            Especialidade = "Sem Especialidade";
        }


        public Advogado(string nome, int cna)
        {
            this.Nome = nome;
            this.Cna = cna;
        }

        public Advogado(string nome, DateTime dataNascimento, string cpf, int cna, string especialidade)
            : base(nome, dataNascimento, cpf, idade: 0)
        {
            Cna = cna;
            Especialidade = especialidade;
            // Calcular a idade ao criar o objeto
            Idade = CalcularIdade(dataNascimento);
        }

        public static bool IsCpfUnico(string cpf, List<Advogado> advogados)
        {
            // Verifica se o CPF já existe na lista de advogados
            if (!Pessoa.IsValidCPF(cpf))
            {
                throw new ArgumentException("\n\tOps, CPF inválido!...");
            }

            // Verifica se o CPF já existe na lista de advogados
            return !advogados.Any(advogado => advogado.Cpf == cpf);
        }

        public static int ValidarEntradaCNA(string mensagem)
        {
            int valor;

            do
            {
                LimparTela();
                Console.WriteLine("\n\t========== GESTÃO DE ADVOCACIA ========== ");
                Console.Write($"\t{mensagem}: ");

                string input = Console.ReadLine()!;

                try
                {
                    // Remova espaços em branco e verifique se o comprimento é válido
                    input = input.Replace(" ", "").Trim();

                    if (input.Length != 6)
                    {
                        throw new FormatException("\n\tOps, entrada inválida! O CNA deve ter 6 caracteres.");
                    }

                    valor = Int32.Parse(input);

                    if (valor <= 0)
                    {
                        throw new OverflowException("\n\tOps, entrada inválida! O valor não pode ser menor ou igual a zero.");
                    }

                    return valor;
                }
                catch (FormatException)
                {
                    LimparTela();
                    Console.WriteLine($"\n\tOps, entrada inválida. Por favor, insira um CNA válido (6 dígitos).");
                    Pause();
                }
                catch (OverflowException ex)
                {
                    LimparTela();
                    Console.WriteLine(ex.Message);
                    Pause();
                }

            } while (true);
        }

        public static bool IsCnaUnico(int cna, List<Advogado> advogados)
        {
            // Verifica se o CNA já existe na lista de advogados
            return !advogados.Any(advogado => advogado.Cna == cna);
        }

        private static void LimparTela()
        {
            // Implemente a lógica para limpar a tela conforme necessário
        }

        private static void Pause()
        {
            // Implemente a lógica para pausar a execução conforme necessário
        }

        public override string ToString() {
            return
                $"\tNome: {this.Nome}"
                + $"\n\tCPF: {this.Cpf}"
                + $"\n\tData de Nascimento: {this.DataNascimento.ToString("dd/MM/yyyy")}"
                + $"\n\tIdade: {this.Idade}"
                + $"\n\tCNA: {this.Cna}"
                + $"\n\tEspecialidade: {this.Especialidade}";
        }
    }
}
