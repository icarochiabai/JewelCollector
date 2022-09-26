namespace projeto_final;
/// <summary>
/// Classe para os obstáculos, herda da classe Entidade.
/// </summary>
public class Obstacle : Entity
{
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <param name="simbolo">Símbolo.</param>
    /// <returns>Objeto da classe Obstáculo.</returns>
    public Obstacle(int x, int y, string simbolo) : base(x, y, simbolo) { }
}
/// <summary>
/// Classe para o objeto Water, herda da classe Obstáculo.
/// </summary>
public class Water : Obstacle
{
    public Water(int x, int y) : base(x, y, "##") { }
}
/// <summary>
/// Classe para o objeto Tree, herda da classe Obstáculo.
/// </summary>
public class Tree : Obstacle
{
    public Tree(int x, int y) : base(x, y, "$$") { }
}
/// <summary>
/// Classe para o objeto Radioativo, herda da classe Obstáculo.
/// </summary>
public class Radioativo : Obstacle
{
    public Radioativo(int x, int y) : base(x, y, "!!") { 
        this.setTransposable(true);
    }

}