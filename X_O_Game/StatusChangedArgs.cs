namespace X_O_Game
{
    public class StatusChangedArgs
    {
        public FieldState CurrentState { get; set; }

        public StatusChangedArgs(FieldState current)
        {
            CurrentState = current;
        }
    }
}