
using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Выберите команду:");
      Console.WriteLine("1.Информация о  логических дисках, именах, метке тома, размере типе файловой системы");
      Console.WriteLine("2.Работа с файлами(класс File, FileInfo, FileStream и другие");
      Console.WriteLine("3.Работа с форматом JSON");
      Console.WriteLine("4.Работа с форматом XML");
      Console.WriteLine("5.Создание zip архива, добавление туда файла, определение размера архива");
      string bruh = Console.ReadLine();
      switch (bruh)
      {
        case "1":
          DriveInfo[] drives = DriveInfo.GetDrives();

          foreach (DriveInfo drive in drives)
          {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}"); //DriveType: представляет тип диска
            if (drive.IsReady) //готов ли диск (например, DVD-диск может быть не вставлен в дисковод)
            {
              Console.WriteLine($"Объем диска: {drive.TotalSize}"); //TotalSize: общий размер диска в байтах
              Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}"); //TotalFreeSpace: получает общий объем свободного места на диске в байтах
              Console.WriteLine($"Метка: {drive.VolumeLabel}"); //VolumeLabel: получает или устанавливает метку тома
            }
            Console.WriteLine();
          }
          //получение списка файлов и подкаталогов
          string dirName = "C:\\";

          if (Directory.Exists(dirName)) //Exists(path): определяет, существует ли каталог по указанному пути path. Если существует, возвращается true, если не существует, то false
          {
            Console.WriteLine("Подкаталоги:");
            string[] dirs = Directory.GetDirectories(dirName); //GetDirectories(path): получает список каталогов в каталоге path
            foreach (string s in dirs)
            {
              Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("Файлы:");
            string[] files = Directory.GetFiles(dirName); //GetFiles(path): получает список файлов в каталоге path
            foreach (string s in files)
            {
              Console.WriteLine(s);
            }
            
          }
          break;
        case "2":
          // создаем каталог для файла
          string path = @"C:\SomeDir2";
          DirectoryInfo dirInfo = new DirectoryInfo(path);
          if (!dirInfo.Exists)
          {
            dirInfo.Create();
          }
          Console.WriteLine("Введите строку для записи в файл:");
          string text = Console.ReadLine();

          // запись в файл
          using (FileStream fstream = new FileStream($@"{path}\note.txt", FileMode.OpenOrCreate))
          {
            // преобразуем строку в байты
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("Текст записан в файл");
          }

          // чтение из файла
          using (FileStream fstream = File.OpenRead($@"{path}\note.txt"))
          {
            // преобразуем строку в байты
            byte[] array = new byte[fstream.Length];
            // считываем данные
            fstream.Read(array, 0, array.Length);
            // декодируем байты в строку
            string textFromFile = System.Text.Encoding.Default.GetString(array);
            Console.WriteLine($"Текст из файла: {textFromFile}");
          }
          Console.ReadLine();
          /*удаление файла 
          string path1 = @"C:\SomeDir2\note.txt";
          FileInfo fileInf = new FileInfo(path1);
          if (fileInf.Exists)
          {
            fileInf.Delete();
            // альтернатива с помощью класса File
            // File.Delete(path);
          }*/
          break;
        case "3":
            

          break;
        case "4":

          break;
        case "5":
          
          break;
        default:
          break;
      }
     }
   }
}


