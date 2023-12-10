namespace MyApp
{
    public class Program
    {
        static void Main()
        {
            List<string> positionsMenuList = new List<string>();
            positionsMenuList.Add("Opcja_01");
            positionsMenuList.Add("Opcja_02");
            positionsMenuList.Add("Opcja_03");
            positionsMenuList.Add("Opcja_04");
            positionsMenuList.Add("Opcja_05");

            ShowMenu mainMenu = new ShowMenu("Wybierz Opcję:", positionsMenuList);

            int activePosition = 0;
            int lastPosition = 0;
            int widthPositions = 35;

            mainMenu.ShowMenuHeader();
            mainMenu.ShowMenuPositions();
            do
            {
                lastPosition = activePosition;
                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.UpArrow: activePosition = (mainMenu.ActivePosition > 0) ? mainMenu.ActivePosition - 1 : mainMenu.PositionsMenuList.Count - 1; break;
                    case ConsoleKey.DownArrow: activePosition = (mainMenu.ActivePosition + 1) % mainMenu.PositionsMenuList.Count; break;
                    case ConsoleKey.Enter: Environment.Exit(0); break;
                }
                mainMenu.ChangeMenuActivePosition(lastPosition, activePosition, widthPositions);
            }
            while (true);
        }
    }
    public class ShowMenu
    {
        private string Header { get; set; }
        public List<string> PositionsMenuList { get; set; }
        public int ActivePosition { get; private set; }

        public ShowMenu(string header, List<string> positionsMenuList)
        {
            this.Header = header;
            this.PositionsMenuList = positionsMenuList;
            this.ActivePosition = 0;
        }
        public void ShowMenuPositions()
        {
            int position = 0;
            foreach (string item in PositionsMenuList)
            {
                if (position == ActivePosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0,-35}", PositionsMenuList[position]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(item);
                }
                position++;
            }
        }
        public void ChangeMenuActivePosition(int lastPosition, int activePosition, int widthPositions)
        {
            this.ActivePosition = activePosition;
            if (PositionsMenuList.Count > 0)
            {
                Console.SetCursorPosition(0, lastPosition +1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0,-35}", PositionsMenuList[lastPosition]);
                Console.SetCursorPosition(0, activePosition + 1);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0,-35}", PositionsMenuList[activePosition]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ShowMenuHeader()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(this.Header);
        }
    }

}
