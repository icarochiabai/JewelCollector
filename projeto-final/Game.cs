namespace projeto_final
{
    /// <summary>
    /// Classe responsável por lidar das instâncias de jogos que serão criadas.
    /// </summary>
    public class Game
    {
        private int rows, columns, totalJewels;
        private Map map;
        private Robot player;
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="row">Número de linhas do mapa.</param>
        /// <param name="column">Número de colunas do mapa.</param>
        public Game(int row, int column){
            this.rows = row;
            this.columns = column;
            this.map = new Map(this.rows, this.columns);
            this.player = new Robot(this.map);
            this.totalJewels = this.map.getJewels().Count;            
        }
        /// <summary>
        /// Exibe o mapa e as informações relacionadas ao jogador.
        /// </summary>
        public void display(){
            this.map.displayMap();
            this.player.displayInfo();
        }
        /// <summary>
        /// Lida com os comandos passados através do terminal.
        /// </summary>
        /// <param name="command">Comando recebido através do terminal.</param>
        public void sendCommand(string command){
            if(command == "w" || command == "a" || command == "s" || command == "d"){
                this.player.move(command);
            }
            else if(command == "g"){
                this.player.interact();
                this.checkIfNextLevel();
            }
        }
        /// <summary>
        /// Retorna o número total de jóias do mapa.
        /// </summary>
        /// <returns>Inteiro do número total de jóias do mapa.</returns>
        public int getTotalJewels(){
            return this.totalJewels;
        }
        /// <summary>
        /// Verifica se as condições para avançar para o próximo nível foram satisfeitas e inicia o novo nível se possível.
        /// </summary>
        public void checkIfNextLevel(){
            if(this.player.getMochila().Count == this.totalJewels){
                if(rows + 1 <= 30){
                    this.map = new Map(++rows, ++columns, true);
                }
                else {
                    this.map = new Map(30, 30, true);
                }
                this.player.setMap(this.map);
                this.totalJewels += this.map.getJewels().Count;
            }
        }
        /// <summary>
        /// Verifica se o jogador não tem mais energia para continuar jogando.
        /// </summary>
        /// <returns>Retorna se a energia do jogador é menor ou igual à zero.</returns>
        public bool isOver(){
            if(this.player.getEnergia() <= 0){
                return true;
            }
            return false;
        }
    }
}