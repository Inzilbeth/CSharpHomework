using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var controller = new CursorController(@"C:\Users\Талгат\Desktop\map.txt");

            eventLoop.LeftHandler += controller.OnLeft;
            eventLoop.RightHandler += controller.OnRight;
            eventLoop.UpHandler += controller.OnUp;
            eventLoop.DownHandler += controller.OnDown;

            controller.Print();

            eventLoop.Run();
        }
    }
}
