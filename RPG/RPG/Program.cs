Console.WriteLine("Bem vindo ao sistema de RPG!\nInsira o número de integrantes do grupo:\n\n\n" +
    "Numero de integrantes:");
int quantidade;
while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
{
    Console.WriteLine("Entrada inválida. Informe um número inteiro maior que zero para o tamanho do grupo:");
}

string[] itens = new string[quantidade];
for (int i = 0; i < quantidade; i++)
{
    Console.Write($"Digite o nome do {i + 1} jogador: ");
    itens[i] = Console.ReadLine() ?? string.Empty;
}

Console.WriteLine("Jogadores Adicionados:");
foreach (string item in itens)
{
    Console.WriteLine("--" + item);
}
Console.WriteLine("Agora que já temos os nossos jogadores vamos adicionar pontos mana e de saúde\n");
int[] pontosMana = new int[quantidade];
for (int i = 0; i < quantidade; i++)
{
    Console.Write($"Digite o total de pontos de mana do personagem {itens[i]}:");
    while (!int.TryParse(Console.ReadLine(), out pontosMana[i]) || pontosMana[i] <= 0)
    {
        Console.WriteLine("Entrada inválida. Informe um número inteiro maior ou igual a zero para os pontos de mana:");
    }
}
int[] pontosSaude = new int[quantidade];
for (int i = 0; i < quantidade; i++)
{
    Console.Write($"Digite o total de pontos de saúde do personagem {itens[i]}:");
    while (!int.TryParse(Console.ReadLine(), out pontosSaude[i]) || pontosSaude[i] <= 0)
    {
        Console.WriteLine("Informe um número inteiro maior ou igual a zero para os pontos de saúde:");
    }
}
Console.WriteLine($"Perfeito! Vamos recapitular rapidamente.\n\n" +
    $"Nessa sessão temos um grupo de {quantidade} composto por:");
foreach (string jogador in itens)
{
    int indice = Array.IndexOf(itens, jogador);
    Console.WriteLine($"- {jogador} ---Mana: {pontosMana[indice]} ---Saúde: {pontosSaude[indice]}");
}
Console.WriteLine("S = sim , N = não");
switch(Console.ReadLine()?.ToUpper())
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
//Edição de vida e mana
Console.WriteLine("Agora que já configuramos os dados dos nossos personagens. Que comece a aventura!!\n\n\n\n\n");
Console.WriteLine("Deseja fazer alguma alteração de vida ou mana?");
Console.WriteLine("S = sim , N = não");
while (true)
{
    switch (Console.ReadLine()?.ToUpper())
    {
        case "S":
            Console.WriteLine("Qual personagem deseja alterar os pontos?");
            string nomePersonagem = Console.ReadLine() ?? string.Empty;
            int indicePersonagem = Array.IndexOf(itens, nomePersonagem);
            if (indicePersonagem == -1)
            {
                Console.WriteLine("Personagem não encontrado. Insira um personagem válido");
                continue;
            }
            Console.WriteLine("Deseja alterar pontos de Mana ou Saúde? (M/S)"); 
            string tipoPonto = Console.ReadLine()?.ToUpper() ?? string.Empty;
            if (tipoPonto != "M" && tipoPonto != "S")
            {
                Console.WriteLine("Tipo inválido");
                continue;
            }
            Console.WriteLine("Digite o novo valor:");
            int novoValor;
            if (!int.TryParse(Console.ReadLine(), out novoValor) || novoValor < 0)
            {
                Console.WriteLine("Valor inválido. Tente novamente");
                continue;
            }
            if (tipoPonto == "M")
            {
                pontosMana[indicePersonagem] = novoValor;
                Console.WriteLine($"Pontos de Mana de {nomePersonagem} atualizados para {novoValor} " +
                    $"Digite 'N' para ver as mudanças e S para mais adições" );
            }
            else
            {
                pontosSaude[indicePersonagem] = novoValor;
                Console.WriteLine($"Pontos de Saúde de {nomePersonagem} atualizados para {novoValor} " +
                    $"Digite 'N' para ver as mudanças e 'S' para mais edições");
            } 
            break;
        case "N":
            foreach (string jogador in itens)
            {
                int indice = Array.IndexOf(itens, jogador);
                Console.WriteLine($"- {jogador} --- Mana: {pontosMana[indice]} --- Saúde: {pontosSaude[indice]}");
            }
            Console.WriteLine("Encerrando alterações. Os pontos de Mana e de Saude dos personagens foram atualizados\n" +
                "Deseja fazer mais alterações? S = sim , N = não");
            break;
        default:
            Console.WriteLine("Digite S para sim ou N para não");
            break;
    }
}
