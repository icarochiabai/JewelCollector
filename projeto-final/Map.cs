namespace projeto_final;
/// <summary>
/// Classe do mapa.
/// </summary>
public class Map
{
    private int rows, columns;
    private bool radioativos;
    private Entity[,] map;
    private List<List<Entity>> entities = new List<List<Entity>>();
    private List<Entity> jewels = new List<Entity>();
    private List<Entity> obstacles = new List<Entity>();
    /// <summary>
    /// Construtor da classe.
    /// </summary>
    /// <param name="rows">Número de linhas.</param>
    /// <param name="columns">Número de colunas.</param>
    /// <param name="radioativos">Se pode possuir valores radioativos.</param>
    public Map(int rows, int columns, bool radioativos){

        this.rows = rows;
        this.columns = columns;
        this.radioativos = radioativos;
        createMap();
    }
    public Map(int rows, int columns) : this(rows, columns, false) { }
    /// <summary>
    /// Getter do número de linhas.
    /// </summary>
    /// <returns>Número de linhas.</returns>
    public int getRows(){
        return this.rows;
    }
    /// <summary>
    /// Getter do número de colunas.
    /// </summary>
    /// <returns>Número de colunas.</returns>
    public int getColumns(){
        return this.columns;
    }
    /// <summary>
    /// Retorna a entidade em certa posição.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    /// <returns>Entidade na posição (x, y).</returns>
    public Entity getEntityAt(int x, int y){
        return this.map[x, y];
    }
    /// <summary>
    /// Cria as entidades presentes no mapa.
    /// </summary>
    public void createEntities(){
        Random rnd = new Random();
        for(int i = 0; i < this.getRows() - 4; i++){
            int x, y;
            do{
                x = rnd.Next(this.getRows());
                y = rnd.Next(this.getColumns());
            } while (!(this.getEntityAt(x, y) is Nada) || (x == 0 && y == 0));
            Jewel gem = Jewel.randomGem(x, y);
            this.jewels.Add(Jewel.randomGem(x, y));
            this.addEntity(gem);
        }

        for(int i = 0; i < this.getRows(); i++){
            Obstacle obs;
            int x, y;
            do{
                x = rnd.Next(this.getRows());
                y = rnd.Next(this.getColumns());
            } while (!(this.getEntityAt(x, y) is Nada) || (x == 0 && y == 0));

            if(i % 2 == 0){
                obs = new Water(x, y);
            }
            else{
                obs = new Tree(x, y);
            }
            this.obstacles.Add(obs);
            this.addEntity(obs);
        }
        if(this.radioativos){
            for(int i = 0; i < this.getRows() - 8; i++){
                Obstacle obs;
                int x, y;
                do{
                    x = rnd.Next(this.getRows());
                    y = rnd.Next(this.getColumns());
                } while (!(this.getEntityAt(x, y) is Nada) || (x == 0 && y == 0));
                obs = new Radioativo(x, y);
                this.obstacles.Add(obs);
                this.addEntity(obs);
            }
        }

        this.entities.Add(this.jewels);
        this.entities.Add(this.obstacles);
    }
    /// <summary>
    /// Preenche o mapa com entidades de Nada.
    /// </summary>
    public void createMap(){
        this.map = new Entity[this.rows, this.columns];
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                this.addEntity(new Nada(i, j));
            }
        }
        this.createEntities();
    }    
    /// <summary>
    /// Exibe o mapa no terminal.
    /// </summary>
    public void displayMap(){
        for(int i = 0; i < this.rows; i++){
            for(int j = 0; j < this.columns; j++){
                Console.Write(this.map[i, j] + " ");
            }
            Console.Write("\n");
        }       
    }
    /// <summary>
    /// Getter das jóias geradas no mapa.
    /// </summary>
    /// <returns>Lista de jóias geradas no mapa.</returns>
    public List<Entity> getJewels(){
        return this.jewels;
    }
    /// <summary>
    /// Adiciona uma entidade ao mapa.
    /// </summary>
    /// <param name="e">Entidade a ser adicionada.</param>
    public void addEntity(Entity e){
        this.map[e.getX(), e.getY()] = e;
    }
    /// <summary>
    /// Verifica se uma entidade pode se mover em uma determinada direção.
    /// </summary>
    /// <param name="e">Entidade.</param>
    /// <param name="direction">Direção.</param>
    /// <returns>Verdadeiro ou falso.</returns>
    public bool entityCanMoveTo(Entity e, string direction){
        if(direction == "w"){
            if(e.getX() > 0 && this.map[e.getX() - 1, e.getY()].isTransposable()){
                return true;
            }
        }
        if(direction == "s"){
            if(e.getX() < this.getRows() - 1 && this.map[e.getX() + 1, e.getY()].isTransposable()){
                return true;
            }
        }
        if(direction == "a"){
            if(e.getY() > 0 && this.map[e.getX(), e.getY() - 1].isTransposable()){
                return true;
            }
        }
        if(direction == "d"){
            if(e.getY() < this.getColumns() - 1 && this.map[e.getX(), e.getY() + 1].isTransposable()){
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Verifica se alguma entidade adjacente é do tipo Radioativo.
    /// </summary>
    /// <param name="e">Entidade.</param>
    /// <returns>Verdadeiro ou falso.</returns>
    public bool isNearRadioactive(Entity e){
        if(e.getX() > 0 && this.map[e.getX() - 1, e.getY()] is Radioativo){
            return true;
        }
        if(e.getX() < this.getRows() - 1 && this.map[e.getX() + 1, e.getY()] is Radioativo){
            return true;
        }
        if(e.getY() > 0 && this.map[e.getX(), e.getY() - 1] is Radioativo){
            return true;
        }
        if(e.getY() < this.getColumns() - 1 && this.map[e.getX(), e.getY() + 1] is Radioativo){
            return true;
        }
        return false;
    }
    /// <summary>
    /// Retorna a entidade em uma posição relativa a outra entidade.
    /// </summary>
    /// <param name="e">Entidade.</param>
    /// <param name="direction">Direção.</param>
    /// <returns>Entidade relativa em determinada direção.</returns>
    public Entity entityRelativeAt(Entity e, string direction){
        if(direction == "w"){
            if(e.getX() > 0 && this.map[e.getX() - 1, e.getY()].isTransposable()){
                return this.map[e.getX() - 1, e.getY()];
            }
        }
        if(direction == "s"){
            if(e.getX() < this.getRows() - 1 && this.map[e.getX() + 1, e.getY()].isTransposable()){
                return this.map[e.getX() + 1, e.getY()];
            }
        }
        if(direction == "a"){
            if(e.getY() > 0 && this.map[e.getX(), e.getY() - 1].isTransposable()){
                return this.map[e.getX(), e.getY() - 1];
            }
        }
        if(direction == "d"){
            if(e.getY() < this.getColumns() - 1 && this.map[e.getX(), e.getY() + 1].isTransposable()){
                return this.map[e.getX(), e.getY() + 1];
            }
        }
        return new Nada(0, 0);
    }
    /// <summary>
    /// Transforma a entidade na posição (x, y) em uma entidade do tipo Nada.
    /// </summary>
    /// <param name="x">Posição x.</param>
    /// <param name="y">Posição y.</param>
    public void resetEntityAt(int x, int y){
        this.map[x, y] = new Nada(x, y);
    }
    /// <summary>
    /// Move uma entidade em uma direção.
    /// </summary>
    /// <param name="e">Entidade.</param>
    /// <param name="direction">Direção.</param>
    public void moveEntity(Entity e, string direction){
        if(direction == "w"){
            this.resetEntityAt(e.getX(), e.getY());
            e.setX(e.getX() - 1);
            this.addEntity(e);
        }
        if(direction == "s"){
            this.resetEntityAt(e.getX(), e.getY());
            e.setX(e.getX() + 1);
            this.addEntity(e);
        }
        if(direction == "a"){
            this.resetEntityAt(e.getX(), e.getY());
            e.setY(e.getY() - 1);
            this.addEntity(e);
        }
        if(direction == "d"){
            this.resetEntityAt(e.getX(), e.getY());
            e.setY(e.getY() + 1);
            this.addEntity(e);
        
        }
    }
    /// <summary>
    /// Getter do mapa.
    /// </summary>
    /// <returns>Retorna um array de entidades.</returns>
    public Entity[,] getMap(){
        return this.map;
    }
}