using System;

class Program
{
    static void Main()
    {
        const int MAX_ALUNOS = 25;
        const int TAM_NOME = 50;

        string[] nomes = new string[MAX_ALUNOS];
        float[] av1 = new float[MAX_ALUNOS];
        float[] av2 = new float[MAX_ALUNOS];
        float[] media = new float[MAX_ALUNOS];
        float[] final = new float[MAX_ALUNOS];
        float[] mediaFinal = new float[MAX_ALUNOS];

        for (int i = 0; i < MAX_ALUNOS; ++i)
        {
            Console.Write($"Digite o nome do aluno {i + 1}: ");
            nomes[i] = Console.ReadLine();

            Console.Write($"Digite a nota da AV1 do aluno {i + 1}: ");
            av1[i] = float.Parse(Console.ReadLine());

            Console.Write($"Digite a nota da AV2 do aluno {i + 1}: ");
            av2[i] = float.Parse(Console.ReadLine());

            // Calcula a média do aluno
            media[i] = (av1[i] + av2[i]) / 2;

            // Verifica se precisa fazer a prova final
            if (media[i] < 6)
            {
                Console.WriteLine($"Este aluno {nomes[i]} deve fazer a prova final.");
                Console.Write($"Digite a nota da prova final do aluno {i + 1}: ");
                final[i] = float.Parse(Console.ReadLine());

                // Calcula a nova média final junto à prova final
                mediaFinal[i] = (media[i] + final[i]) / 2;
            }
        }

        do
        {
            // Buscando aluno por nome
            Console.Write("\nDigite o nome do aluno para busca: ");
            string busca_nome = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < MAX_ALUNOS; ++i)
            {
                if (nomes[i].Equals(busca_nome, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Aluno encontrado: {nomes[i]}");
                    Console.WriteLine($"Média: {media[i]:F2}");
                    Console.WriteLine($"Média após prova final: {mediaFinal[i]:F2}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Aluno não encontrado.");
            }

            Console.Write("Deseja continuar procurando (s/n)? ");
            char continuar = Console.ReadKey().KeyChar;

            if (continuar != 's' && continuar != 'S')
            {
                break;
            }
        } while (true);

        // Buscando alunos aprovados por média
        Console.WriteLine("\nAlunos aprovados por média:");
        for (int i = 0; i < MAX_ALUNOS; ++i)
        {
            if (media[i] >= 6)
            {
                Console.WriteLine(nomes[i]);
            }
        }

        // Buscando alunos reprovados
        Console.WriteLine("\nAlunos reprovados:");
        for (int i = 0; i < MAX_ALUNOS; ++i)
        {
            if (media[i] < 6 && mediaFinal[i] < 6)
            {
                Console.WriteLine(nomes[i]);
            }
        }

        // Busca alunos aprovados após a prova final
        Console.WriteLine("\nAlunos aprovados após a prova final:");
        for (int i = 0; i < MAX_ALUNOS; ++i)
        {
            if (mediaFinal[i] >= 6)
            {
                Console.WriteLine(nomes[i]);
            }
        }
    }
}