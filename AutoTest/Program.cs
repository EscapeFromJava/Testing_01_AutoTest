using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.WindowsAPI;
using System.Threading;

namespace AutoTest
{
    class Program
    {
        private const string ExeSourceFile = @"C:\Windows\System32\calc1.exe";
        static private Application _application;
        static private Window _mainWindow;

        static void Main(string[] args)
        {
            var psi = new ProcessStartInfo(ExeSourceFile);
            _application = Application.AttachOrLaunch(psi);
            _mainWindow = _application.GetWindow("Калькулятор", InitializeOption.NoCache);

            //FirstTest();
            //SecondTest();
            ThirdTest();
            ThirdTestAlternative();
            
            //Label resLab = _mainWindow.Get<Label>(SearchCriteria.ByAutomationId("158"));

            //if (resLab.Text == "8")
            //    Console.WriteLine("Тест пройден успешно. Результат = {0}", resLab.Text);
            //else
            //    Console.WriteLine("Тест фейл");

            Console.ReadKey();
        }

        private static void FirstTest()
        {
            _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("81")).Click();

            Button bt5 = _mainWindow.Get<Button>(SearchCriteria.ByText("5"));
            Button btAdd = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("93"));
            Button bt3 = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("133"));
            Button btEq = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("121"));

            var listButtons = new List<Button>() { bt5, btAdd, bt3, btEq};

            foreach (var el in listButtons)
            {
                el.Click();
            }
        }

        private static void SecondTest()
        {
            _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("81")).Click();

            Keyboard.Instance.Enter("30/3");
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        private static void ThirdTest()
        {
            MenuBar menuBar = _mainWindow.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));
            Menu menu;

            string[] listCommands = { "Инженерный", "Программист", "Статистика", "Обычный" };

            foreach (var el in listCommands)
            {
                menu = menuBar.MenuItem("Вид", el);
                menu.Click();
            }
        }

        private static void ThirdTestAlternative()
        {
            string[] listCommands = { "2", "3", "4", "1" };

            foreach (var el in listCommands)
            {
                Thread.Sleep(1000);
                Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.LEFT_ALT);
                Keyboard.Instance.Enter(el);
                Keyboard.Instance.LeaveAllKeys();
            }
        }
    }
}
