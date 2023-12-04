namespace AvaliacaoDotNet
{
    public class ListaCliente
    {
        public List<Cliente> clientes { get; set; }

        public ListaCliente()
        {
            clientes = new List<Cliente>();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public void Cadastrar()
        {
            Console.Write("\n\tDigite o nome do cliente: ");
            string nome = Console.ReadLine()??"";
            nome = Cliente.ConvertePrimeiraLetraParaMaiuscula(nome);

            string cpf;
            do
            {
                App.LimparTela();
                Console.Write("\n\tDigite o CPF do cliente: ");
                cpf = Console.ReadLine()!;

                if (!Cliente.IsValidCPF(cpf) || !Cliente.IsCpfUnico(cpf, clientes))
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tOps, CPF inválido ou já existe no cadastro. Por favor, digite um CPF válido.");
                    App.Pause();
                }

            } while (!Pessoa.IsValidCPF(cpf) || !Cliente.IsCpfUnico(cpf, clientes));

            DateTime dataNascimento = Cliente.ObterDataDeNascimento();

            string estadoCivil;
            do
            {
                App.LimparTela();
                Console.Write("\n\tDigite o estado civil do cliente: ");
                estadoCivil = Console.ReadLine()!;
                estadoCivil = Cliente.ConvertePrimeiraLetraParaMaiuscula(estadoCivil);

                if (!Cliente.estadoCivil(estadoCivil))
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tOps, estado civil inválido. Por favor, digite um estado civil válido.");
                    App.Pause();
                }

            } while (!Cliente.estadoCivil(estadoCivil));

            Console.Write("\n\tDigite a profissão do cliente: ");
            string profissão = Console.ReadLine()!;
            profissão = Cliente.ConvertePrimeiraLetraParaMaiuscula(profissão);

            AdicionarCliente(new Cliente(nome, cpf, dataNascimento, estadoCivil, profissão));

            App.LimparTela();
            ExibirDados(cpf);
            Console.WriteLine("\n\tcliente cadastrado com sucesso!");
            App.Pause();

        }

        public void Listar()
        {
            Console.WriteLine("\n\t=== Lista de clientes ===");
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.ToString());            
                Console.WriteLine("\t===========================");
            }
        }

        public void Editar()
        {
            Console.WriteLine("\n\t=== Editar cliente ===");
            Console.Write("\n\tDigite o CPF do cliente que deseja editar: ");
            string cpf = Console.ReadLine()!;

            if (clientes.Exists(cliente => cliente.Cpf == cpf))
            {
                ExibirDados(cpf);
                App.Pause();
                App.LimparTela();

                Console.Write("\n\tDigite o nome do cliente: ");
                string nome = Console.ReadLine()!;
                nome = Cliente.ConvertePrimeiraLetraParaMaiuscula(nome);

                DateTime dataNascimento = Cliente.ObterDataDeNascimento();

                string estadoCivil;
                do
                {
                    App.LimparTela();
                    Console.Write("\n\tDigite o estado civil do cliente: ");
                    estadoCivil = Console.ReadLine()!;

                    if (!Cliente.estadoCivil(estadoCivil))
                    {
                        Console.WriteLine("\n\tOps, estado civil inválido. Por favor, digite um estado civil válido.");
                        App.Pause();
                    }

                } while (!Cliente.estadoCivil(estadoCivil));

                Console.Write("\n\tDigite a profissão do cliente: ");
                string profissão = Console.ReadLine()!;

                clientes[clientes.FindIndex(cliente => cliente.Cpf == cpf)] = new Cliente(nome, cpf, dataNascimento, estadoCivil, profissão);

                App.LimparTela();
                ExibirDados(cpf);
                Console.WriteLine("\n\tcliente editado com sucesso!");
                App.Pause();
            }
            else
            {
                Console.WriteLine("\n\tcliente não encontrado.");
                App.Pause();
            }
        }

        public void Excluir()
        {
            Console.WriteLine("\n\t=== Excluir cliente ===");
            Console.Write("\n\tDigite o CPF do cliente que deseja excluir: ");
            string cpf = Console.ReadLine()!;

            if (clientes.Exists(cliente => cliente.Cpf == cpf))
            {
                ExibirDados(cpf);
                clientes.RemoveAt(clientes.FindIndex(cliente => cliente.Cpf == cpf));
                Console.WriteLine("\n\tcliente excluído com sucesso!");
                App.Pause();
            }
            else
            {
                Console.WriteLine("\n\tcliente não encontrado.");
                App.Pause();
            }
        }

        public void ExibirDados(string cpf)
        {
            Cliente cliente = clientes[clientes.FindIndex(cliente => cliente.Cpf == cpf)];
            Console.WriteLine("\n\t=== Dados do cliente ===");
            Console.WriteLine(cliente.ToString());
            Console.Write("\t==========================");

        }

        public void Pesquisar()
        {

            Console.WriteLine("\n\t=== Pesquisar cliente ===");
            Console.Write("\n\tDigite o CPF do cliente que deseja pesquisar: ");
            string cpf = Console.ReadLine()!;

            if (clientes.Exists(cliente => cliente.Cpf == cpf))
            {
                ExibirDados(cpf);
                App.Pause();
            }
            else
            {
                Console.WriteLine("\n\tcliente não encontrado.");
                App.Pause();
            }
        }
    }
}