using RPG;
using System;
using System.IO;
using System.Collections.Generic;

DadosRPG gerenciador = new DadosRPG();
string caminhoArquivo = "dados_personagens.json";

Console.WriteLine("Bem vindo ao sistema de RPG!\nDeseja carregar os dados salvos? (S/N)?");
DadosRPG[] personagens;

if (Console.ReadLine()?.ToUpper() == "S" && File.Exists(caminhoArquivo))
{
    personagens = gerenciador.CarregarDados(caminhoArquivo);
    Console.WriteLine("Dados carregados com sucesso!");
}
else
{
    Console.WriteLine("Quantos participarão da aventura?");
    int quantidade;
    while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
    {
        Console.WriteLine("Assim não da");
    }
    personagens = new DadosRPG[quantidade];

    for (int i = 0; i < quantidade; i++)
    {
        personagens[i] = new DadosRPG();
        Console.Write($"Digite o nome do {i + 1} jogador: ");
        personagens[i].Nome = Console.ReadLine() ?? string.Empty;
    }

    Console.WriteLine("Jogadores Adicionados:");
    foreach (var item in personagens)
    {
        Console.WriteLine("--" + item.Nome);
    }
    Console.WriteLine("Agora que já temos os nossos jogadores vamos adicionar pontos mana e de saúde\n");

    for (int i = 0; i < quantidade; i++)
    {
        Console.Write($"Digite o total de pontos de mana do personagem {personagens[i].Nome}:");
        if (int.TryParse(Console.ReadLine(), out int mana))
        {
            personagens[i].PontosMana = mana;
        }
    }

    for (int i = 0; i < quantidade; i++)
    {
        Console.Write($"Digite o total de pontos de saúde do personagem {personagens[i].Nome}:");
        if (int.TryParse(Console.ReadLine(), out int saude))
        {
            personagens[i].PontosSaude = saude;
        }
    }
    Console.WriteLine($"Perfeito! Vamos recapitular rapidamente.\n\n" +
        $"Nessa sessão temos um grupo de {quantidade} composto por:");
    foreach (var jogador in personagens)
    {
        int indice = Array.IndexOf(personagens, jogador);
        Console.WriteLine($"- {jogador.Nome} ---Mana: {jogador.PontosMana} ---Saúde: {jogador.PontosSaude}");
    }
    Console.WriteLine("S = sim , N = não");
    switch (Console.ReadLine()?.ToUpper())
    {
        case "S":
            Console.WriteLine("Perfeito! Continuando...\n");
            break;
        case "N":
            Console.WriteLine("Eita... Reinicia o sistema e preenche direito");
            return;
        default:
            Console.WriteLine("Não é possível que vc conseguiu clicar errado...");
            break;
    }
}
Console.WriteLine("Agora que já configuramos os dados dos nossos personagens. Que comece a aventura!!\n\n\n\n\n");
Console.WriteLine("Deseja fazer alguma alteração de vida ou mana?");
Console.WriteLine("S = sim , N = não");

while (true)
{
    Console.WriteLine("\nDeseja fazer alguma alteração (S), Ver status (V), Salvar progresso (G) ou Encerrar (E)?");
    string opcao = Console.ReadLine()?.ToUpper() ?? "";

    if (opcao == "E") return;

    switch (opcao)
    {
        case "S":
            Console.WriteLine("Qual personagem deseja alterar?");
            string nomeBusca = Console.ReadLine() ?? "";
            var p = Array.Find(personagens, x => x.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            if (p == null)
            {
                Console.WriteLine("Não encontramos o seu personagem...");
                continue;
            }

            Console.WriteLine("Alterar (M)ana ou (S)aúde?");
            string tipo = Console.ReadLine()?.ToUpper() ?? "";

            Console.WriteLine("Digite o novo valor:");
            if (int.TryParse(Console.ReadLine(), out int novoValor) && novoValor >= 0)
            {
                if (tipo == "M") p.PontosMana = novoValor;
                else if (tipo == "S") p.PontosSaude = novoValor;
                Console.WriteLine("Os pontos foram atualizados com sucesso!!");
            }
            break;

        case "V":
            ExibirStatus(personagens);
            break;

        case "G":
            gerenciador.SalvarDados(personagens, caminhoArquivo);
            Console.WriteLine(">>>> Dados salvos no arquivo local com sucesso! <<<<");
            break;

        default:
            Console.WriteLine("O que vc quer fazer?");
            break;
    }
}
void ExibirStatus(DadosRPG[] lista)
{
    Console.WriteLine("\n--- STATUS ATUAL DO GRUPO ---");
    foreach (var p in lista)
    {
        Console.WriteLine($"- {p.Nome} | Mana: {p.PontosMana} | Saúde: {p.PontosSaude}");
    }
}
