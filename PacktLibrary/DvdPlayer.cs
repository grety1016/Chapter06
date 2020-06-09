using static System.Console;
namespace Packt.Shared
{
    public class DvdPlayer:BasePlayer,IPlayable
    {
        public void Pause()
        {
            WriteLine("DVD player is pausing. ") ;
        }
        public void Play()
        {
            WriteLine("DVD player is playing. ") ;
        }

        public void stop()
        {
            
            WriteLine("This is a derived class");
        }

        public new void StopPlay()
        {
            base.StopPlay();
            WriteLine("This is a overrride method");
        }
    }
}