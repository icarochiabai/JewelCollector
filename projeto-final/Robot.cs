namespace projeto_final;

/// <summary>
/// Classe do jogador.
/// </summary>
public class Robot : Entity
{   
    private MapController mc;
    private List<Entity> mochila = new List<Entity>();
    private int energia = 5;
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="map">Mapa para ser linkado ao jogador através do MapController.</param>
    /// <returns>Objeto da classe Robot.</returns>
    public Robot(Map map) : base(0, 0, "ME") {
        this.setMap(map);
    }
    /// <summary>
    /// Setter do mapa. Cria um MapController com o mapa passado e o próprio objeto como parâmetros.
    /// </summary>
    /// <param name="map">Mapa.</param>
    public void setMap(Map map){
        this.mc = new MapController(map, this);
        this.mc.resetRobotPos();
    }
    /// <summary>
    /// Move o jogador em determinada direção.
    /// </summary>
    /// <param name="direction">Direção.</param>
    public void move(string direction){
        mc.moveRobot(direction);
    }
    /// <summary>
    /// Interage com objetos próximos, sejam eles jóias ou árvores.
    /// </summary>
    public void interact(){
        mc.collectIfNearbyGems();

        if(mc.isNearbyTrees()){
            this.interactWithNearbyTrees();
        }
    }
    /// <summary>
    /// Interage com árvores próximas, aumenta a energia do jogador em 3 unidades.
    /// </summary>
    public void interactWithNearbyTrees(){
        this.addEnergia(3);
    }
    /// <summary>
    /// Adiciona um valor ao valor atual da energia do jogador.
    /// </summary>
    /// <param name="value">Valor a ser adicionado.</param>
    public void addEnergia(int value){
        this.setEnergia(this.getEnergia() + value);
    }
    /// <summary>
    /// Adiciona jóia à mochila do jogador.
    /// </summary>
    /// <param name="gem">Jóia a ser adicionada.</param>
    public void addGemToBag(Entity gem){
        mochila.Add(gem);
        if(gem is Blue){
            this.setEnergia(this.getEnergia() + 5);
        }
    }
    /// <summary>
    /// Getter da energia do jogador.
    /// </summary>
    /// <returns>Inteiro da energia do jogador.</returns>
    public int getEnergia(){
        return this.energia;
    }
    /// <summary>
    /// Setter da energia do jogador.
    /// </summary>
    /// <param name="energia">Novo valor da energia do jogador.</param>
    public void setEnergia(int energia){
        this.energia = energia;
    }
    /// <summary>
    /// Getter da pontuação do jogador.
    /// </summary>
    /// <returns>Inteiro com a pontuação do jogador.</returns>
    public int getScore(){
        int sum = 0;
        foreach(Jewel e in this.mochila){
            sum += e.getPontos();
        }
        return sum;
    }
    /// <summary>
    /// Getter da mochila do jogador.
    /// </summary>
    /// <returns>Lista de entidades.</returns>
    public List<Entity> getMochila(){
        return this.mochila;
    }
    /// <summary>
    /// Exibe as informações relacionadas a energia, número total de itens na bolsa e o valor total de itens coletados do jogador.
    /// </summary>
    public void displayInfo(){
        Console.WriteLine("Robot's energy: " + this.energia);
        Console.WriteLine("Bag total items: " + this.mochila.Count + " | Bag total value: " + this.getScore());
    }
}
