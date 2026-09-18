using System.Net;

static void ExibeMenu()
{

    Console.Clear();
    Console.WriteLine("Abaixo escolha opção desejada");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Listar todos equipamentos");
    Console.WriteLine("3 - Pesquisar por código");
    Console.WriteLine("4 - Filtrar por tipo");
    Console.WriteLine("5 - Filtrar por localização");
    Console.WriteLine("6 - Filtrar por status");
    Console.WriteLine("7 - Alterar status");
    Console.WriteLine("8 - Registrar manutenção");
    Console.WriteLine("9 - Listar equiamentos sem manutenção recente");
    Console.WriteLine("10 - Exibir resumo do inventário");
    Console.WriteLine("11 - Encerrar o programa");    
}

static bool ValidaIP(string ip)
{
    if (IPAddress.TryParse(ip, out IPAddress? ipValido))
    {
        return true;
    }
    else
    {
        return false;
    }
}


static int ConverteParaInteiro (string? op)
{
    if (int.TryParse(op, out int opConver))
    {
        return opConver;
    }
    return 0;
}

static void CadastrarEquipamento()
{
    string? nome = string.Empty;        
    string? fabricante = string.Empty;  
    string? modelo = string.Empty; 
    IPAddress? ip;
    string? localização = string.Empty;
    string? Observacao = string.Empty;
    List<Equipamento> novoEquipamento; 
    string? tipoEscolhido;
    Tipos tipo;
    //List<object> equipamentoCriado;

    try
    {  
        
        while (nome == null || nome == "")
        {
            Console.Clear();
            Console.Write(" Digite o nome do equipamento: ");
            nome = Console.ReadLine();
        }

        while (true)
        {
            Console.Clear();
            var cont = 0;
            foreach (Tipos tip in Enum.GetValues(typeof(Tipos)))
            {
                Console.WriteLine(cont + " - " + tip);
                cont += 1;
            }
            //cont = 0;
            Console.Write("Opção: ");
            tipoEscolhido = Console.ReadLine()!;

            switch (tipoEscolhido)
            {
                case "0":
                    tipo = Tipos.Roteador;
                    break;
                case "1":
                    tipo = Tipos.Switch;
                    break;
                case "2":
                    tipo = Tipos.ONU;
                    break;
                case "3":
                    tipo = Tipos.Servidor;
                    break;
                case "4":
                    tipo = Tipos.Firewall;
                    break;
                case "5":
                    tipo = Tipos.AP;
                    break;
                case "6":
                    tipo = Tipos.Outro;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    continue;
            }
            break;

        }

        while (fabricante == "" ||fabricante == null)
        {
            Console.Clear();
            Console.Write(" Digite o fabricante do equipamento: ");
            fabricante = Console.ReadLine();
        }

        while (modelo == "" || modelo == null)
        {
            Console.Clear();
            Console.Write(" Digite o modelo do equipamento: ");
            modelo = Console.ReadLine();
        }

        while (true)
        {
            Console.Clear();
            Console.Write(" Digite o IP do equipamento: ");

            if (IPAddress.TryParse(Console.ReadLine(), out ip))
            {
                break;
            }
            else
            {
                continue;
            }
        }

        while (localização == "" || localização == null)
        {
            Console.Clear();
            Console.Write(" Digite a localização do equipamento: ");
            localização = Console.ReadLine();
        }

        Console.Clear();
        Console.Write(" Há alguma observação?: ");
        Observacao = Console.ReadLine();
        
        novoEquipamento =
        [   new Equipamento{
            NomeDescricao = nome,
            Tipo = tipo,
            Fabricante = fabricante,
            Modelo = modelo,
            IP = ip.ToString(),
            Localizacao = localização,
            DataInstalacao = DateTime.Now,
            Statu = Status.Ativo,
            DataUltimaManutencao = null,
            Observacao = Observacao}
        ];
        
        

        using var db = new MeuDbContext();

        db.equipamentos.Add(novoEquipamento[0]);

        db.SaveChanges();


        Console.WriteLine("Equipamento cadastrado com sucesso!");
        Thread.Sleep(2000);

    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro: " + ex);
    }

}

static void ListarEquipamentos()
{
    using var db = new MeuDbContext();
    var equipamentos = db.equipamentos.ToList();


    Console.Clear();
    Console.WriteLine("##############################################################");

    foreach (var equipamento in equipamentos)
    {
        Console.WriteLine($"Código: {equipamento.Codigo}\n Nome: {equipamento.NomeDescricao}\n Tipo: {equipamento.Tipo}\n Fabricante: {equipamento.Fabricante}\n Modelo: {equipamento.Modelo}\n IP: {equipamento.IP}\n Localização: {equipamento.Localizacao}\n Data de Instalação: {equipamento.DataInstalacao}\n Status: {equipamento.Statu}\n Data da Última Manutenção: {(equipamento.DataUltimaManutencao.HasValue ? equipamento.DataUltimaManutencao.Value.ToString("dd/MM/yyyy") : "Sem manutenção registrada")}\n Observação: {equipamento.Observacao}");
        Console.WriteLine("##############################################################");
    }

    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

static List<Equipamento> FiltrarPorTipo(Tipos tipo)
{
    using var db = new MeuDbContext();
    var equipamentos = db.equipamentos.Where(e => e.Tipo == tipo).ToList();
    return equipamentos;
}

static Equipamento? PesquisarPorCodigo(int codigo)
{
    using var db = new MeuDbContext();
    var equipamento = db.equipamentos.FirstOrDefault(e => e.Codigo == codigo);
    return equipamento;
}

static List<Equipamento> FiltrarPorLocalizacao(string localizacao)
{
    using var db = new MeuDbContext();
    var equipamentos = db.equipamentos.Where(e => e.Localizacao == localizacao).ToList();
    return equipamentos;
}

try
    {
        int opcao;

        while ( true )
        {
            ExibeMenu();
            Console.Write("Opção: ");
            opcao = ConverteParaInteiro(Console.ReadLine());
            if (opcao >= 1 & opcao <= 10)
            {
                switch (opcao)
                {
                    case 1:
                    CadastrarEquipamento();
                        break;
                    case 2:
                        ListarEquipamentos();
                        break;
                    case 3:
                        Console.Write("Digite o código do equipamento que deseja pesquisar: ");
                        int codigo = ConverteParaInteiro(Console.ReadLine());
                        var equipamento = PesquisarPorCodigo(codigo);
                        if (equipamento != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Código: {equipamento.Codigo}\n Nome: {equipamento.NomeDescricao}\n Tipo: {equipamento.Tipo}\n Fabricante: {equipamento.Fabricante}\n Modelo: {equipamento.Modelo}\n IP: {equipamento.IP}\n Localização: {equipamento.Localizacao}\n Data de Instalação: {equipamento.DataInstalacao}\n Status: {equipamento.Statu}\n Data da Última Manutenção: {(equipamento.DataUltimaManutencao.HasValue ? equipamento.DataUltimaManutencao.Value.ToString("dd/MM/yyyy") : "Sem manutenção registrada")}\n Observação: {equipamento.Observacao}");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Equipamento não encontrado!");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.Write("Digite o tipo de equipamento que deseja filtrar: ");
                        string tipoStr = Console.ReadLine();
                        if (Enum.TryParse<Tipos>(tipoStr, out Tipos tipo))
                        {
                            var equipamentos = FiltrarPorTipo(tipo);
                            //ListarEquipamentos(equipamentos);
                            foreach (var equip in equipamentos)
                            {
                                Console.Clear();
                                Console.WriteLine($"Código: {equip.Codigo}\n Nome: {equip.NomeDescricao}\n Tipo: {equip.Tipo}\n Fabricante: {equip.Fabricante}\n Modelo: {equip.Modelo}\n IP: {equip.IP}\n Localização: {equip.Localizacao}\n Data de Instalação: {equip.DataInstalacao}\n Status: {equip.Statu}\n Data da Última Manutenção: {(equip.DataUltimaManutencao.HasValue ? equip.DataUltimaManutencao.Value.ToString("dd/MM/yyyy") : "Sem manutenção registrada")}\n Observação: {equip.Observacao}");
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Tipo de equipamento inválido!");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        Console.Write("Digite a localização que deseja filtrar: ");
                        string localizacao = Console.ReadLine();
                        var equipament = FiltrarPorLocalizacao(localizacao);
                        if (equipament.Count == 0 || equipament == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Nenhum equipamento encontrado nessa localização!");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }else
                    {
                        {foreach (var equip in equipament)
                        {
                            Console.Clear();
                            Console.WriteLine($"Código: {equip.Codigo}\n Nome: {equip.NomeDescricao}\n Tipo: {equip.Tipo}\n Fabricante: {equip.Fabricante}\n Modelo: {equip.Modelo}\n IP: {equip.IP}\n Localização: {equip.Localizacao}\n Data de Instalação: {equip.DataInstalacao}\n Status: {equip.Statu}\n Data da Última Manutenção: {(equip.DataUltimaManutencao.HasValue ? equip.DataUltimaManutencao.Value.ToString("dd/MM/yyyy") : "Sem manutenção registrada")}\n Observação: {equip.Observacao}");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;
                            
                        }
                    }
                        
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                }
            }
            else if (opcao == 11)
            {
                Console.WriteLine("Encerrando!");
                //Console.WriteLine(Tipos.Firewall);
                Thread.Sleep(2000);
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                Console.Clear();
                continue;
            }
        }
    }        
catch
{
    Console.WriteLine("Algo deu errado tente novamente!");
    Thread.Sleep(2000);
    ExibeMenu();
}
