namespace X_O_Game
{
    public delegate void StatusChangedDelegate(object sender, StatusChangedArgs e);
    public class Field
    {
        public event StatusChangedDelegate StatusChanged;
        private FieldState _state;
        public FieldState State
        {
            get
            {
                return _state;
            }

            set
            {
                if (value != _state)
                {
                    // Doesn't need to fire event
                    if (value == FieldState.EMPTY)
                    {
                        _state = value;
                        return;
                    }

                    // Can't change from X to O and vice-versa
                    if (_state != FieldState.EMPTY)
                    {
                        return;
                    }

                    // Changing from EMPTY to X or O and firing event.
                    _state = value;
                    StatusChanged(this, new StatusChangedArgs(_state));
                }
            }
        }
        public Field()
        {
            State = FieldState.EMPTY;
        }
        
    }
}