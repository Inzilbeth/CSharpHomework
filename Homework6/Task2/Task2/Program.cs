using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            using (StreamWriter sr = new StreamWriter("temp.txt"))
            {
                sr.Write(   @"#######################
#                     #
#             #       #
#             #       #
#   ##############    #
#         #           #
#   @     #           #
#         #           #
#                     #
#######################");
            }
            
            var controller = new CursorController(@"temp.txt");

            File.Delete("temp.txt");

            eventLoop.LeftHandler += controller.OnLeft;
            eventLoop.RightHandler += controller.OnRight;
            eventLoop.UpHandler += controller.OnUp;
            eventLoop.DownHandler += controller.OnDown;

            controller.Print();

            eventLoop.Run();
        }
    }
}
