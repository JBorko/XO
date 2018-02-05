using System;
using System.Collections.Generic;

namespace X_O_Game
{
    public class GameBoard
    {
        public Array Fields = Array.CreateInstance(typeof(Field), 3, 3);

        public void Init()
        {
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Field f = new Field
                    {
                        State = FieldState.EMPTY
                    };
                    Fields.SetValue(f, i, j);
                }
            }
        }
    }
}