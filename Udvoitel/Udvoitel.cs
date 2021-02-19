using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Class_Udvoitel
{
    class Udvoitel
    {
        public event System.Action Update;

        int current = 1;
        int count = 0;//количество шагов

        public int Finish { get; private set; }
        Stack<int> history = new Stack<int>();

        public int Current
        {
            get { return current; }
        }

        public int Count
        {
            get { return count; }
        }

        public int Steps
        {
            get
            {
                int f = Finish;
                int i = 0;
                while (f != 1)
                {
                    f = f % 2 == 0 ? f / 2 : f - 1;
                    i++;
                }
                return i;
            }
        }

        public Udvoitel(int min, int max)
        {
            Finish = new Random().Next(min, max + 1);
            if (Update != null) Update.Invoke();
        }

        public Udvoitel()
        {
            Finish = new Random().Next(10, 101);
            if (Update != null) Update.Invoke();
        }

        public Udvoitel(int finish)
        {
            this.Finish = finish;
            if (Update != null) Update.Invoke();
        }

        public int Plus()
        {
            history.Push(current);
            current++;
            count++;
            if (Update != null) Update.Invoke();
            checking();
            return current;
        }

        public int Multi()
        {
            history.Push(current);
            current *= 2;
            count++;
            if (Update != null) Update.Invoke();
            checking();
            return current;
        }

        public void Reset()
        {
            current = 1;
            count = 0;
            history.Clear();
            if (Update != null) Update.Invoke();
        }

        public void Back()
        {
            if (history.Count != 0)
            {
                count--;
                current = history.Pop();                
                Update?.Invoke();
            }
        }

        public override string ToString()
        {
            return current.ToString();
        }

        private void checking()
        {
            if (Finish == Current)
            {
                if (MessageBox.Show("Победа!!! Играть еще?", "Победа!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Reset();
                }
                else
                {
                    
                }
            }
            else if (Finish < Current)
            {
                if  (MessageBox.Show("Вы проиграли!  Играть еще?", "Вы проиграли!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Reset();
                }
                else
                {
                   //btnExit_Click();

                }
            }
        }
    }
}
