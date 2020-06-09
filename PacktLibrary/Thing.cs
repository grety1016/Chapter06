namespace Packt.Shared
{
    public class Thing
    {
        //field
        public object Data = default;

        //method
        public string Process(object input)
        {
            if (Data == input)
            {
                return "Data and input are the same";
            }
            else 
            {
                return "Data and input are not the same";
            }

        }
        
    }
}