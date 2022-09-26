namespace projeto_final
{
    /// <summary>
    /// Classe responsável pelas interações entre o jogador e o mapa.
    /// </summary>
    public class MapController
    {
        private Map map;
        private Robot player;
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="map">Mapa.</param>
        /// <param name="r">Jogador.</param>  
        public MapController(Map map, Robot r){
            this.map = map;
            this.player = r;
        }
        /// <summary>
        /// Move o jogador em determinada direção.
        /// </summary>
        /// <param name="direction">Direção.</param>
        public void moveRobot(string direction){
            if(this.map.entityCanMoveTo(this.player, direction)){
                if(this.map.entityRelativeAt(this.player, direction) is Radioativo){
                    this.player.addEnergia(-30);
                }
                
                this.map.moveEntity(this.player, direction);

                if(this.map.isNearRadioactive(this.player)){
                    this.player.addEnergia(-10);
                }
                this.player.addEnergia(-1);
            }
        }
        /// <summary>
        /// Verifica se há árvores adjacentes ao jogador.
        /// </summary>
        /// <returns>Verdadeiro ou falso.</returns>
        public bool isNearbyTrees(){
            if(this.player.getX() + 1 <= this.map.getColumns() - 1 && this.map.getMap()[this.player.getX() + 1, this.player.getY()] is Tree){
                return true;
            }
            else if(this.player.getX() - 1 >= 0 && this.map.getMap()[this.player.getX() - 1, this.player.getY()] is Tree){
                return true;
            }
            else if(this.player.getY() + 1 <= this.map.getRows() - 1 && this.map.getMap()[this.player.getX(), this.player.getY() + 1] is Tree){
                return true;
            }
            else if(this.player.getY() - 1 >= 0 && this.map.getMap()[this.player.getX(), this.player.getY() - 1] is Tree){
                return true;
            }
            return false;
        }
        /// <summary>
        /// Coleta uma jóia se houver alguma adjacente ao jogador.
        /// </summary>
        public void collectIfNearbyGems(){
            if(this.player.getX() + 1 <= this.map.getColumns() - 1 && this.map.getMap()[this.player.getX() + 1, this.player.getY()] is Jewel){
                this.player.addGemToBag(this.map.getMap()[this.player.getX() + 1, this.player.getY()]); 
                this.map.resetEntityAt(this.player.getX() + 1, this.player.getY());    
            }
            else if(this.player.getX() - 1 >= 0 && this.map.getMap()[this.player.getX() - 1, this.player.getY()] is Jewel){
                this.player.addGemToBag(this.map.getMap()[this.player.getX() - 1, this.player.getY()]); 
                this.map.resetEntityAt(this.player.getX() - 1, this.player.getY());    
            }
            else if(this.player.getY() + 1 <= this.map.getRows()  - 1 && this.map.getMap()[this.player.getX(), this.player.getY() + 1] is Jewel){
                this.player.addGemToBag(this.map.getMap()[this.player.getX(), this.player.getY() + 1]); 
                this.map.resetEntityAt(this.player.getX(), this.player.getY() + 1);    
            }
            else if(this.player.getY() - 1 >= 0 && this.map.getMap()[this.player.getX(), this.player.getY() - 1] is Jewel){
                this.player.addGemToBag(this.map.getMap()[this.player.getX(), this.player.getY() - 1]); 
                this.map.resetEntityAt(this.player.getX(), this.player.getY() - 1);    
            }
        }
        /// <summary>
        /// Reseta a posição do jogador para o início.
        /// </summary>
        public void resetRobotPos(){
            this.player.setX(0);
            this.player.setY(0);
            this.map.addEntity(this.player);
        }
    }
}