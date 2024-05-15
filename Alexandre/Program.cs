





void printMatriz(string[,] matrizPrincipal)
{

    for (int i = 0; i < matrizPrincipal.GetLength(0); i++)
    {
        for (int j = 0; j < matrizPrincipal.GetLength(1); j++)
        {
            Console.Write(matrizPrincipal[i, j] + " ");
        }
        Console.WriteLine();
    }

}


void colocarAsteristicos(ref string[,] matrizPrincipal)
{

    for (int i = 0; i < matrizPrincipal.GetLength(0); i++)
    {
        for (int j = 0; j < matrizPrincipal.GetLength(1); j++)
        {
            matrizPrincipal[i, j] = "*";
        }
    }

}

void colocarNaMatrizResultado(ref string[,] matrizResultado)
{
    Random rnd = new Random();
    HashSet<string> jaFoi = new HashSet<string>();
    string[] letras = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c"];

    for (int i = 0; i < 12; i++)
    {
        int cont = 0;
        while (cont != 2)
        {
            int linha = rnd.Next(0, 4);
            int coluna = rnd.Next(0, 6);

            if (jaFoi.Contains(linha.ToString() + coluna.ToString()))
            {

                continue;
            }
            cont++;
            jaFoi.Add(linha.ToString() + coluna.ToString());
            matrizResultado[linha, coluna] = letras[i];

        }

    }


}

void printJogo(ref string[,] matrizPrincipal, string[,] matrizResultado, int proxLinha, int coluna, ref Dictionary<string, GuardarPosicao> valoresArmazenados)
{

    int contJogadas = 1;
    matrizPrincipal[proxLinha, coluna] = matrizResultado[proxLinha, coluna];
    matrizPrincipal[proxLinha, coluna + 1] = matrizResultado[proxLinha, coluna + 1];

    string carater1 = matrizPrincipal[proxLinha, coluna];
    string carater2 = matrizPrincipal[proxLinha, coluna + 1];

    Console.WriteLine("Jogada:" + contJogadas + "\n");
    printMatriz(matrizPrincipal);

    if(carater1 == carater2)
    {
        Console.WriteLine("Opa que sorte achei a combinação!!!!!");
        return;
    }


        if(valoresArmazenados.ContainsKey(carater1) && !valoresArmazenados.ContainsKey(carater2))
        {
        valoresArmazenados.TryGetValue(carater1,out GuardarPosicao pegarPos);
            Console.WriteLine("Opa eu sei aonde esta o outro '" + carater1 + "' esta na linha "+ pegarPos.linha + " na coluna "+ pegarPos.coluna);
            Console.WriteLine("\nProxima tentativa para pegar nova combinação encontrada :)");

        string salvar1 = matrizPrincipal[proxLinha, coluna];
        string salvar2 = matrizPrincipal[proxLinha, coluna + 1];
        matrizPrincipal[proxLinha, coluna] = "*";
        matrizPrincipal[proxLinha, coluna + 1] = "*";

        if (matrizResultado[pegarPos.linha, pegarPos.coluna] == salvar1)
        {
            matrizPrincipal[pegarPos.linha, pegarPos.coluna] = salvar1;
            matrizPrincipal[proxLinha, coluna] = salvar1;
            printMatriz(matrizPrincipal);
        }

        if (matrizResultado[pegarPos.linha, pegarPos.coluna] == salvar2)
        {
            matrizPrincipal[pegarPos.linha, pegarPos.coluna] = salvar2;
            matrizPrincipal[proxLinha, coluna + 1] = salvar2;
            printMatriz(matrizPrincipal);
        }
        valoresArmazenados.Remove(carater1);

        GuardarPosicao guardarPosicao = new GuardarPosicao();
        guardarPosicao.linha = proxLinha;
        guardarPosicao.coluna = coluna+1;
        valoresArmazenados.Add(carater2, guardarPosicao);


        contJogadas++;
        return;
      }
        if (valoresArmazenados.ContainsKey(carater2) && !valoresArmazenados.ContainsKey(carater1))
        {
        valoresArmazenados.TryGetValue(carater2, out GuardarPosicao pegarPos);
        
        Console.WriteLine("Opa eu sei aonde esta o outro '" + carater2 + "' esta na linha " + pegarPos.linha + " na coluna " + pegarPos.coluna);

        Console.WriteLine("\nProxima tentativa para pegar nova combinação encontrada :)");
        string salvar1 = matrizPrincipal[proxLinha, coluna];
        string salvar2 = matrizPrincipal[proxLinha, coluna + 1];
        matrizPrincipal[proxLinha, coluna] = "*";
        matrizPrincipal[proxLinha, coluna + 1] = "*";

        if (matrizResultado[pegarPos.linha,pegarPos.coluna] == salvar1)
        {
            matrizPrincipal[pegarPos.linha, pegarPos.coluna] = salvar1;
            matrizPrincipal[proxLinha, coluna] = salvar1;
            printMatriz(matrizPrincipal);
        }

        if (matrizResultado[pegarPos.linha, pegarPos.coluna] == salvar2)
        {
            matrizPrincipal[pegarPos.linha, pegarPos.coluna] = salvar2;
            matrizPrincipal[proxLinha, coluna+1] = salvar2;
            printMatriz(matrizPrincipal);
        }

        valoresArmazenados.Remove(carater2);

        GuardarPosicao guardarPosicao = new GuardarPosicao();
        guardarPosicao.linha = proxLinha;
        guardarPosicao.coluna = coluna;
        valoresArmazenados.Add(carater1, guardarPosicao);


        contJogadas++;
        return;
        }

    if (valoresArmazenados.ContainsKey(carater2) && valoresArmazenados.ContainsKey(carater1))
    {
        valoresArmazenados.TryGetValue(carater2, out GuardarPosicao pegarPos2);
        valoresArmazenados.TryGetValue(carater1, out GuardarPosicao pegarPos1);

        Console.WriteLine("Opa eu sei aonde esta os dois caracteres, o '" + carater1 + "' esta na linha " + pegarPos1.linha + " na coluna " + pegarPos1.coluna +"\nE o caractere '"+carater2+"' esta na linha "+pegarPos2.linha+" e na coluna "+ pegarPos2.coluna);

        Console.WriteLine("\nProxima tentativa para pegar as duas combinações encontradas :)");

        string salvar1 = matrizPrincipal[proxLinha, coluna];
        string salvar2 = matrizPrincipal[proxLinha, coluna+1];

        matrizPrincipal[proxLinha, coluna] = "*";
        matrizPrincipal[proxLinha, coluna + 1] = "*";
        printMatriz(matrizPrincipal);
        Console.WriteLine("\nPegando a primeira combinação das duas encontradas");
        if(matrizResultado[pegarPos1.linha, pegarPos1.coluna] == salvar1)
        {
            matrizPrincipal[proxLinha, coluna] = salvar1;
            matrizPrincipal[pegarPos1.linha, pegarPos1.coluna] = salvar1;
            printMatriz(matrizPrincipal);
        }
        if (matrizResultado[pegarPos1.linha, pegarPos1.coluna] != salvar1)
        {
            matrizPrincipal[proxLinha, coluna] = salvar2;
            matrizPrincipal[pegarPos1.linha, pegarPos1.coluna] = salvar2;
            printMatriz(matrizPrincipal);
        }

        Console.WriteLine("\nPegando a segunda combinação das duas encontradas");
        if (matrizResultado[pegarPos2.linha, pegarPos2.coluna] == salvar2)
        {
            matrizPrincipal[proxLinha, coluna+1] = salvar2;
            matrizPrincipal[pegarPos2.linha, pegarPos2.coluna] = salvar2;
            printMatriz(matrizPrincipal);
        }
        if (matrizResultado[pegarPos2.linha, pegarPos2.coluna] != salvar2)
        {
            matrizPrincipal[proxLinha, coluna+1] = salvar1;
            matrizPrincipal[pegarPos2.linha, pegarPos2.coluna] = salvar1;
            printMatriz(matrizPrincipal);
        }
        valoresArmazenados.Remove(carater2);
        valoresArmazenados.Remove(carater1);


        contJogadas++;
        return;
    }

    armazenarOsValoresAindaNaoEncontrados(ref valoresArmazenados,proxLinha, coluna,  carater1, carater2);

    matrizPrincipal[proxLinha, coluna] = "*";
    matrizPrincipal[proxLinha, coluna + 1] = "*";
    contJogadas++;
    Console.WriteLine("\nProxima tentativa para buscar novas combinações que ainda não encontrei");
}

void armazenarOsValoresAindaNaoEncontrados( ref Dictionary<string, GuardarPosicao> valoresArmazenados,
    int proxLinha, int coluna, string carater1, string carater2)
{
    if (!valoresArmazenados.ContainsKey(carater2))
    {

        GuardarPosicao guardarPosicao = new GuardarPosicao();
        guardarPosicao.linha = proxLinha;
        guardarPosicao.coluna = coluna + 1;
        valoresArmazenados.Add(carater2, guardarPosicao);
    }
    if (!valoresArmazenados.ContainsKey(carater1))
    {

        GuardarPosicao guardarPosicao = new GuardarPosicao();
        guardarPosicao.linha = proxLinha;
        guardarPosicao.coluna = coluna;
        valoresArmazenados.Add(carater1, guardarPosicao);
    }
}


void jogando(ref string[,] matrizPrincipal, string[,] matrizResultado)
{
    Dictionary<string, GuardarPosicao> valoresArmazenados = new Dictionary<string, GuardarPosicao>();
    printMatriz(matrizResultado);
    
    int proxLinha = 0;
    while (proxLinha!=4)
    {
        
        for (int coluna = 0; coluna < 6; coluna+=2)
        {
            
            

            printJogo(ref matrizPrincipal, matrizResultado, proxLinha, coluna, ref valoresArmazenados);

            

            

            Console.WriteLine("-----------------");
            Console.WriteLine("-----------------");
        }

        proxLinha++;

    }

}


string[,] matrizPrincipal = new string[4, 6];

string[,] matrizResultado = new string[4, 6];


colocarAsteristicos(ref matrizPrincipal);

colocarNaMatrizResultado(ref matrizResultado);

jogando(ref matrizPrincipal, matrizResultado);

public struct GuardarPosicao
{
    public int linha;
    public int coluna;
};