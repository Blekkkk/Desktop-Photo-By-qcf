using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

class Program
{
    private static readonly string[] wallpapers = {
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (1).png",
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (2).png",
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (3).png",
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (4).png",
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (5).png",
        "C:\\Users\\qcf\\Desktop\\C#\\DesktopPhotoByqcf\\Photo\\Photo (6).png",
    };

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    private const int SPI_SETDESKWALLPAPER = 20;
    private const int SPIF_UPDATEINIFILE = 0x01;
    private const int SPIF_SENDWININICHANGE = 0x02;

    static void Main(string[] args)
    {
        Console.SetWindowSize(60, 20);
        Console.SetBufferSize(60, 20);

        Console.Clear();
        Console.SetCursorPosition((Console.WindowWidth - "Choose a wallpaper".Length) / 2, Console.WindowHeight / 2 - 2);
        Console.WriteLine("Choose a wallpaper");

        for (int i = 0; i < wallpapers.Length; i++)
        {
            Console.SetCursorPosition((Console.WindowWidth - (i + 1 + ". " + Path.GetFileName(wallpapers[i])).Length) / 2, Console.WindowHeight / 2 + i);
            Console.WriteLine((i + 1) + ". " + Path.GetFileName(wallpapers[i]));
        }

        Console.SetCursorPosition((Console.WindowWidth - "Enter the number of the wallpaper: ".Length) / 2, Console.WindowHeight / 2 + wallpapers.Length + 1);
        Console.Write("Enter the number of the wallpaper: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > wallpapers.Length)
        {
            Console.SetCursorPosition((Console.WindowWidth - "Invalid entry. Repeat: ".Length) / 2, Console.WindowHeight / 2 + wallpapers.Length + 2);
            Console.Write("Invalid entry. Repeat: ");
        }

        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpapers[choice - 1], SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        Console.ReadKey();
    }
}
