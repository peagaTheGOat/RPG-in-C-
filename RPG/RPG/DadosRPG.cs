using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RPG
{
    public class DadosRPG
    {
        public string Nome { get; set; }
        public int PontosMana { get; set; }
        public int PontosSaude { get; set; }
        public void SalvarDados(DadosRPG[] dados, string caminhoArquivo)
        {
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(dados, opcoes);
            File.WriteAllText(caminhoArquivo, jsonString);
        }
        public DadosRPG[] CarregarDados(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("Arquivo de dados não encontrado.", caminhoArquivo);
            }
            string jsonString = File.ReadAllText(caminhoArquivo);
            DadosRPG[] dados = JsonSerializer.Deserialize<DadosRPG[]>(jsonString);
            return dados ?? Array.Empty<DadosRPG>();
        }

    }
}
