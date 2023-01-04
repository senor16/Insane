namespace BCEngine
{
    class PlayerInput
    {
        public bool Left, Right, Up, Down, A, B, X, Y;

        public PlayerInput()
        {
            reset();
        }

        public void reset()
        {
            Left = false;
            Right = false;
            Up = false;
            Down = false;
            A = false;
            B = false;
            X = false;
            Y = false;
        }
    }
}