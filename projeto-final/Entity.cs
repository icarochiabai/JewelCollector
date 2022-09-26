namespace projeto_final
{
    /// <summary>
    /// Classe padrão para entidades, inclui todas as entidades utilizadas. Aproveita do conceito polimorfismo.
    /// </summary>
    public class Entity
    {
        
        private int x, y;
        private string? simbolo;
        private bool transposable;
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="x">Posição x.</param>
        /// <param name="y">Posição y.</param>
        /// <param name="simbolo">Símbolo da classe.</param>
        /// <param name="transposable">Se é transponível ou não.</param>
        public Entity(int x, int y, string simbolo, bool transposable){
            this.setX(x);
            this.setY(y);
            this.setSimbolo(simbolo);
            this.setTransposable(transposable);
        }
        public Entity(int x, int y, string simbolo) : this(x, y, simbolo, false) { }
        /// <summary>
        /// Getter para a posição x.
        /// </summary>
        /// <returns>Inteiro da posição x.</returns>
        public int getX(){
            return this.x;
        }
        /// <summary>
        /// Getter para a posição y.
        /// </summary>
        /// <returns>Inteiro da posição y.</returns>
        public int getY(){
            return this.y;
        }
        /// <summary>
        /// Getter para o símbolo.
        /// </summary>
        /// <returns>String do símbolo.</returns>
        public string getSimbolo(){
            return this.simbolo;
        }
        /// <summary>
        /// Setter para a posição x.
        /// </summary>
        /// <param name="x">Valor para nova posição x.</param>
        public void setX(int x){
            this.x = x;
        }
        /// <summary>
        /// Setter para a posição y.
        /// </summary>
        /// <param name="y">Valor para a nova posição y.</param>
        public void setY(int y){
            this.y = y;
        }
        /// <summary>
        /// Setter para o símbolo.
        /// </summary>
        /// <param name="simbolo">Valor para o novo símbolo.</param>
        public void setSimbolo(string simbolo){
            this.simbolo = simbolo;
        }
        /// <summary>
        /// Setter para a transponibilidade.
        /// </summary>
        /// <param name="value">Novo valor para a transponibilidade.</param>
        public void setTransposable(bool value){
            this.transposable = value;
        }
        /// <summary>
        /// Override do método ToString().
        /// </summary>
        /// <returns>Símbolo da entidade.</returns>
        public override string ToString()
        {
            return this.getSimbolo();
        } 
        /// <summary>
        /// Retorna se a entidade é transponível ou não.
        /// </summary>
        /// <returns>Valor da transponibilidade.</returns>
        public bool isTransposable()
        {
            return this.transposable;
        }
    }
    /// <summary>
    /// Classe base que herda da entidade.
    /// </summary>
    public class Nada : Entity
    {
        public Nada(int x, int y) : base(x, y, "--", true) {
         }
    }

}