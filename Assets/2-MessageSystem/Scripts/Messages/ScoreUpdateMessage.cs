namespace DesignPattern.MessagePattern.Messages
{
    /*
     * Score Update Message
     */
    public class ScoreUpdateMessage : Message
    {
        #region Factory
        
        public static ScoreUpdateMessage InstanceOf()
        {
            return new ScoreUpdateMessage();
        }

        #endregion

        #region Properties

        private float _score;
        public float Score
        {
            get
            {
                return _score;
            }
            set
            {
                SetScore(value);
            }
        }

        #endregion

        #region Mutators

        public ScoreUpdateMessage SetScore(float value)
        {
            _score = value;
            return this;
        }

        #endregion
    }
}
