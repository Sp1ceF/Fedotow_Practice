using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEY_Task_6
{
    internal class Controller
    {
        bool _isWorking = true;
        string[] fio;
        string[] work;
        public Controller()
        {
            fio = new string[0];
            work = new string[0];
        }
        public void Loop()
        {
            while (_isWorking)
            {
                PrintInterface();
                GetInput();
                PressToContinue();
            }
        }

        private void PressToContinue()
        {
            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        private void PrintInterface()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("1)Добавить досье\n2)Вывести все досье\n3)Удалить досье\n4)Поиск по фамилии\n5)Выход");
        }
        private void GetInput()
        {
            string input = Console.ReadLine();
            int.TryParse(input, out int intInp);

            switch (intInp)
            {
                case 1:
                    AddRecord();
                    break;
                case 2:
                    PrintRecords();
                    break;
                case 3:
                    RemoveRecord();
                    break;
                case 4:
                    Search();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Wrong command, try again");
                    GetInput();
                    break;
            }
        }
        private void AddRecord()
        {
            Array.Resize(ref fio, fio.Length+1);
            Array.Resize(ref work, work.Length + 1);
            Console.Write("Введите фамилию: ");
            string familiya = Console.ReadLine();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string otchestvo = Console.ReadLine();
            Console.Write("Введите должность: ");
            string doljnost = Console.ReadLine();
            string fiostr = familiya + " " + name + " " + otchestvo;
            fio[fio.Length-1] = fiostr;
            work[work.Length-1] = doljnost;
            Console.WriteLine("Досье успешно добавлено");
        }
        private void RemoveRecord()
        {
            Console.WriteLine("Введите индекс для удаления: ");
            if(!int.TryParse(Console.ReadLine(), out int removeIndex))
            {
                Console.WriteLine("Wrong command, try again");
                RemoveRecord();
                return;
            }
            removeIndex--;
            if(removeIndex<0 || removeIndex >= fio.Length)
            {
                Console.WriteLine("Index is outside of bounds, enter another one");
                RemoveRecord();
                return; 
            }
            fio= fio.Where((sourse,index) => index!= removeIndex).ToArray();
            work= work.Where((sourse,index) => index!= removeIndex).ToArray();
            Console.WriteLine("Досье успешно удалено");

        }
        private void PrintRecords()
        {
            if (fio.Length == 0) 
            { 
                Console.WriteLine("Нету записей");
                return;
            }
            for (int i = 0; i < fio.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {fio[i]} - {work[i]}");
            }
        }
        private void Search()
        {
            Console.WriteLine("Введите фамилию для поиска: ");
            string familiya = Console.ReadLine();
            for (int i = 0; i < fio.Length; i++)
            {
                string familStr = fio[i].Split(" ")[0];
                if (familStr.Contains(familiya))
                {
                    Console.WriteLine($"{i + 1}) {fio[i]} - {work[i]}");
                }
            }
        }
        private void Exit()
        {
            _isWorking = false;
        }
    }
}
