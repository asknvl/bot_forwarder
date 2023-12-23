namespace bot_forwarder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var bot = new bot_forwarder("6973654807:AAFggHHa5zEGO5aZnWzJZw6TAmEEasQNJeY");
            bot.start();


            string text = "";
            do
            {
                text = Console.ReadLine();
            } while (!text.Equals("quit"));

        }
    }
}