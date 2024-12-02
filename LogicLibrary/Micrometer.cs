namespace LogicLibrary
{
    public class Micrometer
    {
        public int Value { get; set; }

        public Micrometer(int value) 
        {
            Value = value; 
        }

        public Angle ConvertToAngel()
        {
            return new Angle(0, 0, 0);
        }
    }
}
