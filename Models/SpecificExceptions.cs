namespace Models
{
    [System.Serializable]
    public class InputInvalidException : System.Exception
    {
        public InputInvalidException(){}
        public InputInvalidException(string memo) : base(memo) {}
        public InputInvalidException(string memo, System.Exception inner) : base(memo, inner) {}
        protected InputInvalidException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
        
    }
}