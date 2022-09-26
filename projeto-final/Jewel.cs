namespace projeto_final;

/// <summary>
/// Classe das jóias. Herda da classe entidade.
/// </summary>
public class Jewel : Entity
{
    private int pontos;
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <param name="pontos">Pontos recebidos ao coletar a jóia.</param>
    /// <param name="simbolo">Símbolo da jóia.</param>
    /// <returns></returns>
    public Jewel(int x, int y, int pontos, string simbolo) : base(x, y, simbolo) 
    {
        this.pontos = pontos;
    }  
    /// <summary>
    /// Getter dos pontos da jóia.
    /// </summary>
    /// <returns>Inteiro da quantidade de pontos recebidos ao coletar a jóia.</returns>
    public int getPontos(){
        return this.pontos;
    }
    /// <summary>
    /// Método estático para gerar uma jóia aleatória.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <returns>Uma jóia Red, Green ou Blue.</returns>
    public static Jewel randomGem(int x, int y){
        Random rnd = new Random();
        int num = rnd.Next(1, 4);
        if(num == 1){
            return new Red(x, y);
        }
        else if(num == 2){
            return new Green(x, y);
        }
        else{
            return new Blue(x, y);
        }
    }
}
/// <summary>
/// Classe da jóia Red, herda da classe Jewel.
/// </summary>
public class Red : Jewel
{
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <returns>Uma jóia Red.</returns>
    public Red(int x, int y) : base(x, y, 100, "JR") { }
}

/// <summary>
/// Classe da jóia Green, herda da classe Jewel.
/// </summary>
public class Green : Jewel
{
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <returns>Uma jóia Green.</returns>
    public Green(int x, int y) : base(x, y, 50, "JR") { }
}

/// <summary>
/// Classe da jóia Blue, herda da classe Jewel.
/// </summary>
public class Blue : Jewel
{
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <returns>Uma jóia Blue.</returns>
    public Blue(int x, int y) : base(x, y, 10, "JB") { }
}

