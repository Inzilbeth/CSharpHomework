using System;
using System.Windows.Forms;
using System.Drawing;


namespace Forms
{
    /// <summary>
    /// Controls the button field.
    /// </summary>
    public class Controller
    {
        private Random rand = new Random();

        public Button[,] buttonArray;
        public int[,] valueArray;

        private int size;
        private Button firstButton;
        private Button secondButton;

        private int first = -1;
        private int second = -1;
        private int currentlyChoosing = 0;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="size">Size of the array.</param>
        public Controller(int size)
        {
            if (size % 2 != 0 || size <= 0)
            {
                throw new ArgumentException("Wrong size");
            }

            this.size = size;
            Initialize();
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        public void Initialize()
        {
            buttonArray = new Button[size, size];
            valueArray = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    valueArray[i, j] = -1;
                }
            }

            for (int i = 0; i < (size * size) / 2 - 1; ++i)
            {
                for (int k = 0; k < 2; ++k)
                {
                    int x = rand.Next(0, size);
                    int y = rand.Next(0, size);

                    while (valueArray[x, y] != -1)
                    {
                        x = rand.Next(0, size);
                        y = rand.Next(0, size);
                    }

                    valueArray[x, y] = i;
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Location = new Point(i * 40, j * 40);
                    buttonArray[i, j].Size = new Size(40, 40);
                    
                }
            }
        }

        /// <summary>
        /// Clicks on the button with (i, j) coordinates
        /// </summary>
        public void Click(int i, int j)
        {
            switch (currentlyChoosing)
            {
                case 0:
                    {
                        if (firstButton != null && secondButton != null && first != second)
                        {
                            firstButton.Text = string.Empty;
                            secondButton.Text = string.Empty;
                        }

                        firstButton = buttonArray[i, j];
                        currentlyChoosing = 1;
                        first = valueArray[i, j];
                        firstButton.Text = valueArray[i, j].ToString();
                        break;
                    }
                case 1:
                    {
                        secondButton = buttonArray[i, j];
                        currentlyChoosing = 0;
                        second = valueArray[i, j];
                        secondButton.Text = valueArray[i, j].ToString();

                        if (first == second && firstButton != secondButton)
                        {
                            firstButton.Enabled = false;
                            secondButton.Enabled = false;
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Checks if a player has won (checks if all the buttons are disabled).
        /// </summary>
        /// <returns></returns>
        public bool WinCheck()
        {
            foreach (var button in buttonArray)
            {
                if (button.Enabled)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

